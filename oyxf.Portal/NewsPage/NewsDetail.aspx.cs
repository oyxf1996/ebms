using oyxf.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Common;
using oyxf.Model;

namespace oyxf.Portal.NewsPage
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定content
            int pageSize = 2;//想呈现页大小
            string id = Context.Request.QueryString["id"];//获取新闻分类Id
            List<News> newList = new NewsBll().GetModelList("Status=1");
            if (!newList.Exists(o => o.NewsId == Convert.ToInt32(id)))
            {
                id = newList[0].NewsId.ToString();
            }
            string pageindex = Context.Request.QueryString["pageindex"];//获取当前页

            pageindex = (string.IsNullOrWhiteSpace(pageindex) == true || !pageindex.IsNumber()) ? "1" : pageindex;//如果不传pageindex，默认返回第一页
            int recordCount = 0;//总新闻条数
            List<Model.News> list = GetNewsList(pageSize, id, pageindex, ref recordCount);//获取新闻列表
            int pageCount = (int)Math.Ceiling((double)recordCount / pageSize);//页数
            int minCount = list.Count < pageSize ? list.Count : pageSize;//当前页大小与想呈现页大小取最小值
            if (id == null)
            {
                content = "请输入正确的url";
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='ArticleList'>");
            sb.Append("<ul></ul>");
            sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            sb.Append("<tbody>");
            for (int i = 0; i < minCount; i++)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td width='90%' class='fw_t'>·<a href='{0}' target='_blank'>{1}</a></td>", "/newsPage/newsContent.aspx?newsid=" + list[i].NewsId, list[i].Title);
                sb.AppendFormat("<td width='10%' class='fw_s'>[{0}]</td>", list[i].UpdateDate.ToString("yyyy-MM-dd"));
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("<div class='clearfix'></div>");
            string indexHref = Request.RawUrl;//url
            if (indexHref.Contains('?'))
            {
                indexHref = indexHref.Substring(0, indexHref.IndexOf('?'));
            }
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
            sb.Append("</div>");

            content = sb.ToString();
            #endregion
        }

        #region 获取新闻列表
        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="id"></param>
        /// <param name="pageindex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        private static List<Model.News> GetNewsList(int pageSize, string id, string pageindex, ref int recordCount)
        {
            string newsin = string.Empty;
            List<Model.Category> categoryList = new CategoryBll().GetModelList("Status=1");
            List<int> inList = categoryList.FindAll(o => o.IdPath.StartsWith(categoryList.SingleOrDefault(p => p.CategoryId == Convert.ToInt32(id)).IdPath)).Select(o => o.CategoryId).ToList();
            foreach (int item in inList)
            {
                newsin += (item.ToString() + ',');
            }
            newsin = newsin.TrimEnd(',');
            List<Model.News> list = new NewsBll().GetPage(Convert.ToInt32(pageindex), pageSize, "UpdateDate desc", out recordCount, "CategoryId in(" + newsin + ")");
            return list;
        }
        #endregion
    }
}