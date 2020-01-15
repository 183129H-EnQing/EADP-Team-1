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
            RedirectValidator.isUser();

            currentUser = (User)Session["currentUser"];
            ProfileLink.HRef = "Profile/User.aspx?username=" + currentUser.Username;

            ProfilePicNavImage.ImageUrl = "~" + currentUser.ProfileImage;
        }
    }
}