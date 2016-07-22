using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Admin
{
    public partial class MusteriIslemleri : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                    Response.Redirect("Home.aspx");
                else
                {
                    MusterileriGetir();
                }
            }
        }

        private void MusterileriGetir()
        {
            var musteri = ent.Kullanicilar.Where(k => k.Silindi == false).ToList();
            gvMusteriler.DataSource = musteri;
            gvMusteriler.DataBind();

            decimal toplamtutar = (from s in ent.Siparisler
                                   where s.Silindi == false
                                   select s.Tutar).ToList().Sum();

            int toplammiktar = (from s in ent.Siparisler
                                where s.Silindi == false
                                select s.Tutar).ToList().Count();

            txtToplamTutar.Text = toplamtutar.ToString();
            txtAlisverisMiktari.Text = toplammiktar.ToString();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if(lblMusteriNo.Text=="0")
            {
                DataModel.Kullanicilar yenikullanici = new DataModel.Kullanicilar();
                yenikullanici.Ad = txtAd.Text;
                yenikullanici.Soyad = txtSoyad.Text;
                yenikullanici.EMail = txtEmail.Text;
                yenikullanici.IkinciAd = txtIkinciAd.Text;
                yenikullanici.Sifre = txtSifre.Text;
                yenikullanici.TcKimlikNo = txtTcNo.Text;
                yenikullanici.Telefon = txtTelefon.Text;
                yenikullanici.KullaniciAd = txtKullaniciAdi.Text;
                ent.Kullanicilar.Add(yenikullanici);
                ent.SaveChanges();
                var kullanici = ent.Kullanicilar.Where(k => k.TcKimlikNo == txtTcNo.Text).FirstOrDefault();
                int kullaniciid = kullanici.ID;
                DataModel.Adresler yeniadres = new DataModel.Adresler();
                yeniadres.Adres = txtTeslimAdresi.Text;
                yeniadres.Il = txtIl.Text;
                yeniadres.Ilce = txtIlce.Text;
                yeniadres.KullaniciID = kullaniciid;
                ent.Adresler.Add(yeniadres);
                ent.SaveChanges();
            }
            else
            {
                int kullaniciid = Convert.ToInt32(lblMusteriNo.Text);
                var degisenkullanici = ent.Kullanicilar.Where(k => k.ID == kullaniciid).FirstOrDefault();
                var adresi = ent.Adresler.Where(a => a.KullaniciID == kullaniciid).FirstOrDefault();
                degisenkullanici.Ad = txtAd.Text;
                degisenkullanici.Soyad = txtSoyad.Text;
                degisenkullanici.EMail = txtEmail.Text;
                degisenkullanici.IkinciAd = txtIkinciAd.Text;
                degisenkullanici.Sifre = txtSifre.Text;
                degisenkullanici.TcKimlikNo = txtTcNo.Text;
                degisenkullanici.Telefon = txtTelefon.Text;
                degisenkullanici.KullaniciAd = txtKullaniciAdi.Text;
                adresi.Adres = txtTeslimAdresi.Text;
                adresi.Il = txtIl.Text;
                adresi.Ilce = txtIlce.Text;
                adresi.KullaniciID = kullaniciid;
                ent.SaveChanges();
            }
        }

        protected void lblMusteri_Click(object sender, EventArgs e)
        {

        }

        protected void gvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlYeniMusteri.Visible = true;
            int kullanicino = Convert.ToInt32(gvMusteriler.SelectedValue);
            lblMusteriNo.Text = kullanicino.ToString();
            var kullanici = ent.Kullanicilar.Where(k => k.ID == kullanicino).FirstOrDefault();
            var adresi = ent.Adresler.Where(f => f.KullaniciID == kullanicino).FirstOrDefault();
            txtAd.Text = kullanici.Ad;
            txtIkinciAd.Text = kullanici.IkinciAd;
            txtEmail.Text = kullanici.EMail;
            txtIl.Text = adresi.Il;
            txtIlce.Text = adresi.Ilce;
            txtKullaniciAdi.Text = kullanici.KullaniciAd;
            txtSifre.Text = kullanici.Sifre;
            txtSoyad.Text = kullanici.Soyad;
            txtTcNo.Text = kullanici.TcKimlikNo;
            txtTelefon.Text = kullanici.Telefon;
            txtTeslimAdresi.Text = adresi.Adres;
        }

        protected void gvMusteriler_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int kullanicino = Convert.ToInt32(gvMusteriler.SelectedValue);
            var kullanici = ent.Kullanicilar.Where(k => k.ID == kullanicino).FirstOrDefault();
            kullanici.Silindi = true;
            ent.SaveChanges();
            MusterileriGetir();
        }
    }
}