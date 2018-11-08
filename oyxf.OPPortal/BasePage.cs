using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oyxf.Common;
using oyxf.Bll;
using oyxf.Model;

namespace oyxf.OPPortal
{
    public class BasePage : System.Web.UI.Page,System.Web.SessionState.IRequiresSessionState
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            //验证Session
            if (HttpContext.Current.Session[Key.SESSION_CURRENTUSER] == null)
            {
                //验证Cookie
                CheckCookie();
            }

        }
        
        /// <summary>
        /// 验证Cookie
        /// </summary>
        private void CheckCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[Key.COOKIE_CURRENTUSER];
            if (cookie == null)
            {
                ScriptHelper.AlertRedirect("您还未登录","/login.aspx");
                return;
            }
            if (string.IsNullOrWhiteSpace(cookie.Value))
            {
                ScriptHelper.AlertRedirect("您还未登录", "/login.aspx");
                return;
            }
            string UserIdStr = CryptoHelper.TripleDES_Decrypt(cookie.Value,Key.TRIPLEDES_KEY);
            if (!UserIdStr.IsNumber())
            {
                ScriptHelper.AlertRedirect("您还未登录", "/login.aspx");
                return;
            }
            int userid = Convert.ToInt32(UserIdStr);

            UserInfoBll bll = new UserInfoBll();
            oyxf.Model.UserInfo ui = bll.GetModel(userid);
            if (ui == null)
            {
                ScriptHelper.AlertRedirect("您还未登录", "/login.aspx");
                return;
            }
            HttpContext.Current.Session[Key.SESSION_CURRENTUSER] = ui;
            
        }
    }
}