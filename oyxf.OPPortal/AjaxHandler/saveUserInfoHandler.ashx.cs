using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oyxf.Common;
using oyxf.Bll;
using oyxf.Common.AjaxResponse;

namespace oyxf.OPPortal.AjaxHandler
{
    /// <summary>
    /// saveUserInfoHandler 的摘要说明
    /// </summary>
    public class saveUserInfoHandler : BaseHandler
    {

        public override void SubProcessRequest(HttpContext context)
        {
           
            #region 接收参数
            //接收参数
            string strUserId = Context.Request.Form["UserId"];
            string strUsername = Context.Request.Form["Username"];
            string strPassword = Context.Request.Form["Password"];
            string strRealName = Context.Request.Form["RealName"];
            string strPhone = Context.Request.Form["Phone"];
            string strUserType = Context.Request.Form["UserType"];
            string strStatus = Context.Request.Form["Status"];
            string strCreateDate = Context.Request.Form["CreateDate"]; 
            #endregion

            UserInfoBll bllUserInfo = new UserInfoBll();

            #region 实体赋值
            //实体赋值
            oyxf.Model.UserInfo model = new Model.UserInfo();
            if (!string.IsNullOrWhiteSpace(strUserId) && strUserId.IsNumber())
            {
                //修改
                model.UserId = Convert.ToInt32(strUserId);
            }

            model.Username = !string.IsNullOrWhiteSpace(strUsername) ? strUsername : "";
            model.RealName = !string.IsNullOrWhiteSpace(strRealName) ? strRealName : "";
            model.Phone = !string.IsNullOrWhiteSpace(strPhone) ? strPhone : "";
            model.UserType = (!string.IsNullOrWhiteSpace(strUserType) && strUserType.IsNumber()) ? Convert.ToInt32(strUserType) : 0;
            model.Status = (!string.IsNullOrWhiteSpace(strStatus) && strStatus.IsNumber()) ? Convert.ToInt32(strStatus) : 0;

            //创建时间
            model.CreateDate = !string.IsNullOrWhiteSpace(strCreateDate)
                ? DateTime.ParseExact(strCreateDate, "yyyy-MM-dd HH:mm:ss:fff", System.Globalization.CultureInfo.CurrentCulture)
                : DateTime.Now;

            //密码 
            model.Password = !string.IsNullOrWhiteSpace(strPassword) ? strPassword.ToUpper() : "";
            #endregion

            #region 用户名是否重复
            //用户名是否重复
            if (bllUserInfo.IsExistUsername(model))
            {
                AjaxHelper.WriteError(msg:"用户名已存在");
            } 
            #endregion

            #region 新增或修改
            //新增或修改
            if (bllUserInfo.AddOrUpdate(model))
            {
                AjaxHelper.WriteSuccess();
            }
            else
            {
                AjaxHelper.WriteError(msg:"操作失败");
            } 
            #endregion

        }
    }
}