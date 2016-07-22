<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uyegiris.aspx.cs" Inherits="TopalMarti.Uyegiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Topal Martı</title>
    <link href="Model/index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="body">
        <center>
            <div id="content" style="background-color:antiquewhite">
                <div class="sol" style="height:80px">
                    <div style="float:left;margin-left:30px">
                        <div style="font-size:19px;font-weight:bold;margin-top:10px;text-align:left">                            
                        Topal Martı
                        </div>
                        <div style="font-size:16px;margin-top:10px;font-weight:lighter;color:gray;text-align:left">
                        Kolay Alışveriş, Akıllı Yaşam
                        </div>
                    </div>
                </div>
            
            </div>
            <div style="width:1300px;">
                <div style="float:left;width:600px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="Model/img/marti.png" Width="600px" Height="300px"></asp:Image>
                </div>
                <div style="float:left;width:400px;margin-top:100px">
                    <table>
                <tr>
                    <td style="text-align:left;width:100px">
                        E-Mail
                    </td>
                    <td style="margin-left:15px">
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtKullaniciAdi" runat="server" Width="175px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rgvKullaniciAdi" runat="server" ErrorMessage="Kullanıcı Adı Boş Geçilemez" ControlToValidate="txtKullaniciAdi" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left">
                        Şifre
                    </td>
                    <td style="margin-left:15px">
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtSifre" TextMode="password" runat="server" Width="175px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rgvSifre" runat="server" ErrorMessage="Şifre Boş Geçilemez" ControlToValidate="txtSifre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td  style="margin-left:15px;text-align:left">
                        <asp:LinkButton ID="lbtnSifremiUnuttum" runat="server" ForeColor="Black" ValidationGroup="2" OnClick="lbtnSifremiUnuttum_Click">Şifremi Unuttum</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
                        <asp:Button ID="btnGiris" runat="server" Text="Giriş Yap" CssClass="bluebutton" Width="117px" ValidationGroup="1" OnClick="btnGiris_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="margin-left:15px;text-align:right">
                        <asp:Label ID="lblMesaj" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table> 
                </div>
            </div>
        </center>
    </div>
    </form>
</body>
</html>
