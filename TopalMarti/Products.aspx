<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TopalMarti.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 151px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="homebody">
            <div id="icyapi">
                <div style="float:left;margin-left:300px;width:200px">
                    
                    <div style="margin-top:15px">
                        <asp:Panel ID="pnlKategoriler" runat="server" Visible="false">
                        <asp:Menu ID="mnuKategoriler" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="14px" ForeColor="#7C6F57" StaticSubMenuIndent="10px" Width="180px">
                            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="4px" />
                            <DynamicMenuStyle BackColor="#F7F6F3" />
                            <DynamicSelectedStyle BackColor="#5D7B9D" />
                            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                            <StaticMenuItemStyle HorizontalPadding="10px" VerticalPadding="4px" />
                            <StaticSelectedStyle BackColor="#5D7B9D" />
                        </asp:Menu>
                    </asp:Panel> 
                    </div>                   
                </div>
                <div style="float:left;width:750px;margin-left:50px">
                    <asp:DataList ID="dlstUrunler" runat="server" RepeatColumns="4" Width="750px" DataKeyField="ID" OnItemCommand="dlstUrunler_ItemCommand" OnSelectedIndexChanged="dlstUrunler_SelectedIndexChanged">
                        <ItemTemplate>
                            <div style="text-align:center">
                                <asp:Label ID="lblUrunAdi" runat="server" Text='<%#Eval("UrunAd") %>'></asp:Label><br />
                                <asp:ImageButton ID="imgResim1" runat="server" ImageUrl='<%#Eval("UrunResimYolu1") %>' Width="150px" Height="200px" AlternateText='<%#Eval("UrunAd") %>' CommandName="detay" CommandArgument='<%#Eval("ID") %>' /><br />
                                <asp:Label ID="lblFiyat" runat="server" Text='<%#Eval("BirimFiyat", "{0:C}") %>'></asp:Label><br />                             
                                <asp:Label ID="lblUrunBilgisi" runat="server" Text='<%#Eval("UrunBilgisi") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                    
            </div>
    </div>
</asp:Content>
