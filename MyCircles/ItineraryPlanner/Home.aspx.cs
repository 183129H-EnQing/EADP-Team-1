using MyCircles.BLL;
using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class Home : System.Web.UI.Page
    {
        Itinerary newItinerary = new Itinerary();
        MyCirclesEntityModel db = new MyCirclesEntityModel();

        public BLL.User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            getExistingPlan();

            
        }

        protected void btnSubmitPlan_Click(object sender, EventArgs e)
        {
            currentUser = (BLL.User)Session["currentUser"];

            //add to Itinerary table
            newItinerary.userId = currentUser.Id;
            newItinerary.startDate = tbStartDate.Text;
            newItinerary.endDate = tbEndDate.Text;
            newItinerary.groupSize = tbNoPeople.Text;

            newItinerary.AddItinerary();
            Response.Write("<script> alert('Plan Created!');</script>");

            Session["startDate"] = tbStartDate.Text;
            Session["endDate"] = tbEndDate.Text;
            Response.Redirect("Timeline.aspx");
        }

        private void getExistingPlan()
        {
            Itinerary retrieveItinerary = new Itinerary();
            List<Itinerary> itineraryList = new List<Itinerary>();

            currentUser = (BLL.User)Session["currentUser"];
            itineraryList = retrieveItinerary.RetrieveItinerary(currentUser);

            rpItinerary.DataSource = itineraryList;
            rpItinerary.DataBind();
        }
    }
}