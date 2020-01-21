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
        DayByDay newDayByDay = new DayByDay();

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
            newItinerary.itineraryName = tbName.Text;
            newItinerary.startDate = tbStartDate.Text;
            newItinerary.endDate = tbEndDate.Text;
            newItinerary.groupSize = tbNoPeople.Text;

            //Calculate Middle Dates
            DateTime startDate = Convert.ToDateTime(newItinerary.startDate);
            startDate.ToString("dd MMM");
            DateTime endDate = Convert.ToDateTime(newItinerary.endDate);
            DateTime current = startDate;
            List<string> betweenDates = new List<string>();

            while (current <= endDate)
            {
                var currentDateStr = current.ToString("dd MMM");        //convert 12/1/2020 to 12 Jan
                betweenDates.Add(currentDateStr);
                current = current.AddDays(1);                           //add to current as 12/1/2020
            }

            newItinerary.AddItinerary();
            Response.Write("<script> alert('Plan Created!');</script>");

            int datesSize = betweenDates.Count;
            for(int i = 0; i < betweenDates.Count; i++)
            {
                newDayByDay.itineraryId = newItinerary.itineraryId;
                newDayByDay.date = betweenDates[i];
                newDayByDay.AddDayByDay();
            }

            Session["startDate"] = tbStartDate.Text;
            Session["endDate"] = tbEndDate.Text;

            string url = "Timeline.aspx" + newItinerary.itineraryId;
            Response.Redirect("url");
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