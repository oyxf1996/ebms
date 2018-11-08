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
    public partial class Edit : BasePage
    {
        CategoryBll bll = new CategoryBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) //回发事件(非首次加载页面)
            {
                return;
            }
            string strCategoryId = Context.Request.QueryString["id"]; //url是否传递了id
            if (string.IsNullOrWhiteSpace(strCategoryId) || !strCategoryId.IsNumber()) //新增页面
            {
                BindParentCategory(); //绑定父级分类
            }
            else //修改页面
            {
                ViewState["id"] = strCategoryId; //
                BindParentCategory(Convert.ToInt32(strCategoryId));//绑定父级分类，排出自身跟子分类
                BindModelToControl(Convert.ToInt32(strCategoryId));//实体绑定到控件上
            }

        }

        #region 实体绑定到控件上
        /// <summary>
        /// 实体绑定到控件上
        /// </summary>
        /// <param name="categoryId"></param>
        private void BindModelToControl(int categoryId)
        {
            oyxf.Model.Category model = bll.GetModel(Convert.ToInt32(categoryId));
            txtCategoryName.Text = model.Name;
            ddlType.SelectedValue = model.Type.ToString();
            ddlParentId.SelectedValue = model.ParentId.ToString();
            rblStatus.SelectedValue = model.Status.ToString();
            txtSortIndex.Text = model.SortIndex.ToString();
            txtUrl.Text = model.Url;
        }
        #endregion

        #region 获取控件数据
        /// <summary>
        /// 获取控件数据
        /// </summary>
        /// <returns>实体Category</returns>
        private oyxf.Model.Category GetControlData()
        {
            oyxf.Model.Category model = new Model.Category();
            model.Name = txtCategoryName.Text;
            model.Type = Convert.ToInt32(ddlType.SelectedValue);
            model.ParentId = Convert.ToInt32(ddlParentId.SelectedValue);
            model.Status = Convert.ToInt32(rblStatus.SelectedValue);
            model.SortIndex = Convert.ToInt32(txtSortIndex.Text);
            model.Url = txtUrl.Text;
            return model;
        }
        #endregion

        #region 绑定父级分类
        /// <summary>
        /// 绑定父级分类
        /// </summary>
        private void BindParentCategory(int strCategoryId = 0)
        {
            ddlParentId.DataSource = bll.GetCategoryDropDownList(strCategoryId);
            ddlParentId.DataTextField = "Name";
            ddlParentId.DataValueField = "CategoryId";
            ddlParentId.DataBind();
            ddlParentId.Items.Insert(0, new ListItem("顶级分类", "0"));
        }
        #endregion

        #region 保存按钮事件
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["id"] == null)//新增分类
            {
                AddCategory();
            }
            else//修改分类
            {
                modifyCategory();
            }
        }
        #endregion

        #region 新增分类
        /// <summary>
        /// 新增分类
        /// </summary>
        private void AddCategory()
        {
            oyxf.Model.Category newCategory = GetControlData();//当前新增的分类
            newCategory.Content = "";
            newCategory.HasChildren = 0;
            int categoryId = bll.Add(newCategory);
            newCategory.CategoryId = categoryId; //将自增长的id赋值到当前新增分类的实体对象
            if (newCategory.ParentId == 0)//新增顶级分类
            {
                newCategory.IdPath = ',' + categoryId.ToString() + ',';
                newCategory.Depth = 1;
            }
            else //新增非顶级分类
            {
                oyxf.Model.Category parentCategory = bll.GetModel(newCategory.ParentId);
                newCategory.IdPath = parentCategory.IdPath + categoryId + ',';
                newCategory.Depth = parentCategory.Depth + 1;

                //修改父级分类的HasChildren
                parentCategory.HasChildren = 1;
                bll.Update(parentCategory);
            }
            bll.Update(newCategory);
            ScriptHelper.AlertRedirect("新增成功", "/Category/List.aspx");
        }
        #endregion

        #region 修改分类
        /// <summary>
        /// 修改分类
        /// </summary>
        private void modifyCategory()
        {
            string categoryId = ViewState["id"].ToString();
            oyxf.Model.Category oldCategory = bll.GetModel(Convert.ToInt32(categoryId));
            oyxf.Model.Category newCategory = GetControlData();
            //数据没有被修改
            if (oldCategory.Name == newCategory.Name && oldCategory.ParentId == newCategory.ParentId
                && oldCategory.Type == newCategory.Type && oldCategory.Status == newCategory.Status
                && oldCategory.SortIndex == newCategory.SortIndex && oldCategory.Url == newCategory.Url)
            {
                ScriptHelper.Alert("数据没有被修改");
                return;
            }
            //数据被修改了
            newCategory.CategoryId = oldCategory.CategoryId;
            newCategory.Content = oldCategory.Content;
            oyxf.Model.Category oldParentCategory = bll.GetModel(oldCategory.ParentId);
            oyxf.Model.Category newParentCategory = bll.GetModel(newCategory.ParentId);
            bll.UpdateFatherCategory(oldParentCategory, newParentCategory,oldCategory,newCategory);
            ScriptHelper.AlertRedirect("修改成功", "/Category/List.aspx");
        }
        #endregion
    }
}