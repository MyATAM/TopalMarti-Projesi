<%@ Page Title="" Language="C#" MasterPageFile="~/Firma/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TopalMarti.Firma.Home" %>

<%@ Register Src="~/Firma/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlKullaniciGirisi" runat="server">
        <uc1:WebUserControl1 runat="server" id="WebUserControl1" />
    </asp:Panel>
</asp:Content>
