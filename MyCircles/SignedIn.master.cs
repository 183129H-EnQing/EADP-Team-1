using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles
{
    public partial class SignedIn : System.Web.UI.MasterPage
    {
        public User currentUser;
        public string currentUsername;

        protected void Page_Load(object sender, EventArgs e)
        {
            //RedirectValidator.isUser();

            currentUser = (User)Session["currentUser"];
            ProfileLink.HRef = "Profile/User.aspx?username=" + currentUser.Username;

            ProfilePicNavImage.ImageUrl = currentUser.ProfileImage;

            if (BLL.Admin.RetrieveAdmin(currentUser) != null)
                adminLink.Visible = true;
        }

        protected void SignOutLink_ServerClick(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("/Auth/Login.aspx");
        }
    }
}