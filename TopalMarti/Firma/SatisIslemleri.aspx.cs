using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Firma
{
    public partial class SatisIslemleri : System.Web.UI.Page
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
                }
                else
                    Response.Redirect("Home.aspx");

                int firmaid = Convert.ToInt32(Session["firma"]);

                var satislar = (from s in ent.Siparisler
                                join k in ent.Kullanicilar on s.KullaniciID equals k.ID
                                join sd in ent.SiparisDetaylari on s.ID equals sd.SatisID
                                join fu in ent.Firma_Urunler on sd.FirmaUrunID equals fu.ID
                                where s.Silindi == false && fu.FirmaNo == firmaid
                                select new
                                {
                                    s.ID,
                                    s.Tarih,
                                    s.Miktar,
                                    s.Tutar,
                                    s.SiparisDurumu,
                                    musteri = k.Ad + " " + k.Soyad,
                                    s.TeslimTarihi
                                }).OrderByDescending(k => k.Tarih).ToList();
                gvSatislar.DataSource = satislar;
                gvSatislar.DataBind();
            }
        }

        protected void gvSatislar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int satisid = Convert.ToInt32(gvSatislar.SelectedValue);
            pnlSiparisDetay.Visible = true;

            int firmaid = Convert.ToInt32(Session["firma"]);
            var satisdetay = (from sd in ent.SiparisDetaylari
                              join fu in ent.Firma_Urunler on sd.FirmaUrunID equals fu.ID
                              join u in ent.Urunler on fu.UrunID equals u.UrunID
                              where sd.Silindi == false && fu.FirmaNo == firmaid
                              select new
                              {
                                  sd.ID,
                                  u.UrunKodu,
                                  u.UrunAd,
                                  sd.Adet,
                                  sd.BirimFiyat,
                                  sd.Tutar
                              }).ToList();
            gvSatışDetay.DataSource = satisdetay;
            gvSatışDetay.DataBind();
        }
    }
}