<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="AdresOnay.aspx.cs" Inherits="TopalMarti.AdresOnay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            float: left;
            width: 270px;
            height: 300px;
        }
        .auto-style3 {
            width: 567px;
            height: 65px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>    
        <div style="margin-left:668px">
            <asp:Panel ID="pnlUyeGirisi" runat="server" HorizontalAlign="center">
                <div style="border-style:solid;border-width:1px 1px 1px 1px" class="auto-style2">
            <br />
            <h1>Üye Girişi</h1>
            <br />
            <table>
                <tr>
                    <td style="text-align:left;width:60px">
                        E-Mail
                    </td>
                    <td style="margin-left:15px">
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtKullaniciAdi" runat="server" Width="125px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rgvKullaniciAdi" runat="server" ErrorMessage="Kullanıcı Adı Boş Geçilemez" ControlToValidate="txtKullaniciAdi" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left">
                        Şifre
                    </td>
                    <td style="margin-left:15px">
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtSifre" TextMode="password" runat="server" Width="125px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rgvSifre" runat="server" ErrorMessage="Şifre Boş Geçilemez" ControlToValidate="txtSifre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td  style="margin-left:15px;text-align:left">
                        <asp:LinkButton ID="lbtnSifremiUnuttum" runat="server" ForeColor="Black" OnClick="LinkButton1_Click" ValidationGroup="2">Şifremi Unuttum</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
                        <asp:Button ID="btnGiris" runat="server" Text="Giriş Yap" CssClass="bluebutton" Width="117px" OnClick="btnGiris_Click" ValidationGroup="1"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="margin-left:15px;text-align:right">
                        <asp:Label ID="lblMesaj" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>                
        </div>
        <div style="border-style:solid;border-width:1px 1px 1px 1px;margin-left:20px" class="auto-style2">
            <br /><h1>Üye Ol</h1>
            <br /><br /><br /><br /><br />
            
            <a href="UyeKayit.aspx" style="font-size:large;color:black">Üye Olmak İstiyorum</a>            
        </div>
                </asp:Panel>
        </div>       
        
            <div style="clear:both">
                <asp:Panel ID="pnlAdres" runat="server" Visible="false">
                <table style="margin-left:50px;margin-top:20px">
                <tr>
                    <td style="text-align:left;font-size:small">
                        Teslim Adresi
                    </td>
                    <td style="margin-left:15px">
                        &nbsp; <asp:TextBox ID="txtTeslimAdresi" runat="server" Width="200px" TextMode="multiline"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAdres" runat="server" ErrorMessage="Teslim Adresi Boş Geçilemez" ControlToValidate="txtTeslimAdresi" ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        İlçe
                    </td>
                    <td style="margin-left:15px">
                        &nbsp; <asp:TextBox ID="txtIlce" runat="server" Width="200px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIlce" runat="server" ErrorMessage="İlçe Boş Geçilemez" ControlToValidate="txtIlce" ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        İl
                    </td>
                    <td style="margin-left:15px">
                        &nbsp; <asp:TextBox ID="txtIl" runat="server" Width="200px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIl" runat="server" ErrorMessage="İl Boş Geçilemez" ControlToValidate="txtIl" ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        Telefon
                    </td>
                    <td style="margin-left:15px">
                        &nbsp; <asp:TextBox ID="txtTelefon" runat="server" Width="200px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefon" runat="server" ErrorMessage="Telefon Boş Geçilemez" ControlToValidate="txtTelefon" ForeColor="Red" ValidationGroup="3">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
               <tr>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
                        <asp:Button ID="btnAdresOnay" runat="server" Text="Adres Onay" CssClass="bluebutton" Width="117px" OnClick="btnAdresOnay_Click"></asp:Button>
                    </td>
                </tr>
            </table><br />
           </asp:Panel>
            </div>
            </center>
</asp:Content>
