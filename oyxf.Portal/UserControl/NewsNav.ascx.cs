using oyxf.Bll;
using oyxf.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oyxf.Portal.UserControl
{
    public partial class NewsNav : System.Web.UI.UserControl
    {
        protected string NewsNavStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //            <div class="topic">新闻动态&nbsp;&nbsp;&nbsp;News</div>
            //<div class="blank">
            //    <ul>
            //        <li><a href="/News/CompanyNews">公司新闻</a></li>
            //        <li><a href="/News/IndustryNews">行业新闻</a></li>
            //    </ul>
            //</div>
            #region 绑定NewsNavStr
            string id = ConfigurationManager.AppSettings["NewsCategoryId"];
            List<Model.Category> list = new CategoryBll().GetModelList("Status=1");
            List<Model.Category> newsList = list.FindAll(o => o.ParentId == Convert.ToInt32(id));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div class='topic'>{0}&nbsp;&nbsp;&nbsp;News</div>", list.SingleOrDefault(o => o.CategoryId == Convert.ToInt32(id)).Name);
            sb.Append("<div class='blank'>");
            sb.Append("<ul>");
            foreach (Category item in newsList)
            {
                sb.AppendFormat("<li><a href='{0}'>{1}</a></li>", item.Url, item.Name);
            }
            sb.Append("</ul>");
            sb.Append("</div>");
            NewsNavStr = sb.ToString(); 
            #endregion

        }
    }
}