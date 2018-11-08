using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using oyxf.Bll;
using oyxf.Model;
using log4net;
using oyxf.Common;

namespace oyxf.Portal
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //读取log4net配置信息
            log4net.Config.XmlConfigurator.Configure();
            //ILog log = LogManager.GetLogger("Application_Start");
            //log.Info("网站启动了哈！！");
            ExceptionHelper.HandleException();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            string pageindex = Request.QueryString["pageindex"];//需要分页的页面，可以传入该参数

            //去除url中的参数
            if (url.Contains('?'))
            {
                url = url.Substring(0,url.IndexOf('?'));
            }
            //正则匹配Url重写的路径
            RegexExecute(url, pageindex);

        }
        #region 正则匹配Url重写的路径
        /// <summary>
        /// 正则匹配Url重写的路径
        /// </summary>
        /// <param name="url">url路径</param>
        /// <param name="paras">参数</param>
        private void RegexExecute(string url,string pageindex)
        {
            Regex r = new Regex(@"^/(\w+)(/\w+)*", RegexOptions.IgnoreCase);
            Match m = r.Match(url);
            if (m.Groups.Count <= 0)
            {
                return;
            }
            Model.Category model = new CategoryBll().GetModel(url);
            if (model == null)
            {
                return;
            }
            string path = string.Empty;
            path = string.Format("/{0}Page/{0}Detail.aspx?id={1}", FirstCharUpper(m.Groups[1].ToString()), model.CategoryId); //每个页面
            if (!string.IsNullOrWhiteSpace(pageindex))
            {
                path += ("&pageindex=" + pageindex);
            }
            Context.RewritePath(path);//url重写 
        }
        #endregion

        #region 首字母大写
        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FirstCharUpper(string s)
        {
            string str = s.ToLower();
            str = str.Substring(0, 1).ToUpper() + str.Substring(1, s.Length - 1);
            return str;
        } 
        #endregion

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex=Server.GetLastError();
            log4net.ILog log= log4net.LogManager.GetLogger("FirstLog");
            log.Error(ex);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}