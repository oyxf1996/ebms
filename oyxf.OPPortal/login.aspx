<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="oyxf.OPPortal.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/login.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/md5.encrypt.js"></script>
    <script src="js/login.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="box">
        <h1 class="fontH">管理系统</h1>
        <table id="UserInfoTable">
            <tr>
                <td class="myFont">用户名:</td>
                <td><input id="username" type="text" /></td>
            </tr>
            <tr>
                <td class="myFont">密码:</td>
                <td><input id="password" type="password" /></td>
            </tr>
            <tr>
                <td class="myFont">验证码:</td>
                <td><input id="checkcode" type="text" /><img id="img" class="imgStyle" src="Captcha/CaptchaHandler.ashx" onclick="refresh(this)"/></td>
            </tr>
            <tr>
                <td><input id="autologin" type="checkbox" /></td>
                <td class="myFont">自动登录<span id="Tip"></span></td>
            </tr>
            <tr>
                <td colspan="2"><input id="btnload" type="button" value="登录" onclick="sendAjax()" /></td> 
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
