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
    public partial class News : System.Web.UI.UserControl
    {
        protected string NewsStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定NewsStr
            NewsBll newsbll = new NewsBll();
            List<Model.Category> categoryList = new CategoryBll().GetModelList("");//通过NewsId表的CategoryId找到Category表的对应的Url
            string categoryId = ConfigurationManager.AppSettings["NewsCategoryId"];
            Category category = categoryList.Single(o => o.CategoryId == Convert.ToInt32(categoryId));
            List<Model.News> newsList = newsbll.GetModelList("Status=1");//可显示的所有新闻
            newsList = newsList.OrderByDescending(o => o.UpdateDate).ToList();//按更新时间倒序排列
            StringBuilder sb = new StringBuilder();

            //html字符串拼接
            sb.Append("<div class='topic'>");
            sb.AppendFormat("<div class='TopicTitle'>{0} News</div>", category.Name);
            sb.Append("<div class='TopicMore'>");
            sb.AppendFormat("<a href='{0}'><img src='images/more.png'></a>", category.Url);
            sb.Append("</div>");
            sb.Append("<div class='HeightTab clearfix'></div>");
            sb.Append("<ul></ul>");
            sb.Append("</div>");
            sb.Append("<table id='MBlockTable' width='100%' border='0' cellspacing='0' cellpadding='0'>");
            sb.Append("<tbody>");
            foreach (Model.News item in newsList)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td width='75%'>· <a href='{0}' target='_blank' title='{1}'>{1}</a></td>", "/newsPage/newsContent.aspx?newsid=" + item.NewsId, item.Title);
                sb.AppendFormat("<td width='25%'><span>{0}</span></td>", item.UpdateDate.ToShortDateString());
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            NewsStr = sb.ToString();//给前台变量赋值 
            #endregion
        }
    }
}