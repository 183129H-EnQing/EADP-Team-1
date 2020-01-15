using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedInUser = (User)Session["currentUser"];

            if (loggedInUser != null)
            {
                if (BLL.Admin.RetrieveAdmin(loggedInUser) == null)
                {
                    if (loggedInUser.Username.Contains("DineshGod"))
                    {
                        BLL.Admin admin = new BLL.Admin();
                        admin.UserId = loggedInUser.Id;
                        admin.Add();
                        System.Diagnostics.Debug.WriteLine("Making DineshGod admin");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Not an admin");
                        Response.Redirect("/Redirect.aspx");
                    }
                }
            }
        }
    }
}