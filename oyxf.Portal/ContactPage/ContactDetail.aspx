<%@ Page Title="" Language="C#" MasterPageFile="~/twoColumnsMain.master" AutoEventWireup="true" CodeBehind="ContactDetail.aspx.cs" Inherits="oyxf.Portal.ContactPage.ContactDetail" %>

<%@ Register Src="~/UserControl/ContactUs.ascx" TagPrefix="uc1" TagName="ContactUs" %>
<%@ Register Src="~/UserControl/FreshNews.ascx" TagPrefix="uc1" TagName="FreshNews" %>
<%@ Register Src="~/UserControl/Search.ascx" TagPrefix="uc1" TagName="Search" %>



<asp:Content ID="Content1" ContentPlaceHolderID="leftTop" runat="server">
    <uc1:ContactUs runat="server" ID="ContactUs" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftCenter" runat="server">
    <uc1:FreshNews runat="server" ID="FreshNews" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="leftBottom" runat="server">
    <uc1:Search runat="server" ID="Search" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right" runat="server">
    <%=base.content %>
</asp:Content>
