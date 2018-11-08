using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;

namespace oyxf.Portal.UserControl
{
    public partial class AboutCompanyNav : System.Web.UI.UserControl
    {
        protected string AboutCompanyNavStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawurl=Context.Request.RawUrl;
            StringBuilder sb = new StringBuilder();
            List<Model.Category> list = new CategoryBll().GetModelList("Status=1");
            string categoryId=ConfigurationManager.AppSettings["AboutCompanyCategoryId"];
            Model.Category category = list.Single(o=>o.CategoryId==Convert.ToInt32(categoryId));
            List<Model.Category> allList = list.FindAll(o=>o.ParentId==Convert.ToInt32(categoryId));
            sb.AppendFormat("<div class='topic'>{0}&nbsp;&nbsp;&nbsp;About</div>", category.Name);
            sb.Append("<div class='blank'>");
            sb.Append("<ul>");
            for (int i = 0; i < allList.Count; i++)
            {
                sb.AppendFormat("<li {0}><a href='{1}'>{2}</a></li>",allList[i].Url==rawurl?"class='current'":"",allList[i].Url,allList[i].Name);    
            }
            sb.Append("</ul>");
            sb.Append("</div>");
            AboutCompanyNavStr = sb.ToString();
        }
    }
}