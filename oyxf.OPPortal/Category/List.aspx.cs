using oyxf.Bll;
using oyxf.Common;
using oyxf.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;

namespace oyxf.OPPortal.Category
{
    public partial class List : BasePage
    {

        CategoryBll bllCategory = new CategoryBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();//绑定数据
            }
        }

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            int pageIndex = anpCategory.CurrentPageIndex;//当前页码
            int pageSize = anpCategory.PageSize;//页大小
            int recordCount = 0;

            gvCategory.DataSource = bllCategory.GetPage(pageIndex, pageSize, "ParentId asc,SortIndex asc", out recordCount);
            gvCategory.DataBind();

            anpCategory.RecordCount = recordCount;//总记录数
        } 
        #endregion

        #region 绑定行数据
        /// <summary>
        /// 绑定行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = e.Row.FindControl("lblStatus") as Label;//根据控件ID找到控件
                int status = Convert.ToInt32(lblStatus.Text);
                lblStatus.Text = EnumHelper.GetDescription<DisplayOrNot>(status); //状态

                //内容操作
                Label lblType=e.Row.FindControl("lblTypeName") as Label;
                if (Convert.ToInt32(lblType.Text)==Convert.ToInt32(CategoryType.ContentPage))
                {
                    HyperLink hl= e.Row.FindControl("lnkEditContent") as HyperLink;
                    hl.Visible = true;
                }
            }
        } 
        #endregion

        #region 命令行事件
        /// <summary>
        /// 命令行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                    DeleteCategory(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 点击页码时触发
        /// <summary>
        /// 点击页码时触发
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void anpCategory_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            anpCategory.CurrentPageIndex = e.NewPageIndex;//e.NewPageIndex新页码
            BindData();//绑定数据
        } 
        #endregion

        #region 删除分类与所有子分类
        /// <summary>
        /// 删除分类与所有子分类
        /// </summary>
        /// <param name="categoryId"></param>
        private void DeleteCategory(int categoryId)
        {
            if (bllCategory.DeleteCategory(categoryId))
            {
                ScriptHelper.AlertRefresh("删除成功");
            }
            else
            {
                ScriptHelper.AlertRefresh("删除失败");
            }
        }
        #endregion

        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Category/Edit.aspx");
        }

    }
}