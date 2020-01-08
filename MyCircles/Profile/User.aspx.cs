using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Profile
{
    public partial class User : System.Web.UI.Page
    {
        public BLL.User currentUser; 

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];
            this.Title = currentUser.Username + " - MyCircles";
        }
    }
}