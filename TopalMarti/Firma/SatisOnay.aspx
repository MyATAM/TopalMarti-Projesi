<%@ Page Title="" Language="C#" MasterPageFile="~/Firma/Site1.Master" AutoEventWireup="true" CodeBehind="SatisOnay.aspx.cs" Inherits="TopalMarti.Firma.SatisOnay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("ustbaslik");
        baslik.innerText = "Satış Durumu";        
    </script>
    <asp:GridView ID="gvSatışDurumu" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvSatışDurumu_SelectedIndexChanged" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
            <asp:BoundField DataField="ID" HeaderText="SiparisDetayID">
            <HeaderStyle Width="1px" />
            <ItemStyle Width="1px" />
            </asp:BoundField>
            <asp:BoundField DataField="Tarih" HeaderText="Sipariş Tarihi">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="UrunKodu" HeaderText="Ürün Kodu">
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="UrunAd" HeaderText="Ürün Adı">
            <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="TeslimTarihi" HeaderText="Tahmini Teslim T.">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="SiparisDurumu" HeaderText="SiparisDurumu">
            <ItemStyle Width="100px" />
            </asp:BoundField>
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
    <br /><br />
    <asp:Button ID="btnOdemeOnay" runat="server" Text="Ödeme Onaylandı." CssClass="bluebutton" Enabled="false" OnClick="btnOdemeOnay_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="btnHazirlik" runat="server" Text="Hazırlanıyor." CssClass="bluebutton" Enabled="false" OnClick="btnHazirlik_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="btnKargo" runat="server" Text="Kargoya verildi." CssClass="bluebutton" Enabled="false" OnClick="btnKargo_Click"/>
    &nbsp;&nbsp;
    <asp:Button ID="btnTeslim" runat="server" Text="Teslim edildi." CssClass="bluebutton" Enabled="false" OnClick="btnTeslim_Click"/>
</asp:Content>
