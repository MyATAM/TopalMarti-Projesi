<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="KasaIslemleri.aspx.cs" Inherits="TopalMarti.Admin.KasaIslemleri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("ustbaslik");
        baslik.innerText = "Kasa İşlemleri";        
    </script>
    
    <table>
        <tr>
            <td style="height:35px;width:400px">

            </td>
            <td style="height:35px;width:300px">
                Şirket Bazlı Kasa
            </td>
            <td style="height:35px;width:300px">
                Genel Kasa
            </td>
        </tr>
        <tr>
            <td style="height:35px;">
                Şirket seçiniz.
            </td>
            <td style="height:35px;text-align:center">
                <asp:DropDownList ID="ddlFirmalar" runat="server" AutoPostBack="true" Width="180px" OnSelectedIndexChanged="ddlFirmalar_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td style="height:35px;">

            </td>
        </tr>
        <tr style="margin-top:25px">
            <td style="height:35px;margin-top:25px">
                Toplam Alışveriş Miktarı
            </td>
            <td style="margin-top:25px">
                <asp:TextBox ID="txtFTAVMiktari" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td style="margin-top:25px">
                <asp:TextBox ID="txtTAVMiktari" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="margin-top:25px">
            <td style="height:35px;margin-top:25px">
                Toplam Alışveriş Tutarı
            </td>
            <td style="margin-top:25px">
                <asp:TextBox ID="txtFTTutar" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td style="margin-top:25px">
                <asp:TextBox ID="txtTTutar" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
    </table>

</asp:Content>
