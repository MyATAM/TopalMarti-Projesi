using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["admin"]==null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    pnlAdminIslemleri.Visible = true;
                    pnlcikisyap.Visible = true;
                }
            }
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