using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;
using System.Text;

namespace oyxf.Portal
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected string NavigatorContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //<ul id="sddm">
            //                <li class="CurrentLi"><a href="/">网站首页</a></li>
            //                <li><a href="/About/intro" onmouseover="mopen('m2')" onmouseout="mclosetime()">关于公司</a>
            //                   <div id="m3" onmouseover="mcancelclosetime()" onmouseout="mclosetime()" style="visibility: hidden;">
            //   <a href="/news/CompanyNews">公司新闻</a>
            //    <a href="/news/IndustryNews">行业新闻</a>
            //</div>
            //                </li>
            //                <li><a href="/news/" onmouseover="mopen('m3')" onmouseout="mclosetime()">新闻动态</a>
            //                    <div id="m3" onmouseover="mcancelclosetime()" onmouseout="mclosetime()" style="visibility: hidden;"><a href="/news/CompanyNews">公司新闻</a> <a href="/news/IndustryNews">行业新闻</a> </div>
            //                </li>
            //                <li><a href="/Product/" onmouseover="mopen('m4')" onmouseout="mclosetime()">公司产品</a>
            //                    <div id="m4" onmouseover="mcancelclosetime()" onmouseout="mclosetime()"><a href="/Product/DigitalPlayer">数码播放器</a> <a href="/Product/Pad">平板电脑</a> <a href="/Product/GPS">GPS导航</a> <a href="/Product/NoteBook">笔记本电脑</a> <a href="/Product/Mobile">智能手机</a> </div>
            //                </li>
            //                <li><a href="/Support/" onmouseover="mopen('m5')" onmouseout="mclosetime()">技术支持</a>
            //                    <div id="m5" onmouseover="mcancelclosetime()" onmouseout="mclosetime()" style="visibility: hidden;"><a href="/Support/Services">售后服务</a> <a href="/Support/Download">下载中心</a> <a href="/Support/FAQ">常见问题</a> </div>
            //                </li>
            //                <li><a href="/Recruit/" onmouseover="mopen('m6')" onmouseout="mclosetime()">人才招聘</a>
            //                    <div id="m6" onmouseover="mcancelclosetime()" onmouseout="mclosetime()" style="visibility: hidden;"><a href="/recruit/peiyang">人才培养</a> <a href="/recruit/fuli">福利待遇</a> <a href="/recruit/jobs">招聘职位</a> </div>
            //                </li>
            //                <li><a href="/contact/">联系我们</a></li>
            //                <li><a href="/Feedback/">访客留言</a></li>
            //            </ul>
            StringBuilder sb = new StringBuilder();
            List<oyxf.Model.Category> navigatorList = new CategoryBll().GetModelList("Status=1");
            navigatorList = navigatorList.OrderBy(o => o.ParentId).ThenBy(o => o.SortIndex).ToList();
            List<oyxf.Model.Category> firstList = navigatorList.FindAll(o => o.ParentId == 0).ToList();

            sb.Append("<ul id='sddm'>");
            //一级导航栏
            for (int i = 0; i < firstList.Count; i++)
            {
                sb.AppendFormat("<li>");
                if (firstList[i].HasChildren == 0)//没有子菜单
                {
                    sb.AppendFormat("<a href='{0}''>{1}</a>", firstList[i].Url, firstList[i].Name);
                    sb.AppendFormat("</li>");
                    continue;//不执行下面的二级导航栏代码
                }
                else//有子菜单
                {
                    sb.AppendFormat("<a href='{0}' {1} onmouseout='mclosetime()'>{2}</a>", firstList[i].Url, "onmouseover=\"mopen('m" + (i + 1) + "')\"", firstList[i].Name);
                }

                //二级导航栏
                sb.AppendFormat("<div id=\"{0}\" onmouseover='mcancelclosetime()' onmouseout='mclosetime()' style='visibility: hidden;'>", "m" + (i + 1));
                foreach (Category item in navigatorList.FindAll(o => o.ParentId == firstList[i].CategoryId).ToList())
                {
                    sb.AppendFormat("<a href='{0}'>{1}</a>", item.Url, item.Name);
                }
                sb.AppendFormat("</div>");

                sb.AppendFormat("</li>");

            }
            sb.Append("</ul>");
            NavigatorContent = sb.ToString();
        }
    }
}