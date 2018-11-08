<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditContent.aspx.cs" Inherits="oyxf.OPPortal.Category.EditContent"
     ValidateRequest="false" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table.edit tr {
            height: 30px;
        }

            table.edit tr th {
                vertical-align: top;
                text-align: right;
                width:100px;
            }
            table.edit tr td {
                width:600px;
            }
    </style>
    <script src="/ueditor/ueditor.config.js"></script>
    <script src="/ueditor/ueditor.all.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <table class="edit">
        <tr>
            <th>分类名称：</th>
            <td>
                <asp:Label ID="lblCategoryName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>内容：</th>
            <td>
                <script id="container" name="ueditor" type="text/plain">
                    <%=base.Content %>
                </script>
            </td>
        </tr>
        <tr>
            <th></th>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="btn btn-success" />
                <input type="button" value="取消" onclick="javascript: history.back();" class="btn btn-warning" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script>
        var ue = UE.getEditor('container', {
            wordCount: true,
            maximumWords:10000
        });
        $('#container').width('650');
        $('#container').height('250');
    </script>
</asp:Content>
