<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Uyekayit.aspx.cs" Inherits="TopalMarti.Uyekayit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            float: left;
            width: 251px;
            height: 50px;
        }
        .auto-style4 {
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float:left;width:350px;margin-left:620px">
        <table style="margin-top:5px;">
            <tr>
                    <td style="text-align:left;font-size:small;width:100px">
                        Kullanıcı Adı
                    </td>
                    <td style="margin-left:15px;" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtKullaniciAdi" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtKullaniciAdi" ErrorMessage="Kullanıcı Adı boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Şifre</td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtSifre" runat="server" Width="190px" Height="20px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvfSifre" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifre boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Şifre Tekrar
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtSifreTekrar" runat="server" Width="190px" Height="20px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSifreTekrar" runat="server" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifre boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvRePassword" runat="server" ControlToCompare="txtSifre" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifre eşleşmiyor!" ForeColor="Red" ValidationGroup="1">*</asp:CompareValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Ad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtAd" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAd" runat="server" ControlToValidate="txtAd" ErrorMessage="Ad boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        İkinci Ad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtIkinciAd" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Soyad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtSoyad" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSoyad" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyad boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        TC Kimlik No
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtTcNo" runat="server" Width="190px" Height="20px" MaxLength="11" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="TC Kimlik No boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="11 karakter girilmelidir" ValidationExpression="\d{11}" ForeColor="Red" ValidationGroup="1">*</asp:RegularExpressionValidator>
                    </td>
                
                </tr>

                <tr>
                    <td style="text-align:left;font-size:small">
                        Adres
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtTeslimAdresi" runat="server" Width="190px" TextMode="multiline"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTeslimAdresi" runat="server" ErrorMessage="Adres Boş Geçilecemez" ControlToValidate="txtTeslimAdresi" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        İlçe
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtIlce" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIlce" runat="server" ErrorMessage="İlçe Boş Geçilemez" ControlToValidate="txtIlce" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        İl
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtIl" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIl" runat="server" ErrorMessage="İl Boş Geçilemez" ControlToValidate="txtIl" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        Telefon
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtTelefon" runat="server" Width="190px" Height="20px" MaxLength="11" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefon" runat="server" ControlToValidate="txtTelefon" ErrorMessage="Telefon boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small;width:100px">
                        E-Mail
                    </td>
                    <td style="margin-left:15px;" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtEmail" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-Mail boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Mail Dogru Girilmelidir" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="1">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
            <tr>
                <td></td>
                    <td  style="margin-left:15px;text-align:left" class="auto-style4">
                        &nbsp;<asp:CheckBox ID="cbxOkudum" runat="server" Text="Gizlilik Sözleşmesini Okudum" Font-Size="15px" OnCheckedChanged="cbxOkudum_CheckedChanged" />
                    </td>
                </tr>
               <tr>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
                        <asp:Button ID="btnKaydet" runat="server" Text="Kayıt Ol" CssClass="bluebutton" Width="117px" OnClick="btnKaydet_Click" style="height: 29px" ValidationGroup="1" ></asp:Button>
                    </td>
                </tr>
            <tr>
                    <td  colspan="2" style="margin-left:15px;text-align:left">
                        <asp:Label ID="lblMesaj" runat="server" Text="" ForeColor="Red" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
    <div style="float:left;width:150px;margin-left:20px;">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <br /><br /><br /><br />
        <asp:TextBox ID="txtGizlilik" runat="server" Width="141px" TextMode="MultiLine" Height="170px" Font-Size="12px" Enabled="false" Text="Gizlilik Sözleşmesi : Girmiş olduğunuz kişisel bilgileriniz, 3. Şahıs ve kurumlarla kesinlikle paylaşılmayacaktır. Her türlü özel bilgi ve ödeme işlemleriniz 128 bit SSL güvenlik sertifikalarıyla şifrelenmektedir."></asp:TextBox>
    </div>
</asp:Content>
