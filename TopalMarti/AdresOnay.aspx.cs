using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class AdresOnay : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel pnlkayitol = (Panel)this.Master.FindControl("pnlkayitol");
                Panel pnlhesap = (Panel)this.Master.FindControl("pnlcikisyap");
                Panel pnlSepet = (Panel)this.Master.FindControl("pnladres");
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

                if (Session["uye"] != null)
                {
                    pnlUyeGirisi.Visible = false;
                    pnlAdres.Visible = true;

                    int degisenID = Convert.ToInt32(Session["uye"]);
                    var adres = ent.Adresler.Where(adresi => adresi.KullaniciID == degisenID).FirstOrDefault();
                    var musteri = ent.Kullanicilar.Where(kullanici => kullanici.ID == degisenID).FirstOrDefault();
                    pnlUyeGirisi.Visible = false;
                    pnlAdres.Visible = true;
                    txtTeslimAdresi.Text = adres.Adres;
                    txtIlce.Text = adres.Ilce;
                    txtIl.Text = adres.Il;
                    txtTelefon.Text = musteri.Telefon;
                    txtTeslimAdresi.Focus();
                }
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
                var adres = ent.Adresler.Where(a => a.KullaniciID == musteri.ID).FirstOrDefault();
                pnlUyeGirisi.Visible = false;
                pnlAdres.Visible = true;
                txtTeslimAdresi.Text = adres.Adres;
                txtIlce.Text = adres.Ilce;
                txtIl.Text = adres.Il;
                txtTelefon.Text = musteri.Telefon;
                txtTeslimAdresi.Focus();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
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
                    sbmesaj.Append("<a href=\"" + Request.Url.Host + "/Adres.aspx\"> Alışverişe devam etmek için tıklayınız...</a>");
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

        protected void btnAdresOnay_Click(object sender, EventArgs e)
        {
            if (txtTeslimAdresi.Text.Trim() != "")
            {
                int degisenID = Convert.ToInt32(Session["uye"]);
                var güncellekullanici = ent.Kullanicilar.Where(kullanici => kullanici.ID == degisenID).Select(k => k).FirstOrDefault();
                var güncelle = ent.Adresler.Where(kullanici => kullanici.KullaniciID == degisenID).Select(k => k).FirstOrDefault();
                güncelle.Adres = txtTeslimAdresi.Text;
                güncelle.Ilce = txtIlce.Text;
                güncelle.Il = txtIl.Text;
                güncellekullanici.Telefon = txtTelefon.Text;
                try
                {
                    ent.SaveChanges();
                    Response.Write("<script style='javascript'>alert('Adres Onaylandı')</script>");
                    DataModel.Siparisler satis = new DataModel.Siparisler();
                    satis.KullaniciID = Convert.ToInt32(Session["uye"]);
                    satis.Tarih = DateTime.Now;
                    satis.TeslimTarihi = DateTime.Now.AddDays(3);
                    satis.Tutar = ToplamTutarBul();
                    satis.Miktar = ToplamAdetBul();
                    satis.SiparisDurumu = (byte)Models.cEnum.SatisDurumu.siparis;
                    ent.Siparisler.Add(satis);
                    ent.SaveChanges();
                    //satış detayları satış no ya göre sepetten veritabanına aktarılacak.
                    DataModel.SiparisDetaylari detay = new DataModel.SiparisDetaylari();
                    //detay.SatisNo = satis.SatisNo;
                    int sonsatisno = ent.Siparisler.Where(s => s.KullaniciID == satis.KullaniciID).ToList().Last().ID;
                    DataTable dt = (DataTable)Session["sepet"];
                    foreach (DataRow urunler in dt.Rows)
                    {
                        detay.SatisID = sonsatisno;
                        detay.FirmaUrunID = Convert.ToInt32(urunler["urunID"]);
                        detay.Adet = Convert.ToInt32(urunler["adet"]);
                        detay.BirimFiyat = Convert.ToDecimal(urunler["fiyat"]);
                        detay.Tutar = Convert.ToDecimal(urunler["tutar"]);
                        ent.SiparisDetaylari.Add(detay);
                        ent.SaveChanges();
                    }
                    Response.Redirect("Odeme.aspx");
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
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
    }
}