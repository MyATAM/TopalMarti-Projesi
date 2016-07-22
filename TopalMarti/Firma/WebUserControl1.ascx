<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="TopalMarti.Firma.WebUserControl1" %>
<link href="../Model/index.css" rel="stylesheet" />
<style type="text/css">
    .auto-style1 {
        width: 160px;
    }
</style>
<div>
    <table style="width: 391px;margin-top:20px">
        <tr>
                    <td>
                    </td>
                    <td style="margin-left:15px;font-size:18px;font-weight:bold">
                        <asp:Label ID="Label3" runat="server" Text="Admin Giriş"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:17px" class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td style="margin-left:15px">
                        <asp:TextBox ID="txtKullaniciAdi" runat="server" Width="179px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rgvKullaniciAdi" runat="server" ErrorMessage="Kullanıcı Adı Boş Geçilemez" ControlToValidate="txtKullaniciAdi" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:17px" class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Şifre"></asp:Label>
                    </td>
                    <td style="margin-left:15px">
                        <asp:TextBox ID="txtSifre" TextMode="password" runat="server" Width="179px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rgvSifre" runat="server" ErrorMessage="Şifre Boş Geçilemez" ControlToValidate="txtSifre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td style="margin-left:15px;text-align:left">
                        <asp:Button ID="btnGiris" runat="server" Text="Giriş Yap" CssClass="bluebutton" Width="123px" ValidationGroup="1" Height="29px" OnClick="btnGiris_Click" ></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="margin-left:15px;text-align:right">
                        <asp:Label ID="lblMesaj" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="margin-left:15px;text-align:right">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </td>
                </tr>
            </table>                
</div>

