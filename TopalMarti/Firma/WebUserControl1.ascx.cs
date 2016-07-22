using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Firma
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
            var firma = (from f in ent.Firmalar
                           where f.KullaniciAd == txtKullaniciAdi.Text && f.Sifre == txtSifre.Text && f.OnayDurumu == true && f.Silindi == false
                           select f).FirstOrDefault();

            if (firma != null)
            {
                lblMesaj.Text = "";
                Session["firma"] = firma.ID;
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