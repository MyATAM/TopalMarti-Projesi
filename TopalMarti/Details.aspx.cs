using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti
{
    public partial class Details : System.Web.UI.Page
    {
        DataModel.TopalMartiEntities2 ent = new DataModel.TopalMartiEntities2();
        Models.cSepet spt = new Models.cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Panel pnlkayitol = (Panel)this.Master.FindControl("pnlkayitol");
                Panel pnlhesap = (Panel)this.Master.FindControl("pnlcikisyap");
                Panel pnlGenisArama = (Panel)this.Master.FindControl("pblArama");
                pnlGenisArama.Visible = true;

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

                int firmaurunid = Convert.ToInt32(Request.QueryString["firmaurunid"]);
                Session["urunid"] = firmaurunid;

                var urun = (from fu in ent.Firma_Urunler
                            join f in ent.Firmalar on fu.FirmaNo equals f.ID
                            join u in ent.Urunler on fu.UrunID equals u.UrunID
                            where fu.ID == firmaurunid
                            select new
                            {
                                fu.ID,
                                fu.BirimFiyat,
                                fu.UrunBilgisi,
                                fu.Stok,
                                fu.UrunResimYolu2,
                                f.FirmaAd,
                                f.FirmaMail,
                                u.UrunAd,
                                u.UrunKodu
                            }).ToList();
                ddlUrunDetay.DataSource = urun;
                ddlUrunDetay.DataBind();

                var yorum = (from y in ent.Yorumlar
                             join fu in ent.Firma_Urunler on y.FirmaUrunID equals fu.ID
                             join k in ent.Kullanicilar on y.KullaniciID equals k.ID
                             where y.Silindi == false && y.FirmaUrunID==firmaurunid
                             select new
                             {
                                 y.Yorum,
                                 k.KullaniciAd,
                                 y.Tarih,
                                 y.FirmaUrunID,
                                 y.ID
                             }).ToList();


            }

        }
        protected void ddlUrunDetay_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName=="sepet")
            {
                if (Session["sepet"] == null)
                {
                    Session["sepet"] = spt.YeniSepet();
                }
                DataTable dt = (DataTable)Session["sepet"];
                DataRow dr;
                int id = Convert.ToInt32(e.CommandArgument);
                Label lblUrunAdi = (Label)e.Item.FindControl("lblUrunAdi");
                Label lblFiyat = (Label)e.Item.FindControl("lblFiyat");
                string[] fiyat = lblFiyat.Text.Split(' ');
                lblFiyat.Text = fiyat[0];
                TextBox txtAdet = (TextBox)e.Item.FindControl("txtAdet");
                bool Varmi = false;
                foreach (DataRow drow in dt.Rows)
                {
                    if (drow["urunID"].ToString() == id.ToString())
                    {
                        Varmi = true;
                        drow["adet"] = Convert.ToInt32(drow["adet"]) + Convert.ToInt32(txtAdet.Text);
                        drow["tutar"] = Convert.ToDecimal(drow["tutar"]) + Convert.ToInt32(txtAdet.Text) * Convert.ToDecimal(lblFiyat.Text);
                        break;
                    }
                }
                if (!Varmi)
                {
                    dr = dt.NewRow();

                    dr["urunID"] = id;
                    dr["urunAd"] = lblUrunAdi.Text;
                    dr["adet"] = Convert.ToInt32(txtAdet.Text);
                    dr["fiyat"] = Convert.ToDecimal(lblFiyat.Text);
                    dr["tutar"] = Convert.ToDecimal(dr["fiyat"]) * Convert.ToInt32(dr["adet"]);
                    dt.Rows.Add(dr);
                }

                Session["sepet"] = dt;
            }
        }

        protected void lbtnEkle_Click(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                pnlyorum.Visible = true;
            }
            else
            {
                string firmaurunid = Session["urunid"].ToString();
                Response.Redirect("Uyegiris.aspx?firmaurunid=" + firmaurunid);
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {

        }

        protected void ddlUrunDetay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}