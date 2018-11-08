using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;

namespace oyxf.Portal.AboutPage
{
    public partial class AboutDetail : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id=Context.Request.QueryString["id"];//获取Global.asax重写所添加的id
                Category category=new CategoryBll().GetModel(Convert.ToInt32(id));
                content = category.Content;
            }
        }
    }
}