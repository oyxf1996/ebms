using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Bll;
using oyxf.Model;
using oyxf.Common;

namespace oyxf.OPPortal.Category
{
    public partial class EditContent : System.Web.UI.Page
    {
        CategoryBll bll = new CategoryBll();
        protected string Content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Context.Request.QueryString["id"];
            ViewState["id"] = id;
            oyxf.Model.Category model= bll.GetModel(Convert.ToInt32(id));
            lblCategoryName.Text = model.Name;
            Content = model.Content;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id=ViewState["id"].ToString();
            if (string.IsNullOrWhiteSpace(id))
            {
                return;
            }
            oyxf.Model.Category model = new Model.Category();
            model.CategoryId = Convert.ToInt32(id);
            model.Content = Request.Form["ueditor"].ToString();
            if (bll.UpdateContent(model))
            {
                ScriptHelper.AlertRedirect("修改成功","/Category/List.aspx");
            }
            else
            {
                ScriptHelper.Alert("修改失败");
            }
        }
    }
}