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

        protected void landMarkBeaches(object sender, EventArgs e)
        {
            if (cbBeaches.Checked)
            {
                Location locationTag = new Location();
                List<Location> locationTagList = new List<Location>();

                int tagId = int.Parse(cbBeaches.Value);
                locationTagList = locationTag.RetrieveByTag(tagId);

                rpLocation.DataSource = locationTagList;
                rpLocation.DataBind();
            }
        }

        protected void chbBeaches_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBeaches.Checked == true)
            {
                Location locationTag = new Location();
                List<Location> locationTagList = new List<Location>();

                //int tagId = int.Parse(cbBeaches.Value);
                locationTagList = locationTag.RetrieveByTag(1);

                rpLocation.DataSource = locationTagList;
                rpLocation.DataBind();
            }
            else
            {

            }
        }
    }
}