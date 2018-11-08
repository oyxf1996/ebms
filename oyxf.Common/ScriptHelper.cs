using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace oyxf.Common
{
    /// <summary>
    /// JS脚本帮助类
    /// </summary>
    public class ScriptHelper
    {
        /// <summary>
        /// Alert弹窗
        /// </summary>
        /// <param name="msg"></param>
        public static void Alert(string msg)
        {
            string script = string.Format("alert('{0}');", msg);
            RegisterScript(script);
        }

        /// <summary>
        /// Alert弹窗，并跳转
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void AlertRedirect(string msg, string url)
        {
            string script = string.Format("alert('{0}');location.href='{1}';", msg, url);
            RegisterScript(script);
        }

        /// <summary>
        /// Alert弹窗，并刷新当前页面
        /// </summary>
        /// <param name="msg"></param>
        public static void AlertRefresh(string msg)
        {
            string script = string.Format("alert('{0}');location.href=location.href;", msg);
            RegisterScript(script);
        }

        /// <summary>
        /// 浏览器回退
        /// </summary>
        public static void GoBack(int count)
        {
            string script = "history.go(-" + count + ");";
            RegisterScript(script);
        }

        private static void RegisterScript(string script)
        {
            Page currentPage = (Page)HttpContext.Current.Handler;
            if (currentPage != null)
            {
                //RegisterClientScriptBlock     //页面还未加载前执行   页面元素还未生成、页面上的js脚本还未加载
                //RegisterStartupScript         //页面加载完毕后执行  script放在</body>标签前
                currentPage.ClientScript.RegisterClientScriptBlock(currentPage.GetType(), Guid.NewGuid().ToString(), script, true);
            }
            else
            {
                HttpContext.Current.Response.Write("<script>" + script + "</script>");
                HttpContext.Current.Response.End();
            }

        }
    }
}
