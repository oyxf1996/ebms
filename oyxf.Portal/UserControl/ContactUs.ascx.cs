using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oyxf.Portal.UserControl
{
    public partial class ContactUs : System.Web.UI.UserControl
    {
        protected string contactUs = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定contactUs
            StringBuilder sb = new StringBuilder();
            Model.Config config = new Bll.ConfigBll().GetModel(1);
            sb.AppendFormat("<div class='topic'>{0}&nbsp;&nbsp;&nbsp;Contact</div>", "联系我们");
            sb.Append("<div class='blank'>");
            sb.Append("<div style='padding-left: 20px;'>");
            sb.AppendFormat("<p><strong>{0}</strong></p>", config.CompanyName);
            sb.AppendFormat("<p>地址：{0}</p>", config.Address);
            sb.AppendFormat("<p>邮编：{0}</p>", config.Postcode);
            sb.AppendFormat("<p>电话：{0}</p>", config.Telephone);
            sb.AppendFormat("<p>网址：<a href='{0}' target='_blank'>{0}</a></p>", config.Website);
            sb.AppendFormat("<p>邮箱：<a href='mailto:{0}'>{0}</a></p>", config.Email);
            sb.Append("</div>");
            sb.Append("</div>");
            contactUs = sb.ToString(); 
            #endregion
        }
    }
}