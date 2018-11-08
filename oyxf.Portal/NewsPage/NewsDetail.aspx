<%@ Page Title="" Language="C#" MasterPageFile="~/twoColumnsMain.master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="oyxf.Portal.NewsPage.NewsDetail" %>

<%@ Register Src="~/UserControl/FreshNews.ascx" TagPrefix="uc1" TagName="FreshNews" %>
<%@ Register Src="~/UserControl/Search.ascx" TagPrefix="uc1" TagName="Search" %>
<%@ Register Src="~/UserControl/NewsNav.ascx" TagPrefix="uc1" TagName="NewsNav" %>



<asp:Content ID="Content1" ContentPlaceHolderID="leftTop" runat="server">
    <%-- 新闻动态nav --%>
    <uc1:NewsNav runat="server" ID="NewsNav" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftCenter" runat="server">
    <%-- 最新资讯 --%>
    <uc1:FreshNews runat="server" ID="FreshNews" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="leftBottom" runat="server">
    <%-- 搜索栏 --%>
    <uc1:Search runat="server" ID="Search" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right" runat="server">
    <%=base.content %>
    
</asp:Content>
