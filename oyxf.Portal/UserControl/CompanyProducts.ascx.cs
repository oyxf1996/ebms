using oyxf.Bll;
using oyxf.Model;
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
    public partial class CompanyProducts : System.Web.UI.UserControl
    {
        protected string CompanyProductsStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string companyProductsCategoryId = ConfigurationManager.AppSettings["CompanyProductsCategoryId"];
            Category category = new CategoryBll().GetModel(Convert.ToInt32(companyProductsCategoryId));
            //head
            #region head
            sb.Append("<div class='topic'>");
            sb.AppendFormat("<div class='TopicTitle'>{0}  Product</div>", category.Name);
            sb.Append("<div class='TopicMore'>");
            sb.AppendFormat("<a href='{0}'><img src='images/more.png'></a>", category.Url);
            sb.Append("</div>");
            sb.Append("</div>");
            #endregion

            List<Model.Category> categoryList = new CategoryBll().GetModelList("Status=1");//所有分类
            List<Model.Category> productCategoryList = categoryList.Where(o => o.ParentId == Convert.ToInt32(companyProductsCategoryId)).ToList();//公司产品下的所有分类
            //left
            #region left
            sb.Append("<div class='hjnavleft'>");
            sb.Append("<ul>");
            for (int i = 0; i < productCategoryList.Count; i++)
            {
                sb.AppendFormat("<li class='{0}'><a href='{1}' {2}>{3}</a></li>", i == 1 ? "hover1" : "", productCategoryList[i].Url, productCategoryList[i].HasChildren == 1 ? "class='subfolderstyle'" : "", productCategoryList[i].Name);
            }
            sb.Append("</ul>");
            sb.Append("</div>");
            #endregion

            List<Model.Product> productList = new ProductBll().GetModelList("Status=1");//所有产品
            List<Model.Product> list = new List<Product>();//某一产品及其所有子产品
            //right
            #region right
            sb.Append("<div class='hjnavcn'>");
            for (int i = 0; i < productCategoryList.Count; i++)//遍历公司产品下的所有分类
            {
                sb.AppendFormat("<div class='hjone' {0}>", i == 0 ? "style=\"display:block;\"" : "style=\"display:none;\"");//默认选择第一个分类
                //清空list
                list.Clear();
                //得到某一产品及其所有子产品
                list= new ProductBll().GetProAndSubPro(productCategoryList[i].CategoryId);
                foreach (Product item in list) //遍历子产品中的所有产品
                {
                    sb.Append("<div class='albumblock'>");
                    sb.Append("<div class='inner'>");
                    sb.AppendFormat("<a href='{0}' target='_blank' title='{1}'>", "/ProductsPage/ProductsContent.aspx?productid=" + item.ProductId, item.Description);
                    sb.AppendFormat("<img src='{0}' width='166' height='166'><div class='albumtitle'>{1}</div>", item.ThumbUrl, item.Name);
                    sb.Append("</a>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                sb.Append("</div>");
            }
            sb.Append("</div>");
            #endregion
            CompanyProductsStr = sb.ToString();
        }
    }
}

