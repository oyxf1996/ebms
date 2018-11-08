using oyxf.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Common;

namespace oyxf.OPPortal.UserInfo
{
    public partial class Edit : BasePage
    {
        UserInfoBll bllUserInfo = new UserInfoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strUserId = Request.QueryString["id"];
                if (!string.IsNullOrWhiteSpace(strUserId) && strUserId.IsNumber())
                {
                    BindData(Convert.ToInt32(strUserId));
                }
            }
        }

        private void BindData(int userId)
        {
            oyxf.Model.UserInfo model = bllUserInfo.GetModel(userId);
            txtUserId.Value = model.UserId.ToString();
            txtUsername.Text = model.Username;
            txtPassword.Attributes["value"] = "******";//Password类型的 要用Attributes["value"]赋值
            txtRealName.Text = model.RealName;
            txtPhone.Text = model.Phone;
            ddlUserType.SelectedValue = model.UserType.ToString();
            rblStatus.SelectedValue = model.Status.ToString();
            txtCreateDate.Value = model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss:fff");
        }
    }
}