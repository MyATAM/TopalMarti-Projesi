<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="FirmaEkle.aspx.cs" Inherits="TopalMarti.Admin.FirmaEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            float: left;
            width: 251px;
            height: 50px;
            text-align:left;
        }
        .auto-style5 {
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("ustbaslik");
        baslik.innerText = "Firma İşlemleri";
    </script>
    <div style="text-align:left">
        Onay Durumu : <asp:DropDownList ID="ddlOnayDurumu" runat="server" Height="20px" Width="205px" AutoPostBack="True">
            <asp:ListItem Value="1">Onaylanmış</asp:ListItem>
            <asp:ListItem Value="0">Onay Bekleyen</asp:ListItem>
        </asp:DropDownList>

    </div>
    <br />
    <asp:GridView ID="gvFirmalar" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnRowDeleting="gvFirmalar_RowDeleting" OnSelectedIndexChanged="gvFirmalar_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="FirmaAd" HeaderText="Firma" />
            <asp:BoundField DataField="KullaniciAd" HeaderText="Kullanıcı Adı" />
            <asp:BoundField DataField="Sifre" HeaderText="Şifre" />
            <asp:BoundField DataField="YetkiliAd" HeaderText="Yetkili Adı" />
            <asp:BoundField DataField="YetkiliSoyad" HeaderText="Soyadı" />
            <asp:BoundField DataField="Telefon" HeaderText="Telefon" />
            <asp:BoundField DataField="FirmaMail" HeaderText="Mail" />
            <asp:BoundField DataField="VergiNo" HeaderText="Vergi No" />
            <asp:BoundField DataField="VergiDairesi" HeaderText="Vergi Dairesi" />
            <asp:CommandField DeleteText="Sil" ShowDeleteButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <div style="text-align:left">
        <asp:LinkButton ID="lbtnFirmaEkle" runat="server" OnClick="lbtnFirmaEkle_Click">Yeni Firma Ekle</asp:LinkButton>
    </div>
    <br />
    <asp:Panel ID="pnlYeniFirmaEkle" runat="server" Visible="false">
        <table style="margin-top:5px;">
            <tr>
                <td style="text-align:left;font-size:small;width:100px">Firma Adı <asp:Label ID="lblfirmano" runat="server" Text="0" Visible="false"></asp:Label> </td>
                <td class="auto-style3" style="margin-left:15px;">&nbsp;
                    <asp:TextBox ID="txtFirmaAdi" runat="server" Height="20px" Width="190px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirmaAdı" runat="server" ControlToValidate="txtFirmaAdi" ErrorMessage="Firma Adı boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                
                <td class="auto-style5" style="text-align:left;font-size:small">Adres </td>
                <td rowspan="2" class="auto-style3" style="margin-left:15px">&nbsp;
                    <asp:TextBox ID="txtTeslimAdresi" runat="server" TextMode="multiline" Width="199px" Height="58px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTeslimAdresi" runat="server" ControlToValidate="txtTeslimAdresi" ErrorMessage="Adres Boş Geçilecemez" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td style="text-align:left;font-size:small;width:100px">Kullanıcı Adı </td>
                <td class="auto-style3" style="margin-left:15px;">&nbsp;
                    <asp:TextBox ID="txtKullaniciAdi" runat="server" Height="20px" Width="190px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtKullaniciAdi" ErrorMessage="Kullanıcı Adı boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Şifre</td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtSifre" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvfSifre" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifre boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
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
                        Ad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtAd" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAd" runat="server" ControlToValidate="txtAd" ErrorMessage="Ad boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
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
                        Soyad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtSoyad" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSoyad" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyad boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
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
                        Vergi No
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtTcNo" runat="server" Width="190px" Height="20px" MaxLength="10" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="Vergi No boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="10 karakter girilmelidir" ValidationExpression="\d{11}" ForeColor="Red" ValidationGroup="1">*</asp:RegularExpressionValidator>
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

               <tr><td style="text-align:left;font-size:small">
                        Vergi Dairesi
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtVergi" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvVergiDairesi" runat="server" ErrorMessage="Vergi Dairesi Boş Geçilemez" ControlToValidate="txtVergi" ValidationGroup="1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
                        <asp:Button ID="btnOnayla" runat="server" Text="Onayla" CssClass="bluebutton" Width="117px" style="height: 29px" OnClick="btnOnayla_Click"></asp:Button>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="bluebutton" Width="117px" OnClick="btnKaydet_Click" style="height: 29px" ValidationGroup="1" ></asp:Button>
                    </td>
                </tr>
            <tr>
                    <td  colspan="4" style="margin-left:15px;text-align:left">
                        <asp:Label ID="lblMesaj" runat="server" Text="" ForeColor="Red" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
            </table>
    </asp:Panel>
</asp:Content>
