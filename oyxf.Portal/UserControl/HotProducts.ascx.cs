using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oyxf.Portal.UserControl
{
    public partial class HotProducts : System.Web.UI.UserControl
    {
        protected string hotProductStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //        <div class="topic">热门产品&nbsp;&nbsp;&nbsp;Hot</div>
            //<div class="list">
            //    <dl>
            //        <dt>2011/12/10</dt>
            //        <dd><a href="/Product/2783062333.html" target="_blank" title="昂达GPS导航仪VP80 3D版 四维图新全实景6寸">昂达GPS导航仪VP80 3</a></dd>
            //    </dl>
            //</div>
            List<Model.Category> categoryList = new oyxf.Bll.CategoryBll().GetModelList("");
            List<Model.Product> list = new oyxf.Bll.ProductBll().GetModelList("Status=1","UpdateDate desc");
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='topic'>热门产品&nbsp;&nbsp;&nbsp;Hot</div>");
            sb.Append("<div class='list'>");
            sb.Append("<dl>");
            for (int i = 0; i < list.Count; i++)
            {
                sb.AppendFormat("<dt>{0}</dt>", list[i].UpdateDate.ToShortDateString());
                sb.AppendFormat("<dd><a href='{0}' target='_blank' title='{1}'>{2}</a></dd>", "/ProductsPage/ProductsContent.aspx?productid=" + list[i].ProductId, list[i].Name, list[i].Name.Length > 14 ? list[i].Name.Substring(0, 13) : list[i].Name);
            }
            sb.Append("</dl>");
            sb.Append("</div>");

            hotProductStr = sb.ToString();

        }
    }
}