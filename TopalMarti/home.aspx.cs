using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TopalMarti.DataModel;

namespace TopalMarti
{
    public partial class home : System.Web.UI.Page
    {
        TopalMartiEntities2 ent = new TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Panel pnlkayitol = (Panel)this.Master.FindControl("pnlkayitol");
                Panel pnlhesap= (Panel)this.Master.FindControl("pnlcikisyap");
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

                KategorileriGetir();

                var Kampanyali = (from k in ent.Kampanyalar
                                  join fu in ent.Firma_Urunler on k.FirmaUrunID equals fu.ID
                                  join u in ent.Urunler on fu.UrunID equals u.UrunID
                                  where k.Silindi == false
                                  select new
                                  {
                                      fu.ID,
                                      fu.UrunResimYolu1,
                                      k.BitisTarihi,
                                      k.BaslangicTarihi,
                                      k.KampanyaFiyati,
                                      k.Stok,
                                      k.Aciklama,
                                      fu.UrunID,
                                      u.UrunAd,
                                      u.UrunUstKategoriNo,
                                      u.UrunAltKategoriNo,
                                      u.UrunKategoriNo
                                  }).ToList();
                dlstKampanyali.DataSource = Kampanyali;
                dlstKampanyali.DataBind();


            }
        }

        private void KategorileriGetir()
        {
            var ustkategoriler = ent.UstKategoriler.Where(x => x.Silindi == false).Select(x => x).ToList();

            foreach (var ustkategori in ustkategoriler)
            {
                MenuItem mitm = new MenuItem();
                mitm.Text = ustkategori.UstKategoriAd;
                mitm.Value = ustkategori.ID.ToString();
                mnuKategoriler.Items.Add(mitm);

                var kategoriler = ent.Kategoriler.Where(x => x.Silindi == false && x.UstKategoriID == ustkategori.ID).Select(x => x).ToList();

                foreach (var kategori in kategoriler)
                {
                    MenuItem citm = new MenuItem();
                    citm.Text = kategori.KategoriAd;
                    citm.Value = kategori.ID.ToString();
                    mitm.ChildItems.Add(citm);

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
        }

        protected void mnuKategoriler_MenuItemClick(object sender, MenuEventArgs e)
        {
            //Response.Write("Yol : " + e.Item.ValuePath);

            int katno = 0;
            int altkatno = 0;
            string[] Degerler = e.Item.ValuePath.Split('/');

            if (Degerler.Length == 1)
            {
                Response.Redirect("Products.aspx?ukno=" + Degerler[0]);
            }
            else
            {
                if (Degerler.Length > 1)
                    katno = Convert.ToInt16(Degerler[1]);
                if (Degerler.Length > 2)
                    altkatno = Convert.ToInt16(Degerler[2]);

                Response.Redirect("Products.aspx?ukno=" + Degerler[0] + "&kno=" + katno + "&akno=" + altkatno);
            }
        }

        protected void dlstKampanyali_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName=="detay")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("Details.aspx?firmaurunid=" + id);
            }
        }
    }
}