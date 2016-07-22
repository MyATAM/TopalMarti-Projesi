using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti
{
    public partial class Uyekayit : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int kullaniciid = 0;
                kullaniciid = Convert.ToInt32(Request.QueryString["id"]);
                if(kullaniciid !=0)
                {
                    var kullanici = (from k in ent.Kullanicilar
                                     where k.ID == kullaniciid
                                     select k).FirstOrDefault();
                    var adresi = (from a in ent.Adresler
                                  where a.KullaniciID == kullaniciid
                                  select a).FirstOrDefault();

                    txtAd.Text = kullanici.Ad;
                    txtEmail.Text = kullanici.EMail;
                    txtIkinciAd.Text = kullanici.IkinciAd;
                    txtIl.Text = adresi.Il;
                    txtIlce.Text = adresi.Ilce;
                    txtKullaniciAdi.Text = kullanici.KullaniciAd;
                    txtSifre.Text = kullanici.Sifre;
                    txtSifreTekrar.Text = kullanici.Sifre;
                    txtSoyad.Text = kullanici.Soyad;
                    txtTcNo.Text = kullanici.TcKimlikNo;
                    txtTelefon.Text = kullanici.Telefon;
                    txtTeslimAdresi.Text = adresi.Adres;
                    txtGizlilik.Visible = false;
                }

                Panel pnlkayitol = (Panel)this.Master.FindControl("pnlkayitol");
                Panel pnlhesap = (Panel)this.Master.FindControl("pnlcikisyap");

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

            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cbxOkudum.Checked)
            {
                if (EmailKontrol( txtEmail.Text))
                {
                    lblMesaj.Text = "Aynı mail adresi zaten kayıtlı!";
                    txtEmail.Focus();
                }
                else if(KullanıcıAdKontrol(txtKullaniciAdi.Text))
                {
                    lblMesaj.Text = "Aynı Kullanıcı adı zaten kayıtlı!";
                    txtKullaniciAdi.Focus();
                }
                else
                {
                    DataModel.Kullanicilar kullanici = new DataModel.Kullanicilar();
                    kullanici.Ad = txtAd.Text;                    
                    kullanici.KullaniciAd = txtKullaniciAdi.Text;
                    kullanici.IkinciAd = txtIkinciAd.Text;
                    kullanici.Sifre = txtSifre.Text; // md5 şifrelenerek veritabanına atılabilir.
                    kullanici.Soyad = txtSoyad.Text;
                    kullanici.TcKimlikNo = txtTcNo.Text;
                    kullanici.Telefon = txtTelefon.Text;
                    kullanici.EMail = txtEmail.Text;
                    ent.Kullanicilar.Add(kullanici);


                    
                    try
                    {
                        ent.SaveChanges();
                        var kullaniciid = ent.Kullanicilar.Where(k => k.KullaniciAd == txtKullaniciAdi.Text).FirstOrDefault();

                        DataModel.Adresler adres = new DataModel.Adresler();
                        adres.KullaniciID = kullaniciid.ID;
                        adres.Adres = txtTeslimAdresi.Text;
                        adres.Il = txtIl.Text;
                        adres.Ilce = txtIlce.Text;
                        ent.Adresler.Add(adres);
                        ent.SaveChanges();

                        lblMesaj.Text = "üye kaydı işleminiz gerçekleştirilmiştir.";

                        SmtpClient smtp = new SmtpClient();
                        smtp.Credentials = new NetworkCredential("wissendeneme@gmail.com", "wissen123");
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com"; // mail.domain.com kullanılır
                        smtp.EnableSsl = true;
                        // smtpClient ile gönderilecek mailmessage türünden bir mail tanımlamalıyız.
                        MailMessage ePosta = new MailMessage();
                        ePosta.From = new MailAddress("wissendeneme@gmail.com");
                        ePosta.To.Add(txtEmail.Text);
                        ePosta.Subject = "Sağlık Ürünleri Şifre işlemi";
                        //ePosta.Body = "Kullanıcı Adı: " + user.KullaniciAd + "\nŞifre: " + user.Sifre;
                        StringBuilder sbmesaj = new StringBuilder();
                        sbmesaj.Append("Sayın " + txtAd.Text + " " + txtSoyad.Text + ",<br />" + "Kullanıcı Adı: " + txtKullaniciAdi.Text + "<br />" + "Şifre: " + txtSifre.Text + "<br />");
                        sbmesaj.Append("<a href=\"" + Request.Url.Host + "/Home.aspx\"> Alışverişe devam etmek için tıklayınız...</a>");
                        ePosta.Body = sbmesaj.ToString();
                        ePosta.IsBodyHtml = true;
                        try
                        {
                            smtp.Send(ePosta);
                            Response.Write("<script style='javascript'> alert('Şifre başarılı bir şekilde gönderilmiştir')</script>");
                        }
                        catch (Exception ex)
                        {
                            string hata = ex.Message;
                        }

                    }
                    catch (Exception ex)
                    {
                        string hata = ex.Message;
                    }
                }
            }
            else
            {
                lblMesaj.Text = "Gizlilik sözleşmesini okudum işaretlenmelidir.";
            }
        }

        private bool KullanıcıAdKontrol(string KullaniciAd)
        {
            var kullanici = ent.Kullanicilar.Where(k => k.KullaniciAd == KullaniciAd && k.Silindi == false).Select(k => k).FirstOrDefault();
            return Convert.ToBoolean(kullanici);
        }

        private bool EmailKontrol(string Email)
        {
            var kullanici = ent.Kullanicilar.Where(k => k.EMail == Email && k.Silindi == false).Select(k => k).FirstOrDefault();
            return Convert.ToBoolean(kullanici);
        }

        protected void cbxOkudum_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxOkudum.Checked)
            {
                lblMesaj.Text = "";
            }
        }
    }
}