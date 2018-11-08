<%@ Page Title="" Language="C#" MasterPageFile="~/twoColumnsMain.master" AutoEventWireup="true" CodeBehind="ProductsContent.aspx.cs" Inherits="oyxf.Portal.ProductsPage.ProductsContent" %>

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
    <div class="content">
        <div class="ProInfo">
            <%=base.proInfo %>
            <div class="clearfix"></div>
        </div>

        <div class="maincontent clearfix">
            <div class="IntroTitle">产品介绍</div>
            <%=base.content %>
        </div>

        <div class="IntroTitle">更多产品</div>

        <div class="MorePro">
            <%=base.morePro %>
        </div>

    </div>
</asp:Content>



