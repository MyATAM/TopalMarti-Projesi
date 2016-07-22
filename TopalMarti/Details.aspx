<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TopalMarti.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="homebody">
        <center>
            <div id="icyapi">
                <div class="sag">
                <div style="text-align:center">      
                    <asp:DataList ID="ddlUrunDetay" runat="server" Width="1000px" OnItemCommand="ddlUrunDetay_ItemCommand" OnSelectedIndexChanged="ddlUrunDetay_SelectedIndexChanged">   
                        <ItemTemplate>
                            <div style="float:left; margin:25px">
                                <asp:Image ID="imgBuyukResim" runat="server" width="500px" Height="500px" ImageUrl='<%#Eval("UrunResimYolu2") %>' /> 
                            </div>
                            <div style="float:left;margin:25px">
                                <asp:Label ID="lblUrunAdi" runat="server" Text='<%#Eval("UrunAd") %>' Font-Size="15px"></asp:Label><br /><br />
                                <asp:Label ID="lblFiyat" runat="server" Text='<%#Eval("BirimFiyat", "{0:C}") %>' Font-Size="15px"></asp:Label><br />
                                <asp:Label ID="lblUrunBilgisi" runat="server" Text='<%#Eval("UrunBilgisi") %>'></asp:Label><br /><br /><br />
                                <asp:Label ID="lblFirma" runat="server" Text='<%#Eval("FirmaAd") %>'></asp:Label><br />
                                <asp:Label ID="lblMail" runat="server" Text='<%#Eval("FirmaMail") %>'></asp:Label><br /><br /><br />
                                <asp:TextBox ID="txtAdet" runat="server" TextMode="Number" Width="26px" Text="1" ></asp:TextBox><br /><br />
                                <asp:ImageButton ID="btnSepeteAt" ImageUrl="Model/img/btnSepeteAt.png" runat="server" CommandName="sepet" CommandArgument='<%#Eval("ID") %>' />
                            </div>                
                            </ItemTemplate>   
                    </asp:DataList>
                    <div style="text-align:left">
                        <asp:LinkButton ID="lbtnEkle" runat="server" OnClick="lbtnEkle_Click">Yorum Ekle</asp:LinkButton>
                        <asp:Panel ID="pnlyorum" runat="server" Visible="false">
                            <asp:TextBox ID="txtYorum" runat="server" Height="83px" Width="444px"></asp:TextBox>
                            <asp:Button ID="btnEkle" runat="server" Text="Ekle" Height="30px" Width="52px" OnClick="btnEkle_Click" ></asp:Button>
                        </asp:Panel>
                    </div>
                    <asp:DataList ID="ddlYorumlar" runat="server" RepeatColumns="1" Width="1000px">
                        <ItemTemplate>
                            <div style="text-align:left;color:orange;background-color:lightgray;font-size:medium">
                                <asp:Label ID="lblTarih" runat="server" Text='<%#Eval("Tarih") %>'></asp:Label>
                                <asp:Label ID="lblKullanici" runat="server" Text='<%#Eval("KullaniciAd") %>'></asp:Label>
                            </div>
                            <div style="margin-left:70px;background-color:lightgray;font-size:large;text-align:left">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Yorum") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>             
                </div>    
            </div>
            </center>
    </div>
</asp:Content>
