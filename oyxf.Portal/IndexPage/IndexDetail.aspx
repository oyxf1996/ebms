<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="IndexDetail.aspx.cs" Inherits="oyxf.Portal.IndexPage.IndexDetail" ClientIDMode="Static" %>

<%@ Register Src="~/UserControl/AboutCompany.ascx" TagPrefix="uc1" TagName="AboutCompany" %>
<%@ Register Src="~/UserControl/News.ascx" TagPrefix="uc1" TagName="News" %>
<%@ Register Src="~/UserControl/Contact.ascx" TagPrefix="uc1" TagName="Contact" %>
<%@ Register Src="~/UserControl/CompanyProducts.ascx" TagPrefix="uc1" TagName="CompanyProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptStyle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="Focus">
        <ul>
            <%-- 轮播图 --%>
            <%=base.turnPic %>
        </ul>
    </div>

    <div class="HeightTab clearfix"></div>

    <div class="MainBlock">
        <!--left start-->
        <div class="right">
            <%-- 关于公司 --%>
            <uc1:AboutCompany runat="server" ID="AboutCompany" />
            <div class=" clearfix"></div>
        </div>
        <!--left end-->
        <div class="WidthTab"></div>
        <!--right start-->
        <div class="left">
            <%-- 新闻动态 --%>
            <uc1:News runat="server" ID="News" />
        </div>
        <!--right end-->
        <!--right2 start-->
        <div class="right2">
            <%-- 联系方式 --%>
            <uc1:Contact runat="server" ID="Contact" />
        </div>
        <!--right2 end-->
    </div>

    <div class="HeightTab clearfix"></div>

    <div class="ProductShow">
        <%-- 公司产品 --%>
        <uc1:CompanyProducts runat="server" ID="CompanyProducts" />
    </div>

    <div class="HeightTab clearfix"></div>

    <div id="Links">
        <%-- 友情链接 --%>
        <%=base.friendlyLink %>
    </div>
</asp:Content>
