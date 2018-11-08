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

namespace oyxf.Portal.NewsPage
{
    public partial class newsContent : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定content
            string newsid = Context.Request.QueryString["newsid"];
            List<News> newsList = new NewsBll().GetModelList("");
            if (string.IsNullOrWhiteSpace(newsid))
            {
                newsid = newsList[0].NewsId.ToString();
            }
            if (!newsid.IsNumber())
            {
                newsid = newsList[0].NewsId.ToString();
            }
            bool isExists = newsList.Exists(o => o.NewsId == Convert.ToInt32(newsid));
            if (!isExists)
            {
                newsid = newsList[0].NewsId.ToString();
            }
            List<Model.News> list = new NewsBll().GetModelList("Status=1", "UpdateDate desc");
            Model.News news = list.SingleOrDefault(o => o.NewsId == Convert.ToInt32(newsid));
            Model.News preNews = GetPreNews(list, news);
            Model.News nextNews = GetNextNews(list, news);
            if (string.IsNullOrWhiteSpace(newsid))
            {
                content = "newsid未接收到";
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='content'>");
            sb.Append("<div class='title'>");
            sb.AppendFormat("<h3>{0}</h3>", news.Title);
            sb.Append("</div>");
            sb.AppendFormat("<div class='infos'>{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;点击：{1}<script language='javascript' src='/inc/article_view.asp?id=938'></script></div>", news.UpdateDate, news.Click);
            sb.Append("<div class='maincontent clearfix'>");
            sb.Append("<div id='MainContent' class='maincontent clearfix'>");
            sb.AppendFormat("{0}", news.Content);
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div class='prenext'>");
            sb.Append("<ul>");
            if (preNews == null)
            {
                sb.AppendFormat("<li>上一篇：没有了</li>");
            }
            else
            {
                sb.AppendFormat("<li>上一篇：<a href='{0}' target='_blank' title='{1}'>{1}</a> <span class='ListDate'>{2}</span></li>", "/newsPage/newsContent.aspx?newsid=" + preNews.NewsId, preNews.Title, preNews.UpdateDate.ToShortDateString());
            }
            if (nextNews == null)
            {
                sb.AppendFormat("<li>下一篇：没有了</li>");
            }
            else
            {
                sb.AppendFormat("<li>下一篇：<a href='{0}' target='_blank' title='{1}'>{1}</a> <span class='ListDate'>{2}</span></li>", "/newsPage/newsContent.aspx?newsid=" + nextNews.NewsId, nextNews.Title, nextNews.UpdateDate.ToShortDateString());
            }

            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");

            content = sb.ToString();
            #endregion
        }

        #region 上一条新闻
        /// <summary>
        /// 上一条新闻
        /// </summary>
        /// <param name="list"></param>
        /// <param name="news"></param>
        /// <returns></returns>
        private Model.News GetPreNews(List<News> list, News news)
        {
            Model.News preNews = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NewsId == news.NewsId)
                {
                    preNews = i == 0 ? null : list[i - 1];
                }
            }
            return preNews;
        }
        #endregion

        #region 下一条新闻
        /// <summary>
        /// 下一条新闻
        /// </summary>
        /// <param name="list"></param>
        /// <param name="news"></param>
        /// <returns></returns>
        private Model.News GetNextNews(List<News> list, News news)
        {
            Model.News nextNews = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NewsId == news.NewsId)
                {
                    nextNews = i == list.Count - 1 ? null : list[i + 1];
                }
            }
            return nextNews;
        }
        #endregion


    }
}