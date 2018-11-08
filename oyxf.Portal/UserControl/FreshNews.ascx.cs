using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;

namespace oyxf.Portal.UserControl
{
    public partial class FreshNews : System.Web.UI.UserControl
    {
        protected string FreshNewsNav = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定FreshNewsNav
            int totalCount = 5;//最新资讯的显示条数
            StringBuilder sb = new StringBuilder();
            List<Model.News> newsList = new NewsBll().GetModelList("Status=1", "UpdateDate desc");
            List<Model.Category> categoryList = new CategoryBll().GetModelList("");
            int minCount = newsList.Count < totalCount ? newsList.Count : totalCount;//取新闻总条数和想显示条数的最小值
            for (int i = 0; i < minCount; i++)//遍历新闻
            {
                sb.AppendFormat("<dt>{0}</dt>", newsList[i].UpdateDate.ToShortDateString());
                sb.AppendFormat("<dd><a href='{0}' target='_blank' title='{1}'>{1}</a></dd>", "/newsPage/newsContent.aspx?newsid="+newsList[i].NewsId, newsList[i].Title.Length > 14 ? newsList[i].Title.Substring(0, 14) : newsList[i].Title);
            }
            FreshNewsNav = sb.ToString(); 
            #endregion
        }
    }
}