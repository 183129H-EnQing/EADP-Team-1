using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class ViewLocation : System.Web.UI.Page
    {
        MyCirclesEntityModel db = new MyCirclesEntityModel();

        protected void Page_Load(object sender, EventArgs e)
        {

            Location location = new Location();
            List<Location> locationList = new List<Location>();

            locationList = location.RetrieveAllLocation(); ;

            rpLocation.DataSource = locationList;
            rpLocation.DataBind();
        }
    }
}