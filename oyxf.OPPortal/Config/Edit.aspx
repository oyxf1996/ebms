<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="oyxf.OPPortal.Config.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">

            table.edit tr {
                height: 30px;
            }

                table.edit tr th {
                    vertical-align: top;
                    text-align: right;
                }

        .tip {
            font-size: 14px;
        }

        #imgAboutImgUrl, #imgContactImgUrl {
            border: 1px gray dashed;
        }
    </style>

    <script type="text/javascript">
        /*验证图片
        obj 上传控件
        imgMaxSize 限制大小 单位:MB
        */
        function checkImage(obj, imgMaxSize) {
            //console.log($(obj).get(0));
            //console.log($(obj).get(0).files);
            //console.log($(obj).get(0).files[0]);//文件对象

            var img = $(obj).get(0).files[0];//文件对象
            //是否选择图片
            if (typeof (img) == 'undefined') {
                alert('请选择图片');
                return false;
            }

            //图片格式
            var imgName = img.name;//文件名
            var extension = imgName.substr(imgName.lastIndexOf('.')).toLowerCase(); //扩展名 转成小写
            //console.log(extension);
            var flag = false;
            var arrFormat = ['.jpg', '.jpeg', '.gif', '.png', '.bmp'];
            for (var i = 0; i < arrFormat.length; i++) {
                if (arrFormat[i] == extension) {
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                alert('图片格式不正确');
                return flag;//return false
            }

            //文件大小            
            var imgSize = img.size;//文件大小 单位：字节Byte
            if (imgSize > imgMaxSize * 1024 * 1024) {
                alert('图片大小超过限制');
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <%--隐藏域保存ConfigId--%>
    <input type="hidden" value="" runat="server" id="txtConfigId" />
    <table class="edit">
        <tr>
            <th>版权信息：</th>
            <td>
                <asp:TextBox ID="txtCopyright" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>首页关于公司图片：</th>
            <td>
                <asp:FileUpload ID="fuAboutImgUrl" runat="server" />
                <asp:Image ID="imgAboutImgUrl" runat="server" ImageUrl="" Width="220" Height="100" />
                <br />
                <span class="tip">尺寸：220*100 大小：小于1MB 格式：jpg、jpeg、gif、png、bmp</span>
                <asp:TextBox ID="txtAboutImgUrl" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btnAboutImgUrl" runat="server" Text="上传" OnClick="btnAboutImgUrl_Click" OnClientClick="return checkImage($('#fuAboutImgUrl'),1);" />
                <asp:RequiredFieldValidator ID="rfvAboutImgUrl" runat="server" ErrorMessage="*请上传图片" ControlToValidate="txtAboutImgUrl" ForeColor="Red" ValidationGroup="vgConfig"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>首页关于公司简介：</th>
            <td>
                <asp:TextBox ID="txtAboutIntro" runat="server" Text="" TextMode="MultiLine" Width="400" Height="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>首页关于公司链接：</th>
            <td>
                <asp:TextBox ID="txtAboutUrl" runat="server" Width="400"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>首页新闻动态链接：</th>
            <td>
                <asp:TextBox ID="txtNewsUrl" runat="server" Width="400"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>首页联系方式图片：</th>
            <td>
                <asp:FileUpload ID="fuContactImgUrl" runat="server" />
                <asp:Image ID="imgContactImgUrl" runat="server" Width="250" Height="100" ImageUrl="" />
                <br />
                <span class="tip">尺寸：250*100 大小：小于1MB 格式：jpg、jpeg、gif、png、bmp</span>
                <asp:TextBox ID="txtContactImgUrl" name="txtContactImgUrl" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btnContactImgUrl" runat="server" Text="上传" OnClick="btnContactImgUrl_Click" OnClientClick="return checkImage($('#fuContactImgUrl'),1);" />
                <asp:RequiredFieldValidator ID="rfvContactImgUrl" runat="server" ErrorMessage="*请上传图片"
                    ControlToValidate="txtContactImgUrl" ForeColor="Red" Display="Dynamic" ValidationGroup="vgConfig"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th>首页联系方式链接：</th>
            <td>
                <asp:TextBox ID="txtContactUrl" runat="server" Width="400"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>公司名称：</th>
            <td>
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>公司地址：</th>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>邮编：</th>
            <td>
                <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>联系电话：</th>
            <td>
                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>官网地址：</th>
            <td>
                <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>Email：</th>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>首页公司产品链接：</th>
            <td>
                <asp:TextBox ID="txtProductUrl" runat="server" Width="400"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th></th>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" ValidationGroup="vgConfig" CssClass="btn btn-success" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClientClick="javascript:history.back();" CssClass="btn btn-warning" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
