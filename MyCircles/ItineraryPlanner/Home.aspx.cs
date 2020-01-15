using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class Home : System.Web.UI.Page
    {
        public BLL.Itinerary newItinerary;
        MyCirclesEntityModel db = new MyCirclesEntityModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            getExistingPlan();
        }

        protected void btnSubmitPlan_Click(object sender, EventArgs e)
        {
            //add to table
            newItinerary.userId = 9;
            newItinerary.startDate = tbStartDate.Text;
            newItinerary.endDate = tbEndDate.Text;
            newItinerary.groupSize = Convert.ToInt32(tbNoPeople.Text);
            Response.Write("<script> alert('Plan Created!');</script>");

            Session["startDate"] = tbStartDate.Text;
            Session["endDate"] = tbEndDate.Text;
            Response.Redirect("Timeline.aspx");
        }

        private void getExistingPlan()
        {
            string s = "select * from Itinerary";

        }
    }
}