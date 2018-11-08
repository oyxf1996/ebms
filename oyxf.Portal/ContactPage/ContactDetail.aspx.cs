using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oyxf.Portal.ContactPage
{
    public partial class ContactDetail : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定content
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='content'>");
            sb.Append("<div class='maincontent clearfix'>");
            sb.Append("<p align='center'></p>");
            sb.Append("<p><strong>易源码商城</strong> </p>");
            sb.Append("<p>地址：广州市天河区 </p>");
            sb.Append("<p>电话：020-88888888&nbsp; </p>");
            sb.Append("<p>E-mil：<a href='mailto:mikl@163.com'>mikl@163.com</a> </p>");
            sb.Append("<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QQ：995226433</p>");
            sb.Append("<p>&nbsp;</p>");
            sb.Append("</div>");
            sb.Append("</div>");
            content = sb.ToString(); 
            #endregion
        }
    }
}