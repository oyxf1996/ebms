<%@ Page Title="" Language="C#" MasterPageFile="~/twoColumnsMain.master" AutoEventWireup="true" CodeBehind="AboutDetail.aspx.cs" Inherits="oyxf.Portal.AboutPage.AboutDetail" %>

<%@ Register Src="~/UserControl/AboutCompanyNav.ascx" TagPrefix="uc1" TagName="AboutCompanyNav" %>
<%@ Register Src="~/UserControl/FreshNews.ascx" TagPrefix="uc1" TagName="FreshNews" %>
<%@ Register Src="~/UserControl/Search.ascx" TagPrefix="uc1" TagName="Search" %>



<asp:Content ID="Content1" ContentPlaceHolderID="leftTop" runat="server">
    <uc1:AboutCompanyNav runat="server" ID="AboutCompanyNav1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftCenter" runat="server">
    <uc1:FreshNews runat="server" ID="FreshNews" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="leftBottom" runat="server">
    <uc1:Search runat="server" ID="Search" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right" runat="server">
    <%--<div class="content">
        <div class="maincontent clearfix">
            <div id="MainContent" class="maincontent clearfix">
                <p>某某有限<a href="http://www.baidu.com" target="_blank">公司致</a>力于XX业的发展，专业从事集中润滑系统的研究、开发、制造及销售，凭借公司强大的技术力量和经济实力，不断开发出具有国际先进技术水平的新产品。公司产品广泛适用于数控机械、加工中心、生产线、机床、锻压、纺织、塑料、橡胶、矿山、冶金、建筑、印刷、化工、制药、铸造、食品等各行业的机械设备及大型车辆底盘的集中润滑系统。 </p>
                <p align="center">&nbsp;<img border="0" alt="" src="/Images/Up_Images/20125212121406539828.jpg"></p>
                <p>公司总部设在xxx，在全国各大城市设有分支机构，服务网络遍及全国。公司内部实行网络化管理，依托先进的计算机辅助设计系统和计算机管理系统，实现规范化运作，在最短的时间内为用户提供高品质的产品。 </p>
                <p>公司本着技术领先、质量第一、客户至上的原则为广大用户提供满意的服务。 </p>
                <p>目前公司为国内、外超过2万家的企业提供了<a href="http://www.hitux.com/" target="_blank">网站建设</a>、域名、邮件服务、虚拟主机、网站托管服务，同时为近千家的企业设计开发了基于互联网的各类商务应用和管理软件，是国内具影响力的互联网应用服务商之一。公司将坚持客户导向、应用为本的策略，继续专注于在信息技术领域开拓发展成为企业、政府、家庭信息化的推动者和服务者。正道将秉承"和谐、参与、激情"的文化，与客户和合作伙伴齐心协力一起成长，共同发展。 </p>
                <p>公司自2000年创立以来，积极进取，不断创新，凭借良好的企业信誉，独特的经营风格及较强的市场开拓能力，取得了一个又一个的骄人业绩。数年来，xx快速稳健的发展，离不开业内极其优秀的合作伙伴。 </p>
            </div>
        </div>
    </div>--%>
    <%=base.content %>
</asp:Content>
