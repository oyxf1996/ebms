using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Bll;
using System.Drawing;
using oyxf.Common;
using oyxf.Model.Enum;

namespace oyxf.OPPortal.UserInfo
{
    public partial class List : BasePage
    {
        UserInfoBll userInfoBll = new UserInfoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            repUserInfo.DataSource = userInfoBll.GetModelList("");
            repUserInfo.DataBind();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserInfo/Edit.aspx");
        }

        /// <summary>
        /// 数据行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repUserInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //AlternatingItem 间隔行
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblStatus = e.Item.FindControl("lblStatus") as Label;
                Label lblUserType = (Label)e.Item.FindControl("lblUserType");
                UserStatus eUserStatus = (UserStatus)Enum.Parse(typeof(UserStatus), lblStatus.Text);

                //设置前景色
                switch (eUserStatus)
                {
                    case UserStatus.Disabled:
                        lblStatus.ForeColor = Color.Red;//禁用
                        break;
                    case UserStatus.Enabled:
                        lblStatus.ForeColor = Color.Green;//启用
                        break;
                    default:
                        break;
                }

                lblStatus.Text = EnumHelper.GetDescription<UserStatus>(Convert.ToInt64(lblStatus.Text));//根据枚举值获取枚举描述
                lblUserType.Text = EnumHelper.GetDescription<UserType>(Convert.ToInt64(lblUserType.Text));
            }
        }

        /// <summary>
        /// 数据行命令
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repUserInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                    DeleteUserInfo(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 根据用户ID删除用户
        /// </summary>
        /// <param name="userId"></param>
        private void DeleteUserInfo(int userId)
        {
            if (userInfoBll.Delete(userId))
            {
                ScriptHelper.AlertRefresh("删除成功");
            }
            else
            {
                ScriptHelper.Alert("删除失败");
            }
        }

        protected void anpUserInfo_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {

        }
    }
}