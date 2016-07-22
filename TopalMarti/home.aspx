<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="TopalMarti.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="homebody">
        <center>
            <div id="icyapi">
                <div class="sol">
                <asp:Menu ID="mnuKategoriler" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="14px" ForeColor="#7C6F57" StaticSubMenuIndent="10px" Width="180px" OnMenuItemClick="mnuKategoriler_MenuItemClick">
                    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="4px" />
                    <DynamicMenuStyle BackColor="#F7F6F3" />
                    <DynamicSelectedStyle BackColor="#5D7B9D" />
                    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="10px" VerticalPadding="4px" />
                    <StaticSelectedStyle BackColor="#5D7B9D" />
                    </asp:Menu>
                </div>
                <div class="sag">

                </div>
                <div class="kampanya" >
                    <asp:DataList ID="dlstKampanyali" runat="server" RepeatColumns="4" Width="1300px" OnItemCommand="dlstKampanyali_ItemCommand" >
                        <ItemTemplate>
                            <div style="text-align:center">
                                <asp:Label ID="lblUrunAd" runat="server" Text='<%#Eval("UrunAd") %>'></asp:Label><br />
                                <asp:ImageButton ID="imgbtnUrunler" runat="server" ImageUrl='<%#Eval("UrunResimYolu1") %>' Width="150px" Height="200px" CommandName="detay" CommandArgument="ID" ></asp:ImageButton><br />
                                <asp:Label ID="lblUrunFiyat" runat="server" Text='<%#Eval("KampanyaFiyati", "{0:C}") %>'></asp:Label><br />
                                Son Tarih : 
                                <asp:Label ID="lblSonTarih" runat="server" Text='<%#Eval("BitisTarihi") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </center>
    </div>
</asp:Content>
