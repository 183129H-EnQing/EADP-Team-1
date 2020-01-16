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

            if (!String.IsNullOrEmpty(tbLat.Text) || !String.IsNullOrEmpty(tbLong.Text))
            {
                currentUser.Latitude = Convert.ToDouble(tbLat.Text);
                currentUser.Longitude = Convert.ToDouble(tbLong.Text);
                currentUser.City = tbCity.Text;
            }

            if (currentUser.City == null) currentUser.City = "Unknown";

            currentUser.UpdateUserLocation();
            Session["currentUser"] = currentUser;

            Response.Redirect("Home/Post.aspx");
        }
    }
}