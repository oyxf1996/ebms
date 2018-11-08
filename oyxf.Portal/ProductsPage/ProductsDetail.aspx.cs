using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;
using oyxf.Common;

namespace oyxf.Portal.ProductsPage
{
    public partial class ProductsDetail : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定content
            string id = Context.Request.QueryString["id"];
            #region 分页所需数据
            int pageSize = 2;//想呈现页大小
            int recordCount = 0;//总产品条数
            string pageindex = Context.Request.QueryString["pageindex"];
            pageindex = (string.IsNullOrWhiteSpace(pageindex) == true || !pageindex.IsNumber()) ? "1" : pageindex;//如果不传pageindex，默认返回第一页
            List<Model.Product> list = GetProductsList(pageSize, id, pageindex, ref recordCount);//获取产品分页列表
            if (list == null) {
                content = "";
                return;
            }
            string indexHref = Request.RawUrl;//url
            int pageCount = (int)Math.Ceiling((double)recordCount / pageSize);//页数
            if (indexHref.Contains('?'))
            {
                indexHref = indexHref.Substring(0, indexHref.IndexOf('?'));
            }
            int minCount = list.Count < pageSize ? list.Count : pageSize;//当前页大小与想呈现页大小取最小值 
            #endregion

            if (id == null)
            {
                content = "您为传递id参数";
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='content'>");
            sb.Append("<div class='MorePro'>");
            sb.Append("<div class='CaseBlock'>");
            sb.Append("<ul>");
            sb.Append("<ul>");
            for (int i = 0; i < minCount; i++)
            {
                sb.Append("<div class='albumblock'>");
                sb.Append("<div class='inner'>");
                sb.AppendFormat("<a href='{0}' target='_blank' title='{1}'>", "/ProductsPage/ProductsContent.aspx?productid=" + list[i].ProductId, list[i].Name);
                sb.AppendFormat("<img src='{0}'><div class='albumtitle'>{1}</div>", list[i].ImgUrl, list[i].Name);
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("</div>");
            }
            sb.Append("</ul>");
            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("<div class='clearfix'></div>");

            #region 分页
            //总数、当前页数，首页
            sb.AppendFormat("<div class='t_page ColorLink'>总数：{0}条&nbsp;&nbsp;当前页数：<span class='FontRed'>{1}</span>/{2}<a href='{3}'>首页</a>&nbsp;&nbsp;", recordCount, pageindex, pageCount, indexHref + "?pageindex=1");
            //上一页
            if (Convert.ToInt32(pageindex) == 1)
            {
                sb.Append("上一页&nbsp;&nbsp;");
            }
            else
            {
                sb.AppendFormat("<a href='{0}' >上一页</a>&nbsp;&nbsp;", indexHref + "?pageindex=" + (int.Parse(pageindex) - 1 <= 0 ? 1 : (int.Parse(pageindex) - 1)));
            }
            //显示页
            for (int i = 0; i < pageCount; i++)
            {
                sb.AppendFormat("<a href='{0}' {2}>{1}</a>", indexHref + "?pageindex=" + (i + 1), (i + 1), (i + 1) == Convert.ToInt32(pageindex) ? "style=\"border: 1px solid red;\"" : "");
            }

            //下一页
            if (Convert.ToInt32(pageindex) == pageCount)
            {
                sb.Append("下一页&nbsp;&nbsp;");
            }
            else
            {
                sb.AppendFormat("<a href='{0}' >下一页</a>&nbsp;&nbsp;", indexHref + "?pageindex=" + (int.Parse(pageindex) + 1 > pageCount ? pageCount : (int.Parse(pageindex) + 1)));
            }
            //尾页
            sb.AppendFormat("<a href='{0}'>尾页</a></div>", indexHref + "?pageindex=" + pageCount);

            #endregion

            sb.Append("</div>");
            sb.Append("</div>");
            content = sb.ToString(); 
            #endregion
        }

        #region 获取产品列表
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="id"></param>
        /// <param name="pageindex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        private static List<Model.Product> GetProductsList(int pageSize, string id, string pageindex, ref int recordCount)
        {
            string newsin = string.Empty;
            List<Model.Category> categoryList = new CategoryBll().GetModelList("Status=1");
            List<int> inList = categoryList.FindAll(o => o.IdPath.StartsWith(categoryList.SingleOrDefault(p => p.CategoryId == Convert.ToInt32(id)).IdPath)).Select(o => o.CategoryId).ToList();
            foreach (int item in inList)
            {
                newsin += (item.ToString() + ',');
            }
            newsin = newsin.TrimEnd(',');
            List<Model.Product> list = new ProductBll().GetPage(Convert.ToInt32(pageindex), pageSize, "UpdateDate desc", out recordCount, "CategoryId in(" + newsin + ")");
            return list;
        }
        #endregion
    }

}