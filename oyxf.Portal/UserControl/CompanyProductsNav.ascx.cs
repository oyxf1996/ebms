using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oyxf.Portal.UserControl
{
    public partial class CompanyProductsNav : System.Web.UI.UserControl
    {
        protected string CompanyProductsNavStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定CompanyProductsNavStr
            //公司产品CategoryId
            string companyProductsCategoryId = ConfigurationManager.AppSettings["CompanyProductsCategoryId"];
            List<Model.Category> categoryList = new oyxf.Bll.CategoryBll().GetModelList("");//所有分类
            //公司产品category
            Model.Category companyProduct = categoryList.SingleOrDefault(o => o.CategoryId == Convert.ToInt32(companyProductsCategoryId));
            //产品分类列表
            List<Model.Category> productCategoryList = categoryList.FindAll(o => o.ParentId == companyProduct.CategoryId);
            //所有产品
            List<Model.Product> productList = new oyxf.Bll.ProductBll().GetModelList("Status=1");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div class='topic'>{0}&nbsp;&nbsp;&nbsp;Product</div>", companyProduct.Name);
            sb.Append("<div class='ClassNav'>");
            sb.Append("<div class='NavTree'>");
            sb.Append("<ul id='suckertree1'>");
            List<Model.Product> list = new List<Model.Product>();//某分类在product中的所有产品
            for (int i = 0; i < productCategoryList.Count; i++)//遍历产品分类列表
            {
                sb.Append("<li>");
                sb.AppendFormat("<a href='{0}' {1}>{2}</a>", productCategoryList[i].Url, productCategoryList[i].HasChildren==1?"class='subfolderstyle'":"", productCategoryList[i].Name);
                if (productCategoryList[i].HasChildren==1)
                {
                    sb.Append("<ul style='display: none;'>");
                    foreach (Model.Category item in categoryList.FindAll(o => o.ParentId==productCategoryList[i].CategoryId))
                    {
                        sb.AppendFormat("<li><a href='{0}'>{1}</a></li>", item.Url, item.Name);
                    }
                    sb.Append("</ul>");
                }
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");
            CompanyProductsNavStr = sb.ToString(); 
            #endregion
        }
    }
}