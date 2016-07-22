using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Admin
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtKullaniciAdi.Focus();
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            var admin = (from k in ent.Kullanicilar
                           where k.KullaniciAd == txtKullaniciAdi.Text && k.Sifre == txtSifre.Text && k.Admin == true && k.Silindi == false
                           select k).FirstOrDefault();

            if (admin != null)
            {
                lblMesaj.Text = "";
                Session["admin"] = admin.ID;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMesaj.Visible = true;
                lblMesaj.Text = "Kullanıcı Adı ve Şifre Yanlış";
                txtKullaniciAdi.Focus();
            }
        }
    }
}