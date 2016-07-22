using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Admin
{

    public partial class SatisIslemleri : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    var satislar = (from s in ent.Siparisler
                                    join k in ent.Kullanicilar on s.KullaniciID equals k.ID
                                    where s.Silindi == false
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
        }

        protected void gvSatislar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int satisid = Convert.ToInt32(gvSatislar.SelectedValue);
            pnlSiparisDetay.Visible = true;

            var satisdetay = (from sd in ent.SiparisDetaylari
                              join fu in ent.Firma_Urunler on sd.FirmaUrunID equals fu.ID
                              join u in ent.Urunler on fu.UrunID equals u.UrunID
                              where sd.Silindi == false
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