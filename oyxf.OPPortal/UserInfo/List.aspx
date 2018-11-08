<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="oyxf.OPPortal.UserInfo.List" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <asp:Label ID="lblUserId" runat="server" Text="用户编号："></asp:Label>
    <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="lblUserName" runat="server" Text="用户名："></asp:Label>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblRealName" runat="server" Text="真实姓名："></asp:Label>
    <asp:TextBox ID="txtRealName" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="lblPhone" runat="server" Text="手机号："></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblUserType" runat="server" Text="用户类型："></asp:Label>
    <asp:DropDownList ID="ddlUserType" runat="server">
        <asp:ListItem Value="">未选择</asp:ListItem>
        <asp:ListItem Value="1">超级管理员</asp:ListItem>
        <asp:ListItem Value="2">网站管理员</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Label ID="lblStatus" runat="server" Text="状态："></asp:Label>
    <asp:DropDownList ID="ddlStatus" runat="server">
        <asp:ListItem Value="">未选择</asp:ListItem>
        <asp:ListItem Value="0">禁用</asp:ListItem>
        <asp:ListItem Value="1">启用</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblCreateDate" runat="server" Text="创建时间："></asp:Label>
    <asp:TextBox ID="txtCreateDateStart" runat="server"></asp:TextBox>到
    <asp:TextBox ID="txtCreateDateEnd" runat="server"></asp:TextBox>
    <asp:Button ID="btnSerach" runat="server" Text="搜索" />
    <asp:Button ID="btnClear" runat="server" Text="重置" />
    <br />

    <asp:Button ID="btnAddUser" runat="server" Text="添加用户" CssClass="btnAdd" OnClick="btnAddUser_Click" />
    <table class=" table-condensed">
        <tr>
            <th>用户编号</th>
            <th>用户名</th>
            <th>真实姓名</th>
            <th>手机</th>
            <th>用户类型</th>
            <th>状态</th>
            <th>创建时间</th>
            <th>操作</th>
        </tr>
        <asp:Repeater ID="repUserInfo" runat="server" OnItemDataBound="repUserInfo_ItemDataBound" OnItemCommand="repUserInfo_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("UserId") %></td>
                    <td><%#Eval("Username") %></td>
                    <td><%#Eval("RealName") %></td>
                    <td><%#Eval("Phone") %></td>
                    <td>
                        <asp:Label ID="lblUserType" runat="server" Text='<%#Eval("UserType") %>'></asp:Label>
                    </td>

                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </td>
                    <td><%#Eval("CreateDate") %></td>
                    <td>
                        <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%#"/UserInfo/Edit.aspx?id="+Eval("UserId") %>'>编辑</asp:HyperLink>
                        <asp:LinkButton ID="lbtn" runat="server" CommandName="del" CommandArgument='<%#Eval("UserId") %>' OnClientClick='return confirm("确认要删除吗？")'>删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>


    <webdiyer:AspNetPager ID="anpUserInfo" PageSize="10" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" OnPageChanging="anpUserInfo_PageChanging" runat="server"></webdiyer:AspNetPager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
