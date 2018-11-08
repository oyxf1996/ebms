using oyxf.Bll;
using oyxf.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oyxf.OPPortal.Config
{

    public partial class Edit : BasePage
    {
        ConfigBll bllConfig = new ConfigBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//首次加载页面
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            //读取Config表的数据
            //页面填空
            oyxf.Model.Config config = bllConfig.GetModel(1);
            if (config != null)
            {
                ViewState["ConfigId"] = config.ConfigId;
                txtCopyright.Text = config.Copyright;
                imgAboutImgUrl.ImageUrl = config.AboutImgUrl;
                txtAboutImgUrl.Text = config.AboutImgUrl;
                txtAboutIntro.Text = config.AboutIntro;
                txtAboutUrl.Text = config.AboutUrl;
                txtNewsUrl.Text = config.NewsUrl;
                imgContactImgUrl.ImageUrl = config.ContactImgUrl;
                txtContactImgUrl.Text = config.ContactImgUrl;
                txtContactUrl.Text = config.ContactUrl;
                txtCompanyName.Text = config.CompanyName;
                txtAddress.Text = config.Address;
                txtPostcode.Text = config.Postcode.ToString();
                txtTelephone.Text = config.Telephone;
                txtWebsite.Text = config.Website;
                txtEmail.Text = config.Email;
                txtProductUrl.Text = config.ProductUrl;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int configId = 0;
            if (ViewState["ConfigId"] != null)
            {
                //修改
                configId = Convert.ToInt32(ViewState["ConfigId"]);
            }

            oyxf.Model.Config config = new Model.Config();
            config.ConfigId = configId;
            config.Copyright = txtCopyright.Text;
            config.AboutImgUrl = txtAboutImgUrl.Text;
            config.AboutIntro = txtAboutIntro.Text;
            config.AboutUrl = txtAboutUrl.Text;
            config.NewsUrl = txtNewsUrl.Text;
            config.ContactImgUrl = txtContactImgUrl.Text;
            config.ContactUrl = txtContactUrl.Text;
            config.CompanyName = txtCompanyName.Text;
            config.Address = txtAddress.Text;
            config.Postcode = Convert.ToInt32(txtPostcode.Text);
            config.Telephone = txtTelephone.Text;
            config.Website = txtWebsite.Text;
            config.Email = txtEmail.Text;
            config.ProductUrl = txtProductUrl.Text;

            if (bllConfig.Update(config))
            {
                ScriptHelper.AlertRefresh("保存成功");
            }
            else
            {
                ScriptHelper.Alert("保存失败");
            }
        }

        /// <summary>
        /// 首页联系方式图片上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContactImgUrl_Click(object sender, EventArgs e)
        {
            if (!fuContactImgUrl.HasFile)
            {
                return;
            }

            string extension = Path.GetExtension(fuContactImgUrl.PostedFile.FileName);
            string fileName = Guid.NewGuid().ToString() + extension;
            string url = "/Upload/" + fileName;

            fuContactImgUrl.SaveAs(Context.Server.MapPath(url));

            imgContactImgUrl.ImageUrl = url;
            txtContactImgUrl.Text = url;

            //ScriptHelper.Alert("上传成功");
        }

        /// <summary>
        /// 关于公司图片上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAboutImgUrl_Click(object sender, EventArgs e)
        {
            if (!fuAboutImgUrl.HasFile)
            {
                return;
            }

            string fileName = fuAboutImgUrl.FileName;
            fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
            string path = "/Upload/" + fileName;//虚拟路径

            fuAboutImgUrl.SaveAs(Server.MapPath(path));

            imgAboutImgUrl.ImageUrl = path;//虚拟路径
            txtAboutImgUrl.Text = path;//验证是否上传

            //ScriptHelper.Alert("上传成功");
        }
    }
}