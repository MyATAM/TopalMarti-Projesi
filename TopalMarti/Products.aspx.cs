using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti
{
    public partial class Products : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int ustkno = 0;
                int kno = 0;
                int altkno = 0;
                int urunid = 0;
                ustkno = Convert.ToInt32(Request.QueryString["ukno"]);
                kno = Convert.ToInt32(Request.QueryString["kno"]);
                altkno = Convert.ToInt32(Request.QueryString["akno"]);
                urunid = Convert.ToInt32(Request.QueryString["urunid"]);

                if (urunid != 0)
                {
                    UrunleriGetirByUrunID(urunid);
                    
                }
                else if (kno == 0 && altkno == 0)
                {
                    UrunleriGetirByUstKategori(ustkno);
                    UstKategoriGetir(ustkno);
                }
                else if(altkno==0)
                {
                    UrunleriGetirByKategori(kno);
                    
                }
                else
                {
                    UrunleriGetirByAltKategori(altkno);
                    
                }


                Panel pnlkayitol = (Panel)this.Master.FindControl("pnlkayitol");
                Panel pnlhesap = (Panel)this.Master.FindControl("pnlcikisyap");
                Panel pnlGenisArama = (Panel)this.Master.FindControl("pblArama");
                pnlGenisArama.Visible = true;

                if (Session["uye"] != null)
                {
                    pnlkayitol.Visible = false;
                    pnlhesap.Visible = true;
                }
                else
                {
                    pnlkayitol.Visible = true;
                    pnlhesap.Visible = false;
                }

                Panel pnlKategoriler = (Panel)this.Master.FindControl("pnlKategoriler");
                pnlKategoriler.Visible = true;
            }
        }

        

        private void UrunleriGetirByAltKategori(int altkno)
        {
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.Silindi == false && u.UrunAltKategoriNo == altkno
                        select new
                        {
                            fu.ID,
                            u.UrunAd,
                            fu.UrunResimYolu1,
                            fu.BirimFiyat,
                            fu.UrunBilgisi
                        }).ToList();
            dlstUrunler.DataSource = urun;
            dlstUrunler.DataBind();
        }

        

        private void UrunleriGetirByKategori(int kno)
        {
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.Silindi == false && u.UrunKategoriNo == kno
                        select new
                        {
                            fu.ID,
                            u.UrunAd,
                            fu.UrunResimYolu1,
                            fu.BirimFiyat,
                            fu.UrunBilgisi
                        }).ToList();
            dlstUrunler.DataSource = urun;
            dlstUrunler.DataBind();
        }

        private void UrunleriGetirByUstKategori(int ustkno)
        {
            mnuKategoriler.Visible = true;

            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.Silindi == false && u.UrunUstKategoriNo == ustkno
                        select new
                        {
                            fu.ID,
                            u.UrunAd,
                            fu.UrunResimYolu1,
                            fu.BirimFiyat,
                            fu.UrunBilgisi
                        }).ToList();
            dlstUrunler.DataSource = urun;
            dlstUrunler.DataBind();
        }

       

        private void UrunleriGetirByUrunID(int urunid)
        {
            var urun = (from fu in ent.Firma_Urunler
                        join u in ent.Urunler on fu.UrunID equals u.UrunID
                        where fu.Silindi == false && u.UrunID == urunid
                        select new
                        {
                            fu.ID,
                            u.UrunAd,
                            fu.UrunResimYolu1,
                            fu.BirimFiyat,
                            fu.UrunBilgisi
                        }).ToList();
            dlstUrunler.DataSource = urun;
            dlstUrunler.DataBind();
        }

        private void UstKategoriGetir(int ustkno)
        {
            mnuKategoriler.Visible = true;
            var kategoriler = ent.Kategoriler.Where(x => x.Silindi == false && x.UstKategoriID == ustkno).Select(x => x).ToList();

            foreach (var kategori in kategoriler)
            {
                MenuItem citm = new MenuItem();
                citm.Text = kategori.KategoriAd;
                citm.Value = kategori.ID.ToString();
                mnuKategoriler.Items.Add(citm);

                var altkategoriler = ent.AltKategoriler.Where(x => x.Silindi == false && x.KategoriID == kategori.ID).Select(x => x).ToList();

                foreach (var altkategori in altkategoriler)
                {
                    MenuItem citm1 = new MenuItem();
                    citm1.Text = altkategori.AltKategoriAd;
                    citm1.Value = altkategori.ID.ToString();
                    citm.ChildItems.Add(citm1);
                }
            }
        }

        protected void mnuOzellikler_MenuItemClick(object sender, MenuEventArgs e)
        {
            string[] degerler = e.Item.ValuePath.Split('/');
            if (degerler.Length > 1)
                Response.Redirect("Products.aspx?aoz=" + degerler[1]);
        }

        protected void dlstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dlstUrunler_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detay")
            {
                int firmaurunid = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Details.aspx?firmaurunid=" + firmaurunid);
            }
        }
    }
}