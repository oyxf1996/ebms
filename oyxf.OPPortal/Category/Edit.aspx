<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="oyxf.OPPortal.Category.Edit" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table.edit {
            width: 600px;
            margin: 0 auto;
            margin-top: 100px;
        }

            table.edit th {
                text-align: right;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <table class="edit">
        <tr>
            <th>分类名称：</th>
            <td>
                <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                <%--MaxLength="16" Width="180"--%>
                <%--<asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="*必填" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revUsername" runat="server" ErrorMessage="*由字母、数字或下划线组成，不能以数字开头，4-16位" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUsername" ValidationExpression="^[_a-zA-Z]\w{3,15}$"></asp:RegularExpressionValidator>--%>
                <%--范围验证--%>
                <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>--%>
            </td>
        </tr>
        <tr>
            <th>分类类型：</th>
            <td>
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Value="1" Selected="True">链接</asp:ListItem>
                    <asp:ListItem Value="2">内容页</asp:ListItem>
                    <asp:ListItem Value="3">新闻列表</asp:ListItem>
                    <asp:ListItem Value="4">产品列表</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>父级分类：</th>
            <td>
                <asp:DropDownList ID="ddlParentId" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>状态：</th>
            <td>
                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">禁用</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th>排序：</th>
            <td>
                <asp:TextBox ID="txtSortIndex" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>URL：</th>
            <td>
                <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th></th>
            <td>
                <asp:Button ID="btnSave" class="btn btn-success" runat="server" Text="保存" OnClick="btnSave_Click" />
                <input type="button" id="btnCancel" class="btn btn-warning" value="取消" onclick="javascript: location.href = '/Category/List.aspx';" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
