using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;
using System.Text;
using System.Configuration;

namespace oyxf.Portal.UserControl
{
    public partial class Contact : System.Web.UI.UserControl
    {
        protected string ContactStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定ContactStr
            Config config = new Config();
            ConfigBll configbll = new ConfigBll();
            config = configbll.GetModel(1);

            string linkUsCategoryId = ConfigurationManager.AppSettings["LinkUsCategoryId"];
            Category category = new CategoryBll().GetModel(Convert.ToInt32(linkUsCategoryId));
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='topic'>");
            sb.AppendFormat("<div class='TopicTitle'>{0} Contact</div>", category.Name);
            sb.Append("<div class='TopicMore'>");
            sb.AppendFormat("<a href='{0}'><img src='images/more.png'></a>", category.Url);
            sb.Append("</div>");
            sb.Append("</div>");

            sb.Append("<div class='img'>");
            sb.AppendFormat("<img src='{0}' width='250' height='100' alt='{1}'>", config.ContactImgUrl, category.Name);
            sb.Append("</div>");
            sb.Append("<div class='txt ColorLink'>");
            sb.Append("<div style='padding-left: 20px;'>");
            sb.AppendFormat("<p><strong>{0}</strong></p>", config.CompanyName);
            sb.AppendFormat("<p>地址：{0}</p>", config.Address);
            sb.AppendFormat("<p>邮编：{0}</p>", config.Postcode);
            sb.AppendFormat("<p>电话：{0}</p>", config.Telephone);
            sb.AppendFormat("<p>网址：<a href='{0}' target='_blank'>{0}</a></p>", config.Website);
            sb.AppendFormat("<p>邮箱：<a href='mailto:{0}'>{0}</a></p>", config.Email);
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div class=' clearfix'></div>");
            ContactStr = sb.ToString(); 
            #endregion
        }
    }
}