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
    public partial class AboutCompany : System.Web.UI.UserControl
    {
        protected string AboutCompanyStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定AboutCompanyStr
            oyxf.Model.Config config = new oyxf.Model.Config();
            ConfigBll configbll = new ConfigBll();
            config = configbll.GetModel(1);
            string categoryId = ConfigurationManager.AppSettings["AboutCompanyCategoryId"];
            Category category = new CategoryBll().GetModel(Convert.ToInt32(categoryId));

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='topic'>");
            sb.AppendFormat("<div class='TopicTitle'>{0} About</div>", category.Name);
            sb.Append("<div class='TopicMore'>");
            sb.AppendFormat("<a href='{0}'><img src='images/more.png' /></a>", category.Url);
            sb.Append("</div>");
            sb.Append("</div>");

            sb.Append("<div class='img'>");
            sb.AppendFormat("<img src='{0}' width='220' height='100' alt='{1}'>", config.AboutImgUrl, category.Name);
            sb.Append("</div>");
            sb.Append("<div class='txt ColorLink'>");
            sb.Append("<p>");
            sb.AppendFormat("{0}<a href='{1}'> 详细&gt;&gt;</a>", config.AboutIntro.Length > 60 ? config.AboutIntro.Substring(0, 60) + "..." : config.AboutIntro, config.AboutUrl);
            sb.Append("</p>");
            sb.Append("</div>");
            AboutCompanyStr = sb.ToString(); 
            #endregion
        }
    }
}