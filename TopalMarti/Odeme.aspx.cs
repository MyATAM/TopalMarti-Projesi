using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti
{
    public partial class Odeme : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Panel pnlkayitol = (Panel)this.Master.FindControl("pnlkayitol");
                Panel pnlhesap = (Panel)this.Master.FindControl("pnlcikisyap");
                Panel pnlSepet = (Panel)this.Master.FindControl("pnlodeme");
                pnlSepet.Visible = true;

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

                int id = Convert.ToInt32(Session["uye"]);
                if (Session["uye"] != null)
                {
                    var kullanici = ent.Kullanicilar.Where(k => k.ID == id).Select(k => k).FirstOrDefault();
                    lblAdi.Text = kullanici.Ad;
                    lblSoyadi.Text = kullanici.Soyad;
                    lblTutar.Text = ToplamTutarBul().ToString("C");
                }
            }
        }

        private decimal ToplamTutarBul()
        {
            decimal ToplamTutar = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow drow in dt.Rows)
            {
                ToplamTutar += Convert.ToDecimal(drow["tutar"]);
            }
            return ToplamTutar;
        }

        protected void btnHavaleEFT_Click(object sender, EventArgs e)
        {
            pnlHavaleEFT.Visible = true;    
        }

        protected void btnAlisveriseDevam_Click(object sender, EventArgs e)
        {
            Session.Remove("sepet");
            Response.Redirect("home.aspx");
        }

        protected void btnGuvenliCikis_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Home.aspx");
        }
    }
}