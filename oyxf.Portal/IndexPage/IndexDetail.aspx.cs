using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;
using System.Text;

namespace oyxf.Portal.IndexPage
{
    public partial class IndexDetail : System.Web.UI.Page
    {
        protected string turnPic = string.Empty;
        protected string friendlyLink = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 绑定turnPic
                StringBuilder sb = new StringBuilder();
                List<oyxf.Model.Banner> bannerList = new BannerBll().GetModelList("Status=1").ToList();
                bannerList = bannerList.OrderBy(o => o.SortIndex).ToList();
                foreach (Banner item in bannerList)
                {
                    sb.AppendFormat("<li>");
                    sb.AppendFormat("<a href='{0}' target='_blank'><img src='{1}' alt='{2}'></a>", item.Url, item.ImgUrl, item.Title);
                    sb.AppendFormat("</li>");
                }
                turnPic = sb.ToString(); 
                #endregion

                #region 绑定friendlyLink
                StringBuilder sb2 = new StringBuilder();
                List<oyxf.Model.FriendlyLink> friendlyLinkList = new FriendlyLinkBll().GetModelList("Status=1");
                sb2.Append("<span>友情链接：</span>");
                foreach (FriendlyLink item in friendlyLinkList)
                {
                    sb2.AppendFormat("<a href='{0}' target='_blank'>{1}</a>", item.Url, item.Name);
                }
                friendlyLink = sb2.ToString(); 
                #endregion
            }
        }
       
    }
}