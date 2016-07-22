using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Firma
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["firma"] == null)
                    Response.Redirect("Home.aspx");
                else
                {
                    pnlAdminIslemleri.Visible = true;
                    pnlcikisyap.Visible = true;
                }
            }
        }

        protected void imgbtnHesabim_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("KayitOl.aspx?id=" + Session["firma"]);
        }

        protected void imbntnCikisYap_Click(object sender, ImageClickEventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Home.aspx");
        }

        protected void imgbtnAnasayfa_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}