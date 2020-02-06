using MyCircles.BLL;
using Reimers.Google.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class LocationDetail : System.Web.UI.Page
    {
        int locId;
        protected void Page_Load(object sender, EventArgs e)
        {
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            GetALocation();
            MapLocation();
        }

        private void GetALocation()
        {
            Location alocation = new Location();
            List<Location> alocList = new List<Location>();
            alocList = alocation.RetrieveALocation(locId);

            rpLocation.DataSource = alocList;
            rpLocation.DataBind();
        }

        private void MapLocation()
        {
            //GMap.ApiKey = ConfigurationManager.AppSettings["MapKey"];

        }
    }
}