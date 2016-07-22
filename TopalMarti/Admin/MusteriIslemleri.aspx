<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="MusteriIslemleri.aspx.cs" Inherits="TopalMarti.Admin.MusteriIslemleri" %>
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
        baslik.innerText = "Müşteri İşlemleri";        
    </script>
    <asp:GridView ID="gvMusteriler" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID"  Width="900px" OnRowDeleting="gvMusteriler_RowDeleting" OnSelectedIndexChanged="gvMusteriler_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="KullaniciAd" HeaderText="Kullanıcı Adı" />
            <asp:BoundField DataField="Sifre" HeaderText="Şifre" />
            <asp:BoundField DataField="Ad" HeaderText="Müşteri Adı" />
            <asp:BoundField DataField="IkinciAd" HeaderText="İkinci Ad" />
            <asp:BoundField DataField="Soyad" HeaderText="Soyad" />
            <asp:BoundField DataField="TcKimlikNo" HeaderText="Tc Kimlik No" />
            <asp:BoundField DataField="Telefon" HeaderText="Telefon" />
            <asp:BoundField DataField="EMail" HeaderText="Mail" />
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
        <table>
            <tr>
                <td>
                    Toplam Alışveriş Miktarı : 
                </td>
                <td style="width:200px;height:30px">
                    <asp:TextBox ID="txtAlisverisMiktari" runat="server" Enabled="false" Height="16px" Width="136px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Toplam Tutar : 
                </td>
                <td style="width:200px;height:30px"">
                    <asp:TextBox ID="txtToplamTutar" runat="server" Enabled="false" Height="16px" Width="136px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align:left">
        <asp:LinkButton ID="lblMusteri" runat="server" OnClick="lblMusteri_Click" >Yeni Müşteri Ekle</asp:LinkButton>
    </div>
    <br />
    <asp:Panel ID="pnlYeniMusteri" runat="server" Visible="false">
        <table style="margin-top:5px;">
            <tr>
                <td style="text-align:left;font-size:small;width:100px">Kullanıcı Adı </td>
                <td class="auto-style3" style="margin-left:15px;">&nbsp;
                    <asp:TextBox ID="txtKullaniciAdi" runat="server" Height="20px" Width="190px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtKullaniciAdi" ErrorMessage="Kullanıcı Adı boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                
                <td class="auto-style5" style="text-align:left;font-size:small">Adres 
                    <asp:Label ID="lblMusteriNo" runat="server" Text="0" Visible="false"></asp:Label>
                </td>
                <td rowspan="2" class="auto-style3" style="margin-left:15px">&nbsp;
                    <asp:TextBox ID="txtTeslimAdresi" runat="server" TextMode="multiline" Width="199px" Height="58px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTeslimAdresi" runat="server" ControlToValidate="txtTeslimAdresi" ErrorMessage="Adres Boş Geçilecemez" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td style="text-align:left;font-size:small">
                        Şifre</td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtSifre" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifre boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Ad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtAd" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAd" ErrorMessage="Ad boş geçilemez!" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
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
                        İkinci Ad
                    </td>
                    <td style="margin-left:15px" class="auto-style3">
                        &nbsp; <asp:TextBox ID="txtIkinciAd" runat="server" Width="190px" Height="20px" ></asp:TextBox>
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
                        Tc Kimlik No
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

               <tr><td colspan="2" style="text-align:left;font-size:small">
                        
                    </td>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
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
