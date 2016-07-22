using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Admin
{
    public partial class FirmaEkle : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["admin"] == null)
                    Response.Redirect("Home.aspx");
                else
                {
                    FirmalariGetir();
                }
            }
        }

        private void FirmalariGetir()
        {
            bool onaydurumu = Convert.ToBoolean(ddlOnayDurumu.SelectedValue);

            var firma = ent.Firmalar.Where(f => f.OnayDurumu == onaydurumu).ToList();
            gvFirmalar.DataSource = firma;
            gvFirmalar.DataBind();
        }

        protected void gvFirmalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlYeniFirmaEkle.Visible = true;
            int firmano = Convert.ToInt32(gvFirmalar.SelectedValue);
            lblfirmano.Text = firmano.ToString();
            var firma = ent.Firmalar.Where(f => f.ID == firmano).FirstOrDefault();
            var adresi=ent.Adresler.Where(f => f.FirmaID == firmano).FirstOrDefault();
            txtAd.Text = firma.YetkiliAd;
            txtEmail.Text = firma.FirmaMail;
            txtFirmaAdi.Text = firma.FirmaAd;
            txtIl.Text = adresi.Il;
            txtIlce.Text = adresi.Ilce;
            txtKullaniciAdi.Text = firma.KullaniciAd;
            txtSifre.Text = firma.Sifre;
            txtSoyad.Text = firma.YetkiliSoyad;
            txtTcNo.Text = firma.VergiNo;
            txtTelefon.Text = firma.Telefon;
            txtTeslimAdresi.Text = adresi.Adres;
            txtVergi.Text = firma.VergiDairesi;

            if (firma.OnayDurumu == false)
                btnOnayla.Enabled = true;        
        }

        protected void gvFirmalar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int firmano = Convert.ToInt32(gvFirmalar.SelectedValue);
            var firma = ent.Firmalar.Where(f => f.ID == firmano).FirstOrDefault();
            firma.Silindi = true;
            ent.SaveChanges();
            FirmalariGetir();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if(lblfirmano.Text == "0")
            {
                DataModel.Firmalar yenifirma = new DataModel.Firmalar();
                yenifirma.FirmaAd = txtFirmaAdi.Text;
                yenifirma.FirmaMail = txtEmail.Text;
                yenifirma.KullaniciAd = txtKullaniciAdi.Text;
                yenifirma.Sifre = txtSifre.Text;
                yenifirma.Telefon = txtTelefon.Text;
                yenifirma.VergiDairesi = txtVergi.Text;
                yenifirma.VergiNo = txtTcNo.Text;
                yenifirma.YetkiliAd = txtAd.Text;
                yenifirma.YetkiliSoyad = txtSoyad.Text;
                ent.Firmalar.Add(yenifirma);
                try
                {
                    ent.SaveChanges();
                    var firma = ent.Firmalar.Where(f => f.FirmaAd == txtFirmaAdi.Text).FirstOrDefault();
                    int firmano = firma.ID;
                    DataModel.Adresler firmadresi = new DataModel.Adresler();
                    firmadresi.FirmaID = firmano;
                    firmadresi.Adres = txtTeslimAdresi.Text;
                    firmadresi.Il = txtIl.Text;
                    firmadresi.Ilce = txtIlce.Text;
                    ent.Adresler.Add(firmadresi);
                    ent.SaveChanges();
                    Temizle();
                    FirmalariGetir();
                    pnlYeniFirmaEkle.Visible = false;
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }
        }


        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            int firmano = Convert.ToInt32(lblfirmano.Text);
            var firma = ent.Firmalar.Where(f => f.ID == firmano).FirstOrDefault();
            firma.OnayDurumu = true;
            ent.SaveChanges();
            Temizle();
            FirmalariGetir();
            pnlYeniFirmaEkle.Visible = false;
        }

        protected void lbtnFirmaEkle_Click(object sender, EventArgs e)
        {
            pnlYeniFirmaEkle.Visible = true;
            Temizle();
        }

        private void Temizle()
        {
            lblfirmano.Text = "0";
            txtAd.Text = "";
            txtEmail.Text = "";
            txtFirmaAdi.Text = "";
            txtIl.Text = "";
            txtIlce.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtSoyad.Text = "";
            txtTcNo.Text = "";
            txtTelefon.Text = "";
            txtTeslimAdresi.Text = "";
            txtVergi.Text = "";
            btnOnayla.Enabled = false;
            txtFirmaAdi.Focus();
        }
    }
}