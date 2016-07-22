using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Firma
{
    public partial class KayitOl : System.Web.UI.Page
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

                    int firmaid = Convert.ToInt32(Session["firma"]);
                    var firma = ent.Firmalar.Where(f => f.ID == firmaid).FirstOrDefault();
                    var adresi = ent.Adresler.Where(a => a.FirmaID == firmaid).FirstOrDefault();

                    txtAd.Text = firma.YetkiliAd;
                    txtEmail.Text = firma.FirmaMail;
                    txtIl.Text = adresi.Il;
                    txtIlce.Text = adresi.Ilce;
                    txtKullaniciAdi.Text = firma.KullaniciAd;
                    txtSifre.Text = firma.Sifre;
                    txtSoyad.Text = firma.YetkiliSoyad;
                    txtTcNo.Text = firma.VergiNo;
                    txtTelefon.Text = firma.Telefon;
                    txtTeslimAdresi.Text = adresi.Adres;
                    txtVergi.Text = firma.VergiDairesi;
                    
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            int firmaid = Convert.ToInt32(Session["firma"]);
            var firma = ent.Firmalar.Where(f => f.ID == firmaid).FirstOrDefault();
            var adresi = ent.Adresler.Where(a => a.FirmaID == firmaid).FirstOrDefault();

            firma.YetkiliAd = txtAd.Text;
            firma.FirmaMail = txtEmail.Text;
            firma.KullaniciAd = txtKullaniciAdi.Text;
            firma.Sifre = txtSifre.Text;
            firma.YetkiliSoyad = txtSoyad.Text;
            firma.VergiNo = txtTcNo.Text;
            firma.Telefon = txtTelefon.Text;
            firma.VergiDairesi = txtVergi.Text;
            adresi.Il = txtIl.Text;
            adresi.Ilce = txtIlce.Text;
            adresi.Adres = txtTeslimAdresi.Text;

            ent.SaveChanges();
            Response.Redirect("Home.aspx");
        }
    }
}