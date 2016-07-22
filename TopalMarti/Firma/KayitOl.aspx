<%@ Page Title="" Language="C#" MasterPageFile="~/Firma/Site1.Master" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="TopalMarti.Firma.KayitOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            float: left;
            width: 251px;
            height: 50px;
        }
        .auto-style5 {
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("ustbaslik");
        baslik.innerText = "Hesap İşlemleri";        
    </script>
    <center>
        <table style="margin-top:5px;">
            <tr>
                    <td style="text-align:left;font-size:small;width:100px">
                        Kullanıcı Adı
                    </td>
                    <td style="margin-left:15px;" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtKullaniciAdi" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtKullaniciAdi" ErrorMessage="Kullanıcı Adı boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                    <td rowspan="2" style="text-align:left;font-size:small" class="auto-style5">
                        Adres
                    </td>
                    <td rowspan="2" style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtTeslimAdresi" runat="server" Width="190px" TextMode="multiline"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTeslimAdresi" runat="server" ErrorMessage="Adres Boş Geçilecemez" ControlToValidate="txtTeslimAdresi" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        Ad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtAd" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAd" runat="server" ControlToValidate="txtAd" ErrorMessage="Ad boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
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
                        Soyad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtSoyad" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSoyad" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyad boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
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
                        Vergi No
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtTcNo" runat="server" Width="190px" Height="20px" MaxLength="10" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="Vergi No boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="10 karakter girilmelidir" ValidationExpression="\d{11}" ForeColor="Red" ValidationGroup="1">*</asp:RegularExpressionValidator>
                    </td>
                <td style="text-align:left;font-size:small">
                        Telefon
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtTelefon" runat="server" Width="190px" Height="20px" MaxLength="11" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefon" runat="server" ControlToValidate="txtTelefon" ErrorMessage="Telefon boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        Vergi Dairesi
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtVergi" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvVergiDairesi" runat="server" ErrorMessage="Vergi Dairesi Boş Geçilemez" ControlToValidate="txtVergi" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="text-align:left;font-size:small;width:100px">
                        E-Mail
                    </td>
                    <td style="margin-left:15px;" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtEmail" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-Mail boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Mail Dogru Girilmelidir" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="1">*</asp:RegularExpressionValidator>
                    </td>
                </tr>

               <tr><td colspan="2"> 

                   </td>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
                        <asp:Button ID="btnKaydet" runat="server" Text="Düzenle" CssClass="bluebutton" Width="117px" OnClick="btnKaydet_Click" style="height: 29px" ValidationGroup="1" ></asp:Button>
                    </td>
                </tr>
            <tr>
                    <td  colspan="4" style="margin-left:15px;text-align:left">
                        <asp:Label ID="lblMesaj" runat="server" Text="" ForeColor="Red" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
            </table>
        </center>
</asp:Content>

