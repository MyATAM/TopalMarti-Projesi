using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti
{
    public partial class Sepet : System.Web.UI.Page
    {
        Models.cSepet spt = new Models.cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Panel pnlkayitol = (Panel)this.Master.FindControl("pnlkayitol");
                Panel pnlhesap = (Panel)this.Master.FindControl("pnlcikisyap");
                Panel pnlSepet = (Panel)this.Master.FindControl("pnlsepet");
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

                if (Session["sepet"] != null)
                {
                    SepetiGoster((DataTable)Session["sepet"]);

                }
                else
                {
                    DataTable dt = spt.YeniSepet();
                    Session["sepet"] = dt;
                    gvSepet.DataSource = dt;
                    gvSepet.DataBind();
                }
            }
        }

        private int ToplamAdetBul()
        {
            int ToplamAdet = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow drow in dt.Rows)
            {
                ToplamAdet += Convert.ToInt32(drow["adet"]);
            }
            return ToplamAdet;
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

        private void SepetiGoster(DataTable dt)
        {
            gvSepet.Columns[1].FooterText = "Toplam :";
            gvSepet.Columns[1].FooterStyle.HorizontalAlign = HorizontalAlign.Right;
            gvSepet.Columns[2].FooterText = ToplamAdetBul().ToString();
            gvSepet.Columns[2].FooterStyle.HorizontalAlign = HorizontalAlign.Center;
            gvSepet.Columns[3].FooterText = ToplamTutarBul().ToString();
            gvSepet.Columns[3].FooterStyle.HorizontalAlign = HorizontalAlign.Right;
            gvSepet.DataSource = dt;
            gvSepet.DataBind();
        }

        protected void btnSepetiBosalt_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            Session["sepet"] = dt;
            SepetiGoster(dt);
        }

        protected void btnDevam_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnSatinAl_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];
            if (dt.Rows.Count > 0)
                Response.Redirect("AdresOnay.aspx");
        }

        protected void gvSepet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];
            dt.Rows.RemoveAt(e.RowIndex);
            Session["sepet"] = dt;
            SepetiGoster(dt);
        }
    }
}