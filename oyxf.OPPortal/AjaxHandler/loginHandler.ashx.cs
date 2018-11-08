using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using oyxf.Common;
using oyxf.Bll;
using oyxf.Model;
using oyxf.Common.AjaxResponse;

namespace oyxf.OPPortal.AjaxHandler
{
    /// <summary>
    /// loginHandler 的摘要说明
    /// </summary>
    public class loginHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request.Form["username"];
            string password = context.Request.Form["password"];
            string checkcode = context.Request.Form["checkcode"].ToUpper();
            string autologin = context.Request.Form["autologin"];

            string checkcodeSession = context.Session[Key.CAPTCHA].ToString().ToUpper();

            //1.合法性判断

            //2.验证码是否正确
            if (!checkcode.Equals(checkcodeSession))
            {
                AjaxHelper.WriteError(msg: "验证码错误");
            }

            //3.账号密码是否正确
            UserInfoBll bll = new UserInfoBll();
            oyxf.Model.UserInfo ui = bll.GetModel(username);
            if (ui == null)
            {
                AjaxHelper.WriteError(msg: "账号或密码不正确");
            }
            if (ui.Status == 0)
            {
                AjaxHelper.WriteError(msg: "该用户已被禁用");
            }

            //4.Session
            context.Session[Key.SESSION_CURRENTUSER] = ui;

            //5.Cookie
            GenerateCookie(autologin, ui);

            AjaxHelper.WriteSuccess();
        }

        #region 生成Cookie
        /// <summary>
        /// 生成Cookie
        /// </summary>
        /// <param name="autologin"></param>
        /// <param name="ui"></param>
        private void GenerateCookie(string autologin, oyxf.Model.UserInfo ui)
        {
            if (autologin == "false") return;
            HttpCookie cookie = new HttpCookie(Key.COOKIE_CURRENTUSER, CryptoHelper.TripleDES_Encrypt(ui.UserId.ToString(), Key.TRIPLEDES_KEY));
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        } 
        #endregion


        public bool IsReusable
        {
            get { return false; }
        }
    }
}