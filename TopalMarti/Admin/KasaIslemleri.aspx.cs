using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopalMarti.Admin
{
    public partial class KasaIslemleri : System.Web.UI.Page
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
                    var firmalar = ent.Firmalar.Where(f => f.Silindi == false).ToList();
                    ddlFirmalar.DataTextField = "FirmaAd";
                    ddlFirmalar.DataValueField = "ID";
                    ddlFirmalar.DataSource = firmalar;
                    ddlFirmalar.DataBind();

                    int toplammiktar = 0;
                    decimal toplamtutar = 0;
                    var siparisDetaylari = ent.SiparisDetaylari.Where(s => s.Silindi == false).ToList();
                    foreach (var siparisdetayi in siparisDetaylari )
                    {
                        toplammiktar += siparisdetayi.Adet;
                        toplamtutar += Convert.ToDecimal(siparisdetayi.Tutar);
                    }

                    txtTAVMiktari.Text = toplammiktar.ToString();
                    txtTTutar.Text = toplamtutar.ToString();
                }
            }
        }

        protected void ddlFirmalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int firmano = Convert.ToInt32(ddlFirmalar.SelectedValue);

            int toplammiktar = 0;
            decimal toplamtutar = 0;
            var siparisDetaylari = (from sd in ent.SiparisDetaylari
                                    join fu in ent.Firma_Urunler on sd.FirmaUrunID equals fu.ID
                                    where sd.Silindi == false && fu.FirmaNo == firmano
                                    select sd).ToList();
            foreach (var siparisdetayi in siparisDetaylari)
            {
                toplammiktar += siparisdetayi.Adet;
                toplamtutar += Convert.ToDecimal(siparisdetayi.Tutar);
            }

        }
    }
}