using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Firma
{
    public partial class SatisOnay : System.Web.UI.Page
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

                    SiparisDurumuGetir();
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        private void SiparisDurumuGetir()
        {
            int firmaid = Convert.ToInt32(Session["firma"]);
            var siparisdurumu = (from sd in ent.SiparisDetaylari
                                 join s in ent.Siparisler on sd.SatisID equals s.ID
                                 join fu in ent.Firma_Urunler on sd.FirmaUrunID equals fu.ID
                                 join u in ent.Urunler on fu.UrunID equals u.UrunID
                                 where fu.FirmaNo == firmaid && s.SiparisDurumu != 5
                                 select new
                                 {
                                     sd.ID,
                                     s.Tarih,
                                     u.UrunKodu,
                                     u.UrunAd,
                                     s.TeslimTarihi,
                                     s.SiparisDurumu
                                 }).ToList();

            gvSatışDurumu.DataSource = siparisdurumu;
            gvSatışDurumu.DataBind();
        }

        protected void gvSatışDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int satisdetayid = Convert.ToInt32(gvSatışDurumu.SelectedRow.Cells[1].Text);
            Session["satisdetayid"] = satisdetayid;
            int siparisdurumu = Convert.ToInt32(gvSatışDurumu.SelectedRow.Cells[6].Text);
            if (siparisdurumu == 1)
            {
                btnHazirlik.Enabled = false;
                btnKargo.Enabled = false;
                btnOdemeOnay.Enabled = true;
                btnTeslim.Enabled = false;
            }
            else if (siparisdurumu == 2)
            {
                btnHazirlik.Enabled = true;
                btnKargo.Enabled = false;
                btnOdemeOnay.Enabled = false;
                btnTeslim.Enabled = false;
            }
            else if (siparisdurumu == 3)
            {
                btnHazirlik.Enabled = false;
                btnKargo.Enabled = true;
                btnOdemeOnay.Enabled = false;
                btnTeslim.Enabled = false;
            }
            else
            {
                btnHazirlik.Enabled = false;
                btnKargo.Enabled = false;
                btnOdemeOnay.Enabled = false;
                btnTeslim.Enabled = true;
            }
        }

        protected void btnOdemeOnay_Click(object sender, EventArgs e)
        {
            int siparisdetayid = Convert.ToInt32(Session["satisdetayid"]);
            var siparisdurumu = (from sd in ent.SiparisDetaylari
                                 join s in ent.Siparisler on sd.SatisID equals s.ID
                                 where sd.ID == siparisdetayid
                                 select s).FirstOrDefault();
            siparisdurumu.SiparisDurumu = 2;
            ent.SaveChanges();
            SiparisDurumuGetir();
        }

        protected void btnHazirlik_Click(object sender, EventArgs e)
        {
            int siparisdetayid = Convert.ToInt32(Session["satisdetayid"]);
            var siparisdurumu = (from sd in ent.SiparisDetaylari
                                 join s in ent.Siparisler on sd.SatisID equals s.ID
                                 where sd.ID == siparisdetayid
                                 select s).FirstOrDefault();
            siparisdurumu.SiparisDurumu = 3;
            ent.SaveChanges();
            SiparisDurumuGetir();
        }

        protected void btnKargo_Click(object sender, EventArgs e)
        {
            int siparisdetayid = Convert.ToInt32(Session["satisdetayid"]);
            var siparisdurumu = (from sd in ent.SiparisDetaylari
                                 join s in ent.Siparisler on sd.SatisID equals s.ID
                                 where sd.ID == siparisdetayid
                                 select s).FirstOrDefault();
            siparisdurumu.SiparisDurumu = 4;
            ent.SaveChanges();
            SiparisDurumuGetir();
        }

        protected void btnTeslim_Click(object sender, EventArgs e)
        {
            int siparisdetayid = Convert.ToInt32(Session["satisdetayid"]);
            var siparisdurumu = (from sd in ent.SiparisDetaylari
                                 join s in ent.Siparisler on sd.SatisID equals s.ID
                                 where sd.ID == siparisdetayid
                                 select s).FirstOrDefault();
            siparisdurumu.SiparisDurumu = 5;
            ent.SaveChanges();
            SiparisDurumuGetir();
        }
    }
}