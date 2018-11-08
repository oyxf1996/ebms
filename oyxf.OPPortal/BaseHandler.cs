using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oyxf.Common;
using oyxf.Common.AjaxResponse;

namespace oyxf.OPPortal
{
    public abstract class BaseHandler : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {
        public HttpContext Context { get { return HttpContext.Current; } }

        public void ProcessRequest(HttpContext context)
        {
            CheckLogin();
            SubProcessRequest(context);
        }

        private void CheckLogin()
        {
            if (Context.Session[Key.SESSION_CURRENTUSER] == null)
            {
                AjaxHelper.WriteError(msg:"您还未登录");
            }
        }

        public abstract void SubProcessRequest(HttpContext context);

        public bool IsReusable
        {
            get { return false; }
        }
    }
}