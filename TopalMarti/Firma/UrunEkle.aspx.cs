using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Firma
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["firma"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    var UstKategori = ent.UstKategoriler.Where(k => k.Silindi == false).Select(k => k).ToList();
                    ddlUstKategoriler.DataTextField = "UstKategoriAd";
                    ddlUstKategoriler.DataValueField = "ID";
                    ddlUstKategoriler.DataSource = UstKategori;
                    ddlUstKategoriler.DataBind();

                    Panel pnlAdminIslemleri = (Panel)this.Master.FindControl("pnlAdminIslemleri");
                    pnlAdminIslemleri.Visible = true;

                    KategorileriGetirByUstKategori(Convert.ToInt32(ddlUstKategoriler.SelectedValue));

                    AltKategorilerbyKategoriID(Convert.ToInt32(ddlKategoriler.SelectedValue));
                    UrunleriGetir();

                }
            }
        }

        private void KategorileriGetirByUstKategori(int ustkategori)
        {
            var kategori = ent.Kategoriler.Where(k =>k.UstKategoriID==ustkategori && k.Silindi == false).Select(k => k).ToList();
            ddlKategoriler.DataTextField = "KategoriAd";
            ddlKategoriler.DataValueField = "ID";
            ddlKategoriler.DataSource = kategori;
            ddlKategoriler.DataBind();
        }

        private void UrunleriGetir()
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.FirmaNo == firmano && fu.Silindi == false
                        select new
                        {
                            fu.Stok,
                            u.UrunAd,
                            u.UrunKodu,
                            fu.BirimFiyat,
                            fu.UrunBilgisi,
                            fu.UrunResimYolu1,
                            fu.UrunResimYolu2,
                            fu.UrunID
                        }).ToList();
            gvUrunler.DataSource = urun;
            gvUrunler.DataBind();
        }

        private void AltKategorilerbyKategoriID(int kategoriId)
        {
            var altkategori = ent.AltKategoriler.Where(k => k.Silindi == false && k.KategoriID == kategoriId).Select(k => k).ToList();

            ddlAltKategoriler.DataTextField = "AltKategoriAd";
            ddlAltKategoriler.DataValueField = "ID";
            ddlAltKategoriler.DataSource = altkategori;
            ddlAltKategoriler.DataBind();
        }

        protected void gvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlekle.Visible = true;
            string[] urunkodu = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[1].Text).Split('-');
            txtUrunKodu.Text = urunkodu[1];
            txtUrunAdi.Text = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[2].Text);
            txtStok.Text = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[3].Text);
            txtFiyat.Text = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[4].Text);
            txtAçıklama.Text = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[5].Text);
            Session["urun"] = gvUrunler.SelectedDataKey.Value.ToString();
            btnKaydet.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void ddlUstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            KategorileriGetirByUstKategori(Convert.ToInt32(ddlUstKategoriler.SelectedValue));
            UrunleriGetirByUstKAtegoriNo(Convert.ToInt32(ddlUstKategoriler.SelectedValue));
        }

        private void UrunleriGetirByUstKAtegoriNo(int ustkategorino)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.FirmaNo == firmano && fu.Silindi == false
                        select new
                        {
                            fu.Stok,
                            u.UrunAd,
                            u.UrunKodu,
                            fu.BirimFiyat,
                            fu.UrunBilgisi,
                            fu.UrunResimYolu1,
                            fu.UrunResimYolu2,
                            fu.UrunID
                        }).ToList();

            gvUrunler.DataSource = urun;
            gvUrunler.DataBind();
        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            AltKategorilerbyKategoriID(Convert.ToInt32(ddlKategoriler.SelectedValue));
            UrunleriGetirByKAtegoriNo(Convert.ToInt32(ddlKategoriler.SelectedValue));
        }

        private void UrunleriGetirByKAtegoriNo(int kategoriId)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.FirmaNo == firmano && fu.Silindi == false
                        select new
                        {
                            fu.Stok,
                            u.UrunAd,
                            u.UrunKodu,
                            fu.BirimFiyat,
                            fu.UrunBilgisi,
                            fu.UrunResimYolu1,
                            fu.UrunResimYolu2,
                            fu.UrunID
                        }).ToList();
            gvUrunler.DataSource = urun;
            gvUrunler.DataBind();
        }

        protected void ddlAltKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriGetirbyAltKategori(Convert.ToInt32(ddlAltKategoriler.SelectedValue));
        }

        private void UrunleriGetirbyAltKategori(int altKategoriId)
        {
            int firmano = Convert.ToInt32(Session["firma"]);
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.FirmaNo == firmano && fu.Silindi == false
                        select new
                        {
                            fu.Stok,
                            u.UrunAd,
                            u.UrunKodu,
                            fu.BirimFiyat,
                            fu.UrunBilgisi,
                            fu.UrunResimYolu1,
                            fu.UrunResimYolu2,
                            fu.UrunID
                        }).ToList();

            gvUrunler.DataSource = urun;
            gvUrunler.DataBind();
        }

        private void Temizle()
        {
            txtUrunAdi.Text = "";
            txtAçıklama.Text = "";
            txtStok.Text = "";
            txtFiyat.Text = "";
            txtUrunKodu.Text = "";
            txtUrunKodu.Focus();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (UrunVarmi())
            {
                int urunid = Convert.ToInt32(Session["urun"]);

                var urun = ent.Urunler.Where(k => k.UrunID == urunid).FirstOrDefault();

                var firmaurun = ent.Firma_Urunler.Where(k => k.UrunID == urunid).FirstOrDefault();                

                urun.UrunKodu = "TAS-" + txtUrunKodu.Text;
                urun.UrunAd = txtUrunAdi.Text;
                firmaurun.Stok = Convert.ToInt32(txtStok.Text);
                firmaurun.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                firmaurun.UrunBilgisi = txtAçıklama.Text;

                int ustkategoriId = Convert.ToInt32(ddlUstKategoriler.SelectedValue);
                int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
                int altkategoriId = Convert.ToInt32(ddlAltKategoriler.SelectedValue);

                urun.UrunUstKategoriNo = ustkategoriId;
                urun.UrunKategoriNo = kategoriId;
                urun.UrunAltKategoriNo = altkategoriId;
                if (fuKucukResim.HasFile)
                {
                    fuKucukResim.SaveAs(Server.MapPath("/Topal/urunimages/images/" + fuKucukResim.FileName));
                }
                if (fuBuyukResim.HasFile)
                {
                    fuBuyukResim.SaveAs(Server.MapPath("/Topal/urunimages/images/buyuk/" + fuBuyukResim.FileName));

                }

                firmaurun.UrunResimYolu1 = "/Topal/urunimages/images/" + fuKucukResim.FileName;
                firmaurun.UrunResimYolu2 = "/Topal/urunimages/images/buyuk/" + fuBuyukResim.FileName;

                try
                {
                    ent.SaveChanges();
                    UrunleriGetir();
                    Temizle();
                    btnKaydet.Enabled = false;
                    btnSil.Enabled = false;
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }
            else
            {
                DataModel.Urunler urun = new DataModel.Urunler();
                urun.UrunKodu = "TAS-" + txtUrunKodu.Text;
                urun.UrunAd = txtUrunAdi.Text;

                int ustkategoriId = Convert.ToInt32(ddlUstKategoriler.SelectedValue);
                int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
                int altkategoriId = Convert.ToInt32(ddlAltKategoriler.SelectedValue);

                urun.UrunUstKategoriNo = ustkategoriId;
                urun.UrunKategoriNo = kategoriId;
                urun.UrunAltKategoriNo = altkategoriId;
                

                ent.Urunler.Add(urun);
                try
                {
                    ent.SaveChanges();
                    var urunid = ent.Urunler.Where(u => u.UrunAd == txtUrunAdi.Text).FirstOrDefault();

                    DataModel.Firma_Urunler firmaurun = new DataModel.Firma_Urunler();
                    firmaurun.UrunID = Convert.ToInt32(urunid.UrunID);
                    firmaurun.FirmaNo = Convert.ToInt32(Session["firma"]);
                    firmaurun.Stok = Convert.ToInt32(txtStok.Text);
                    firmaurun.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                    firmaurun.UrunBilgisi = txtAçıklama.Text;
                    if (fuKucukResim.HasFile)
                    {
                        fuKucukResim.SaveAs(Server.MapPath("/Topal/urunimages/images/" + fuKucukResim.FileName));
                    }
                    if (fuBuyukResim.HasFile)
                    {
                        fuBuyukResim.SaveAs(Server.MapPath("/Topal/urunimages/images/buyuk/" + fuBuyukResim.FileName));

                    }

                    firmaurun.UrunResimYolu1 = "/Topal/urunimages/images/" + fuKucukResim.FileName;
                    firmaurun.UrunResimYolu2 = "/Topal/urunimages/images/buyuk/" + fuBuyukResim.FileName;
                    ent.Firma_Urunler.Add(firmaurun);

                    ent.SaveChanges();

                    UrunleriGetir();
                    Temizle();
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }

            pnlekle.Visible = false;
            Session["urun"] = null;
        }

        private bool UrunVarmi()
        {
            int urunid = Convert.ToInt32(Session["urun"]);
            var urun = ent.Urunler.Where(u => u.UrunID == urunid).Select(u => u).FirstOrDefault();
            if (urun != null) return true;
            return false;
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int urunid = Convert.ToInt32(Session["urun"]);
            var urun = ent.Firma_Urunler.Where(u => u.UrunID == urunid).Select(u => u).FirstOrDefault();
            urun.Silindi = true;
            try
            {
                ent.SaveChanges();

                UrunleriGetir();
                pnlekle.Visible = false;
                Temizle();
                btnKaydet.Enabled = false;
                btnSil.Enabled = false;
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
        }

        protected void lbtnYeniUrunEkle_Click(object sender, EventArgs e)
        {
            Temizle();
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;
            pnlekle.Visible = true;

        }
    }
}