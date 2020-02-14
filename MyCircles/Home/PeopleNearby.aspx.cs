using MyCircles.DAL;
using Reimers.Google.Map;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.Home
{
    public partial class PeopleNearby : System.Web.UI.Page
    {
        public BLL.User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectValidator.isUser();
            currentUser = (BLL.User)Session["currentUser"];

            var notfollow = UserDAO.GetNewUser(currentUser.Id);
            
            GridViewFollow.DataSource = notfollow;
            GridViewFollow.DataBind();

            GMap.ApiKey = ConfigurationManager.AppSettings["MapKey"];

            if (currentUser.Latitude != null || currentUser.Longitude != null)
            {
                LatLng currentPos = new LatLng();
                double currentLat = (this.currentUser.Latitude.HasValue) ? this.currentUser.Latitude.Value : 0;
                double currentLng = (this.currentUser.Longitude.HasValue) ? this.currentUser.Longitude.Value : 0;

                currentPos.Latitude = currentLat;
                currentPos.Longitude = currentLng;
                if (!Page.IsPostBack) GMap.Center = currentPos;
                var marker = new Marker(currentPos);

                GMap.Overlays.Add(marker);
            }
        }

        protected void GridViewFollow_DataBound(object sender, EventArgs e)
        {
           

        }

        protected void GridViewFollow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = e.Row.DataItem;
                BLL.User userpost = data as BLL.User;
               
              

                var circlesname = UserCircleDAO.GetAllUserCircles(userpost.Id);

                DropDownList DropDownList1 = (e.Row.FindControl("DropDownList1") as DropDownList);
                DropDownList1.DataSource = circlesname;
                DropDownList1.DataTextField = "CircleId";
                DropDownList1.DataValueField = "CircleId";
                DropDownList1.DataBind();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Profile/User.aspx");
        }

        protected void GridViewFollow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           


        }
    }
}