<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TopalMarti.Admin.Home" %>

<%@ Register Src="~/Admin/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebUserControl2 runat="server" id="WebUserControl2" />
</asp:Content>
