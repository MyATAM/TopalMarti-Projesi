<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="SatisIslemleri.aspx.cs" Inherits="TopalMarti.Admin.SatisIslemleri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("ustbaslik");
        baslik.innerText = "Satış İşlemleri";        
    </script>
    <asp:GridView ID="gvSatislar" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvSatislar_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Seç" ShowSelectButton="True" >
            </asp:CommandField>
            <asp:BoundField DataField="ID" HeaderText="ID">
            <ItemStyle Width="0px" />
            </asp:BoundField>
            <asp:BoundField DataField="Tarih" HeaderText="Tarih">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Miktar" HeaderText="Miktar">
            <ItemStyle Width="60px" HorizontalAlign="Center" />
            </asp:BoundField>            
            <asp:BoundField DataField="Tutar" HeaderText="Tutar">
            <ItemStyle Width="80px" HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="SiparisDurumu" HeaderText="Sipariş Durumu">
            <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="musteri" HeaderText="Müşteri">
            <ItemStyle Width="70px" HorizontalAlign="Right" />                
            </asp:BoundField>
            <asp:BoundField DataField="TeslimTarihi" HeaderText="Tahmini Teslim Tarihi">
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
    <br />
    <asp:Panel ID="pnlSiparisDetay" runat="server" Visible="false">
        <asp:GridView ID="gvSatışDetay" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="SiparisDetayID">
            <HeaderStyle Width="1px" />
            <ItemStyle Width="1px" />
            </asp:BoundField>
            <asp:BoundField DataField="UrunKodu" HeaderText="Ürün Kodu">
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="UrunAd" HeaderText="Ürün Adı">
            <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="Adet" HeaderText="Miktar">
            </asp:BoundField>
            <asp:BoundField DataField="BirimFiyat" HeaderText="Birim Fiyat">
            <ItemStyle Width="70px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Tutar" HeaderText="Tutar">
            <ItemStyle Width="80px" HorizontalAlign="Right" />
            <ItemStyle HorizontalAlign="Right" Width="80px" />
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
    </asp:Panel>
</asp:Content>
