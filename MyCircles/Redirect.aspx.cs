using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
        }

        protected void geolocationForm_Submit(object sender, EventArgs e)
        {
            var currentUser = (User)Session["currentUser"];
            currentUser.Latitude = Convert.ToDouble(tbLat.Text);
            currentUser.Longitude = Convert.ToDouble(tbLong.Text);

            currentUser.UpdateUserLocation();
            Session["currentUser"] = currentUser;

            Response.Redirect("Profile/User.aspx");
        }
    }
}