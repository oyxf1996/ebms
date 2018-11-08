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

namespace oyxf.Portal
{
    public partial class twoColumnsMain : System.Web.UI.MasterPage
    {
        protected string titleIndex = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            // &gt;<a href=' / About / '>关于公司</a> &gt; <a href=' / About / intro / '>公司介绍</a>
            string id=Context.Request.QueryString["id"];
            if (id==null)
            {
                return;
            }
            List<Model.Category> list=new CategoryBll().GetModelList("Status=1");
            if (!id.IsNumber())
            {
                id = list[0].CategoryId.ToString();
            }
            Model.Category category = list.SingleOrDefault(o=>o.CategoryId==Convert.ToInt32(id));
            if (category==null)
            {
                return;   
            }
            string[] idStrArr = category.IdPath.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
            List<Model.Category> navList = new List<Category>();
            for (int i = 0; i < idStrArr.Length; i++)
            {
                navList.Add(list.SingleOrDefault(o => o.CategoryId == Convert.ToInt32(idStrArr[i])));
            }
            foreach (Category item in navList)
            {
                sb.AppendFormat(" &gt; <a href='{0}'>{1}</a>",item.Url,item.Name);
            }
            titleIndex = sb.ToString();
        }
    }
}