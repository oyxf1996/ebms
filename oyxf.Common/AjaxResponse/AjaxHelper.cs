using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace oyxf.Common.AjaxResponse
{
    public class AjaxHelper
    {
        public static void WriteError(AjaxEnum status = AjaxEnum.Error, string msg = "失败")
        {
            WriteAjax(status, msg);
        }

        public static void WriteSuccess(AjaxEnum status=AjaxEnum.Success,string msg="成功")
        {
            WriteAjax(status,msg);
        }

        private static void WriteAjax(AjaxEnum status,string msg)
        {
            AjaxObject ao = new AjaxObject();
            ao.status = status;
            ao.msg = msg;
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(ao));
            HttpContext.Current.Response.End();
        }
    }
}
