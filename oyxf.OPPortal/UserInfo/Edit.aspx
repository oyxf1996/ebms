<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="oyxf.OPPortal.UserInfo.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--md5加密--%>
    <script src="../js/md5.encrypt.js"></script>

    <script type="text/javascript">
        function submitUserInfo() {

            //console.log($('#ddlUserType option:selected').html());
            //console.log($('input[name="ctl00$right$rblStatus"]:checked').val());

            //ASP.NET框架生成的JS方法
            if (!Page_ClientValidate()) {
                return false;//服务端控件的数据验证没通过
            }

            var user = {
                UserId: $('#txtUserId').val(),
                Username: $('#txtUsername').val(),
                Password: '',
                RealName: $('#txtRealName').val(),
                Phone: $('#txtPhone').val(),
                UserType: $('#ddlUserType').val(),//$('#ddlUserType option:selected')
                Status: $('input[name="ctl00$right$rblStatus"]:checked').val(),
                CreateDate: $('#txtCreateDate').val(),
            };

            //console.log(user);

            if ($('#txtPassword').val() != '' && $('#txtPassword').val() != '******') {
                user.Password = hex_md5($('#txtPassword').val()).toUpperCase();
            }

            $.ajax({
                url: '/AjaxHandler/saveUserInfoHandler.ashx',
                type: 'post',
                async: true,
                data: user,
                dataType: 'json',
                success: function (obj) {
                    if (obj.status == 1) {
                        alert('操作成功');
                        location.href = "/UserInfo/List.aspx";
                    } else {
                        alert(obj.msg);
                    }
                }
            });
        }
    </script>

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
    <input type="hidden" value="" id="txtUserId" runat="server" />
    <input type="hidden" value="" id="txtCreateDate" runat="server" />
    <table class="edit">
        <tr>
            <th>用户名：</th>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" MaxLength="16" Width="180"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="*必填" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revUsername" runat="server" ErrorMessage="*由字母、数字或下划线组成，不能以数字开头，4-16位" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUsername" ValidationExpression="^[_a-zA-Z]\w{3,15}$"></asp:RegularExpressionValidator>
                <%--范围验证--%>
                <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>--%>
            </td>
        </tr>
        <tr>
            <th>密码：</th>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="16"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>真实姓名：</th>
            <td>
                <asp:TextBox ID="txtRealName" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>手机：</th>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>用户类型：</th>
            <td>
                <asp:DropDownList ID="ddlUserType" runat="server">
                    <asp:ListItem Value="1">系统管理员</asp:ListItem>
                    <asp:ListItem Value="2" Selected="True">网站管理员</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>用户状态：</th>
            <td>
                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">禁用</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <th></th>
            <td>
                <input type="button" id="btnSave" class="btn btn-success" value="保存" onclick="submitUserInfo();" />
                &nbsp;
                <input type="button" value="取消" onclick="javascript: history.back();" class="btn btn-warning" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
