using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti
{
    public partial class index : System.Web.UI.MasterPage
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var ustkategori = (from u in ent.UstKategoriler
                                   where u.Silindi == false
                                   select u).ToList();
                ddlKategoriler.DataSource = ustkategori;
                ddlKategoriler.DataTextField = "UstKategoriAd";
                ddlKategoriler.DataValueField = "ID";
                ddlKategoriler.DataBind();
            }
        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ustkategorino = Convert.ToInt32(ddlKategoriler.SelectedValue);
            Response.Redirect("Products.aspx?ukno=" + ustkategorino);

        }
        
        protected void imgbtnArama_Click(object sender, ImageClickEventArgs e)
        {
            if (txtGenisArama.Text.Trim() != null)
            {
                string urunad = txtGenisArama.Text;
                var urun = (from fu in ent.Firma_Urunler
                            join u in ent.Urunler on fu.UrunID equals u.UrunID
                            where u.UrunAd.Contains(urunad) && u.Silindi == false
                            select fu).ToList();
                if(urun != null)
                {
                    int id = Convert.ToInt32("UrunID");
                    Response.Redirect("Product.aspx?urunid=" + id);
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Bir hata oluştu.')</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bir hata ile oluştu.')</script>");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void imgbtnKayitOl_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Uyekayit.aspx");
        }

        protected void imgbtnGirisYap_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Uyegiris.aspx");
        }

        protected void imgbtnHesabim_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Uyekayit.aspx?id=" + Session["uye"]);
        }

        protected void imbntnCikisYap_Click(object sender, ImageClickEventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Home.aspx");
        }

        protected void imgbtnSepet_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Sepet.aspx");
        }
    }
}