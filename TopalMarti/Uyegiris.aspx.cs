using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TopalMarti.DataModel;

namespace TopalMarti
{
    public partial class Uyegiris : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int firmaurunid = Convert.ToInt32(Request.QueryString["firmaurunid"]);
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            var musteri = (from k in ent.Kullanicilar
                           where k.KullaniciAd == kullaniciadi && k.Sifre == sifre
                           select k).FirstOrDefault();

            if (musteri == null)
            {
                lblMesaj.Text = "Kullanıcı Adı ve Şifre Yanlış";
                txtKullaniciAdi.Focus();
            }
            else
            {
                lblMesaj.Text = "";
                Session["uye"] = musteri.ID;
                if (Session["urunid"] == null)
                    Response.Redirect("home.aspx");
                else
                    Response.Redirect("Details.aspx?firmaurunid=" + Session["urunid"]);

            }
        }

        protected void lbtnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text.Trim() != "")
            {
                DataModel.Kullanicilar user = EmailKontrol(txtKullaniciAdi.Text);
                if (user != null)
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new NetworkCredential("wissendeneme@gmail.com", "wissen123");
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; // mail.domain.com kullanılır
                    smtp.EnableSsl = true;
                    // smtpClient ile gönderilecek mailmessage türünden bir mail tanımlamalıyız.
                    MailMessage ePosta = new MailMessage();
                    ePosta.From = new MailAddress("wissendeneme@gmail.com");
                    ePosta.To.Add(user.EMail);
                    ePosta.Subject = "Sağlık Ürünleri Şifre işlemi";
                    //ePosta.Body = "Kullanıcı Adı: " + user.KullaniciAd + "\nŞifre: " + user.Sifre;
                    StringBuilder sbmesaj = new StringBuilder();
                    sbmesaj.Append("Sayın " + user.Ad + " " + user.Soyad + ",<br />" + "Kullanıcı Adı: " + user.KullaniciAd + "<br />" + "Şifre: " + user.Sifre + "<br />");
                    sbmesaj.Append("<a href=\"" + Request.Url.Host + "/UyeGiris.aspx\"> Alışverişe devam etmek için tıklayınız...</a>");
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
                else
                {
                    lblMesaj.Text = "Kullanıcı Adı kayıtlı değil";
                    txtKullaniciAdi.Focus();
                }
            }
        }

        private Kullanicilar EmailKontrol(string kullaniciad)
        {
            var kullanici = ent.Kullanicilar.Where(k => k.KullaniciAd == kullaniciad && k.Silindi == false).Select(k => k).FirstOrDefault();
            return kullanici;
        }
    }
}