<%@ Page Title="" Language="C#" MasterPageFile="~/twoColumnsMain.master" AutoEventWireup="true" CodeBehind="ProductsDetail.aspx.cs" Inherits="oyxf.Portal.ProductsPage.ProductsDetail" %>

<%@ Register Src="~/UserControl/CompanyProductsNav.ascx" TagPrefix="uc1" TagName="CompanyProductsNav" %>
<%@ Register Src="~/UserControl/HotProducts.ascx" TagPrefix="uc1" TagName="HotProducts" %>
<%@ Register Src="~/UserControl/Search.ascx" TagPrefix="uc1" TagName="Search" %>




<asp:Content ID="Content1" ContentPlaceHolderID="leftTop" runat="server">
    <uc1:CompanyProductsNav runat="server" ID="CompanyProductsNav" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftCenter" runat="server">
    <uc1:HotProducts runat="server" ID="HotProducts" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="leftBottom" runat="server">
    <uc1:Search runat="server" ID="Search" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right" runat="server">
    <%=base.content %>
</asp:Content>

