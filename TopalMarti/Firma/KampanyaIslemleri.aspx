<%@ Page Title="" Language="C#" MasterPageFile="~/Firma/Site1.Master" AutoEventWireup="true" CodeBehind="KampanyaIslemleri.aspx.cs" Inherits="TopalMarti.Firma.KampanyaIslemleri" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 136px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <script type="text/javascript">
        var baslik = this.document.getElementById("ustbaslik");
        baslik.innerText = "Kampanya İşlemleri";        
    </script>
    <asp:GridView ID="gvUrunler" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvUrunler_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="KampanyaID">
            <ItemStyle Width="0px" />
            </asp:BoundField>
            <asp:BoundField DataField="BaslangicTarihi" HeaderText="Başlangıç Tarihi">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="BitisTarihi" HeaderText="Bitiş Tarihi">
            <ItemStyle Width="100px" />
            </asp:BoundField>            
            <asp:BoundField DataField="UrunKodu" HeaderText="Ürün Kodu">
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="UrunAd" HeaderText="Ürün Adı">
            <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="KampanyaFiyati" HeaderText="Kampanya Fiyatı">
            <ItemStyle Width="70px" HorizontalAlign="Right" />                
            </asp:BoundField>
            <asp:BoundField DataField="BirimFiyati" HeaderText="Birim Fiyatı">
            <ItemStyle Width="70px" HorizontalAlign="Right" />                
            </asp:BoundField>
            <asp:BoundField DataField="Stok" HeaderText="Stok Miktarı">
            <ItemStyle Width="60px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Aciklama" HeaderText="Açıklama">
            <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:CommandField DeleteText="Sil" ShowDeleteButton="True" >
            <ItemStyle Width="50px" />
            </asp:CommandField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <br />
    
    <div style="text-align:left">
        <asp:LinkButton ID="lbtnYenikampanya" runat="server" OnClick="lbtn_Click">Yeni Kampanya Oluştur</asp:LinkButton>
    </div>
    <asp:Panel ID="pnlekle" runat="server" Visible="false">
        <div style="width:330px;float:left; height: 200px;">
            <table style="width:329px; height: 195px;">
                <tr>
                <td style="width:130px;font-size:16px">
                    <asp:Label ID="Label11" runat="server" Text="Üst kategori Adı"></asp:Label>
                </td>                
                <td style="text-align:left" >
                    <asp:DropDownList ID="ddlUstKategoriler" runat="server" Height="16px"  Width="163px" DataTextField="UstKategoriAd" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlUstKategoriler_SelectedIndexChanged" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:110px;font-size:16px">
                    <asp:Label ID="Label4" runat="server" Text="Kategori Adı"></asp:Label>
                </td>                
                <td  colspan="2" style="text-align:left">
                    <asp:DropDownList ID="ddlKategoriler" runat="server" Height="16px" OnSelectedIndexChanged="ddlKategoriler_SelectedIndexChanged" Width="163px" DataTextField="KategoriAd" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:130px;font-size:16px">
                    <asp:Label ID="Label5" runat="server" Text="Alt kategori Adı"></asp:Label>
                </td>                
                <td style="text-align:left" >
                    <asp:DropDownList ID="ddlAltKategoriler" runat="server" Height="16px"  Width="163px" DataTextField="KategoriAd" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlAltKategoriler_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:100px;font-size:16px;">
                    <asp:Label ID="Label6" runat="server" Text="Ürün Kodu"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:DropDownList ID="ddlUrunKodları" runat="server" Height="16px"  Width="163px" DataTextField="UrunKodu" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlUrunKodları_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td style="width:100px;font-size:16px;">
                    <asp:Label ID="Label8" runat="server" Text="Ürün Adı"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:DropDownList ID="ddlUrunler" runat="server" Height="16px"  Width="163px" DataTextField="UrunAd" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlUrunler_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td style="width:100px;font-size:16px">
                    <asp:Label ID="Label9" runat="server" Text="Fiyat"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtFiyat" runat="server" Font-Size="16px" Height="18px" Width="110px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
                <tr>
                    <td style="width:100px;font-size:16px">
                        <asp:Label ID="Label10" runat="server" Text="Stok Miktarı"></asp:Label>
                </td>
                <td style="text-align:left">                    
                    <asp:TextBox ID="txtStok" runat="server" Font-Size="16px" Height="18px" Width="110px" Enabled="false"></asp:TextBox>
                </td>
                </tr>                
        </table>
        </div>
        <div style="float:left;margin-left:5px;">
            <table style="width:347px; height: 195px;">
            <tr>
                <td style="font-size:16px" class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Başlangıç Tarihi"></asp:Label>
                </td>                
                <td style="text-align:left">
                    <asp:TextBox ID="txtBaslangicTarihi" runat="server" Width="163px" Height="16px" ></asp:TextBox>
                    
                    <asp:TextBoxWatermarkExtender ID="txtBaslangicTarihi_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtBaslangicTarihi" WatermarkText="00.00.0000" WatermarkCssClass="tiklanmadi">
                    </asp:TextBoxWatermarkExtender>
                    
                </td>
            </tr>
            <tr>
                <td style="font-size:16px" class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Bitiş Tarihi"></asp:Label>
                </td>                
                <td style="text-align:left">
                    <asp:TextBox ID="txtBitisTarihi" runat="server" Width="163px" Height="16px" ></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="txtBitisTarihi_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtBitisTarihi" WatermarkText="00.00.0000" WatermarkCssClass="tiklanmadi">
                    </asp:TextBoxWatermarkExtender>
                </td>
            </tr>
                <tr >
                <td style="font-size:16px" class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Kampanya Fiyatı"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtKampanyaFiyatı" runat="server" Font-Size="16px" Height="18px" Width="110px" ></asp:TextBox>
                </td>
            </tr>
                <tr >
                <td style="font-size:16px" class="auto-style2">
                    <asp:Label ID="Label12" runat="server" Text="Kampanya Stok"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtKampanyaStok" runat="server" Font-Size="16px" Height="18px" Width="110px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-size:16px;" class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Açıklama"></asp:Label>
                </td>
                <td rowspan="2" style="text-align:left">
                    <asp:TextBox ID="txtAçıklama" runat="server" TextMode="MultiLine" Height="67px" Width="163px"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:60px">
                <td style="font-size:16px" class="auto-style2">
                </td>
            </tr>
                <tr>
                    <td style="text-align:center" class="auto-style2">
                        
                    </td>
                    <td style="text-align:right">
                        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="bluebutton" Width="114px" Enabled="False" OnClick="btnKaydet_Click" /></td>
                </tr>                
        </table>
        </div> 
        </asp:Panel>

</asp:Content>
