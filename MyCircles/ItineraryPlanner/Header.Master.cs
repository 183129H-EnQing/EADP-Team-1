using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class Header1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            timelinehref.HRef = "Timeline.aspx?Id=" + Id.ToString();
            calendarhref.HRef = "Calendar.aspx?Id=" + Id.ToString();
            maphref.HRef = "Map.aspx?Id=" + Id.ToString();


        }
    }
}