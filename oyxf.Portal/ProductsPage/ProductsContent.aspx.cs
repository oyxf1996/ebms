using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Model;
using oyxf.Bll;
using oyxf.Common;

namespace oyxf.Portal.ProductsPage
{
    public partial class ProductsContent : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected string proInfo = string.Empty;
        protected string morePro = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //           <div class="image"><a href="/images/up_images/201299145547.jpg" rel="clearbox" title="联想手机: 5寸HD屏四核安卓 联想K860仅售2000出头">
            //    <img src="/images/up_images/201299145547.jpg" height="270" width="270"></a></div>
            //<div class="column">
            //    <div class="title">
            //        <h3>联想手机: 5寸HD屏四核安卓 联想K860仅售2000出头</h3>
            //    </div>
            //    <div class="infos">更新：2012/9/9 14:55:49&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;点击：<script language="javascript" src="/inc/article_view.asp?id=951"></script></div>
            //    <ul>
            //        <li><span>产品品牌</span>&nbsp;&nbsp;&nbsp;联想</li>
            //        <li><span>产品型号</span>&nbsp;&nbsp;&nbsp;K860</li>
            //        <li><span>产品描述</span>
            //            <p>联想K860是一款性价比很强悍的国产四核安卓手机，采用和盖世3相同的Exynos4412处理器，性能非常给力，市场报价仅2188元，K860还配备5英寸1280x720像素IPS高清屏，运行安卓4.0...</p>
            //        </li>
            //    </ul>
            //</div>
            string productid = Context.Request.QueryString["productid"];
            List<Model.Product> productList = new ProductBll().GetModelList("Status=1");

            if (string.IsNullOrWhiteSpace(productid))
            {
                productid = productList[0].ProductId.ToString();
            }
            if (!productid.IsNumber())
            {
                productid = productList[0].ProductId.ToString();
            }
            bool isExists = productList.Exists(o => o.ProductId == Convert.ToInt32(productid));
            if (!isExists)
            {
                productid = productList[0].ProductId.ToString();
            }

            Model.Product product = productList.SingleOrDefault(o => o.ProductId == Convert.ToInt32(productid));
            List<Model.Category> categoryList = new CategoryBll().GetModelList("");
            StringBuilder sb = new StringBuilder();

            #region 绑定proInfo
            sb.Append("<div class='image'>");
            sb.AppendFormat("<a href='{0}' rel='clearbox' title='{1}'>", product.ImgUrl, product.Name);
            sb.AppendFormat("<img src='{0}' height='270' width='270'>", product.ImgUrl);
            sb.Append("</a>");
            sb.Append("</div>");

            sb.Append("<div class='column'>");
            sb.AppendFormat("<div class='title'><h3>{0}</h3></div>", product.Name);
            sb.AppendFormat("<div class='infos'>更新：{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;点击：{1}</script></div>", product.UpdateDate, product.Click);
            sb.Append("<ul>");
            sb.AppendFormat("<li><span>产品品牌</span>&nbsp;&nbsp;&nbsp;{0}</li>", product.Brand);
            sb.AppendFormat("<li><span>产品型号</span>&nbsp;&nbsp;&nbsp;{0}</li>", product.Type);
            sb.AppendFormat("<li><span>产品描述</span><p>{0}</p></li>", product.Description.Length > 60 ? (product.Description.Substring(0, 60) + "...") : product.Description);
            sb.Append("</ul>");
            sb.Append("</div>");
            proInfo = sb.ToString();
            #endregion


            //            <div class="albumblock">
            //    <div class="inner"><a href="/Product/9048215147.html" target="_blank" title="高潮彼伏此起 魅族MX全新双核开学礼">
            //        <img src="/images/up_images/201299145145.jpg" width="139" height="139">
            //        <div class="albumtitle">高潮彼伏此起 魅族MX全新双</div>
            //    </a></div>
            //</div>
            sb.Clear();

            #region 绑定content
            sb.AppendFormat("{0}", product.Content);
            content = sb.ToString();
            #endregion

            sb.Clear();

            #region 绑定morePro
            productList.Remove(product);
            for (int i = 0; i < productList.Count; i++)
            {
                sb.Append("<div class='albumblock'>");
                sb.Append("<div class='inner'>");
                sb.AppendFormat("<a href='{0}' target='_blank' title='{1}'>", "/ProductsPage/ProductsContent.aspx?productid=" + productList[i].ProductId,productList[i].Name);
                sb.AppendFormat("<img src='{0}' width='139' height='139'>", productList[i].ImgUrl);
                sb.AppendFormat("<div class='albumtitle'>{0}</div>", productList[i].Name.Length > 8 ? productList[i].Name.Substring(0, 8) : productList[i].Name);
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("</div>");
            }

            morePro = sb.ToString();
            #endregion
        }
    }
}