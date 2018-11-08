$(function () {

})

function refresh(obj) {
    var value="/Captcha/CaptchaHandler.ashx?r="+Math.random();
    $(obj).attr('src', value);
}

function sendAjax() {
    var username = $('#username').val();
    var password = hex_md5($('#password').val()).toUpperCase();
    var checkcode = $('#checkcode').val().toUpperCase();
    var autologin = $('#autologin').get(0).checked;

    //验证输入是否合法


    var postData = { "username": username, "password": password, "checkcode": checkcode, "autologin": autologin };

    //发送ajax
    $.post('/AjaxHandler/loginHandler.ashx', postData, function (data) {
        var tip = $('#Tip').get(0);
        if (data.status == 1) {
            tip.className = 'toGreen';
            location.href = "/index.aspx";

        } else {
            tip.className = 'toRed';
            refresh($('#img'));
        }
        tip.innerHTML = data.msg;
    }, 'json');

}