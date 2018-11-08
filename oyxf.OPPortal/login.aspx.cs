using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oyxf.Common;

namespace oyxf.OPPortal
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.Session[Key.SESSION_CURRENTUSER] != null)
            {
                Context.Response.Redirect("/index.aspx");
            }
        }
    }
}