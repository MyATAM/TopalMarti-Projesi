using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Firma
{
    public partial class KampanyaIslemleri : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["firma"] != null)
                {
                    Panel pnlAdminIslemleri = (Panel)this.Master.FindControl("pnlAdminIslemleri");
                    pnlAdminIslemleri.Visible = true;

                    KampanyalıUrunleriGetir();
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        private void KampanyalıUrunleriGetir()
        {
            int firmaid = Convert.ToInt32(Session["firma"]);
            var kampanyalılar = (from k in ent.Kampanyalar
                                 join fu in ent.Firma_Urunler on k.FirmaUrunID equals fu.ID
                                 join u in ent.Urunler on fu.UrunID equals u.UrunID
                                 where k.Silindi == false && fu.FirmaNo == firmaid
                                 select new
                                 {
                                     k.ID,
                                     k.BaslangicTarihi,
                                     k.BitisTarihi,
                                     u.UrunKodu,
                                     u.UrunAd,
                                     k.KampanyaFiyati,
                                     fu.BirimFiyat,
                                     k.Stok,
                                     k.Aciklama
                                 }).OrderByDescending(k=>k.BirimFiyat).ToList();
            gvUrunler.DataSource = kampanyalılar;
            gvUrunler.DataBind();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            DataModel.Kampanyalar yenikampanya = new DataModel.Kampanyalar();
            yenikampanya.BaslangicTarihi = Convert.ToDateTime(txtBaslangicTarihi.Text);
            yenikampanya.BitisTarihi = Convert.ToDateTime(txtBitisTarihi.Text);
            yenikampanya.KampanyaFiyati = Convert.ToDecimal(txtKampanyaFiyatı.Text);
            yenikampanya.Stok = Convert.ToInt32(txtKampanyaStok.Text);
            yenikampanya.Aciklama = txtAçıklama.Text;

            int firmaid = Convert.ToInt32(Session["firma"]);
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where u.UrunKodu == ddlUrunKodları.SelectedItem.Text && fu.FirmaNo == firmaid
                        select fu).FirstOrDefault();

            yenikampanya.FirmaUrunID = Convert.ToInt32(urun.ID);
            ent.Kampanyalar.Add(yenikampanya);
            try
            {
                ent.SaveChanges();
                KampanyalıUrunleriGetir();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }

        }

        protected void lbtn_Click(object sender, EventArgs e)
        {
            pnlekle.Visible = true;

            var UstKategori = ent.UstKategoriler.Where(k => k.Silindi == false).Select(k => k).ToList();
            ddlUstKategoriler.DataTextField = "UstKategoriAd";
            ddlUstKategoriler.DataValueField = "ID";
            ddlUstKategoriler.DataSource = UstKategori;
            ddlUstKategoriler.DataBind();

            KategorileriGetirByUstKategori(Convert.ToInt32(ddlUstKategoriler.SelectedValue));
        }

        private void KategorileriGetirByUstKategori(int ustkategori)
        {
            var kategori = ent.Kategoriler.Where(k => k.UstKategoriID == ustkategori && k.Silindi == false).Select(k => k).ToList();
            ddlKategoriler.DataTextField = "KategoriAd";
            ddlKategoriler.DataValueField = "ID";
            ddlKategoriler.DataSource = kategori;
            ddlKategoriler.DataBind();
        }

        protected void gvUrunler_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvUrunler.SelectedDataKey);
            var kampanyalıurun = ent.Kampanyalar.Where(k => k.ID == id).FirstOrDefault();
            kampanyalıurun.Silindi = true;
            ent.SaveChanges();
        }

        protected void ddlUstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            KategorileriGetirByUstKategori(Convert.ToInt32(ddlUstKategoriler.SelectedValue));
        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            AltKategorilerbyKategoriID(Convert.ToInt32(ddlKategoriler.SelectedValue));
        }
        private void AltKategorilerbyKategoriID(int kategoriId)
        {
            var altkategori = ent.AltKategoriler.Where(k => k.Silindi == false && k.KategoriID == kategoriId).Select(k => k).ToList();

            ddlAltKategoriler.DataTextField = "AltKategoriAd";
            ddlAltKategoriler.DataValueField = "ID";
            ddlAltKategoriler.DataSource = altkategori;
            ddlAltKategoriler.DataBind();
        }

        protected void ddlAltKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriGetir(Convert.ToInt32(ddlAltKategoriler.SelectedValue));
            UrunKodlarıGetir(Convert.ToInt32(ddlAltKategoriler.SelectedValue));
        }

        private void UrunleriGetir( int altkatid)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urun = (from u in ent.Urunler
                        join fu in ent.Firma_Urunler on u.UrunID equals fu.UrunID
                        where fu.FirmaNo == firmano && fu.Silindi == false && u.UrunAltKategoriNo==altkatid
                        select new
                        {
                            u.UrunAd,
                            u.UrunID
                        }).ToList();
            ddlUrunler.DataTextField = "UrunAd";
            ddlUrunler.DataValueField = "UrunID";
            ddlUrunler.DataSource = urun;
            ddlUrunler.DataBind();
        }

        private void UrunKodlarıGetir(int altkatid)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urunkodları = (from u in ent.Urunler
                        join fu in ent.Firma_Urunler on u.UrunID equals fu.UrunID
                        where fu.FirmaNo == firmano && fu.Silindi == false && u.UrunAltKategoriNo == altkatid
                        select new {
                            u.UrunKodu,
                            u.UrunID
                        }).ToList();
            ddlUrunKodları.DataTextField = "UrunKodu";
            ddlUrunKodları.DataValueField = "UrunID";
            ddlUrunKodları.DataSource = urunkodları;
            ddlUrunKodları.DataBind();
        }

        protected void ddlUrunKodları_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunGetir(Convert.ToInt32(ddlUrunKodları.SelectedValue));
            txtStok.Text = StokMiktari(Convert.ToInt32(ddlUrunKodları.SelectedValue));
            txtFiyat.Text = Fiyat(Convert.ToInt32(ddlUrunKodları.SelectedValue));
        }

        private string Fiyat(int urunid)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var firmaurun = ent.Firma_Urunler.Where(fu => fu.FirmaNo == firmano && fu.UrunID == urunid).FirstOrDefault();
            return firmaurun.BirimFiyat.ToString();
        }

        private string StokMiktari(int urunid)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var firmaurun = ent.Firma_Urunler.Where(fu => fu.FirmaNo == firmano && fu.UrunID == urunid).FirstOrDefault();
            return firmaurun.Stok.ToString();
        }

        private void UrunGetir(int urunid)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urun = (from u in ent.Urunler
                        join fu in ent.Firma_Urunler on u.UrunID equals fu.UrunID
                        where fu.FirmaNo == firmano && fu.Silindi == false && u.UrunID == urunid
                        select u).ToList();
            ddlUrunler.DataTextField = "UrunAd";
            ddlUrunler.DataValueField = "UrunID";
            ddlUrunler.DataSource = urun;
            ddlUrunler.DataBind();
        }

        protected void ddlUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunKoduGetir(Convert.ToInt32(ddlUrunler.SelectedValue));
        }

        private void UrunKoduGetir(int urunid)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urunkodları = (from u in ent.Urunler
                               join fu in ent.Firma_Urunler on u.UrunID equals fu.UrunID
                               where fu.FirmaNo == firmano && fu.Silindi == false && u.UrunID == urunid
                               select u).ToList();
            ddlUrunKodları.DataTextField = "UrunKodu";
            ddlUrunKodları.DataValueField = "UrunID";
            ddlUrunKodları.DataSource = urunkodları;
            ddlUrunKodları.DataBind();
        }
    }
}