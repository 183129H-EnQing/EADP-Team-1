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
        ItineraryPref newItineraryPref = new ItineraryPref();

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

            //daybydays table
            int datesSize = betweenDates.Count;
            for(int i = 0; i < betweenDates.Count; i++)
            {
                newDayByDay.itineraryId = newItinerary.itineraryId;
                newDayByDay.date = betweenDates[i];
                newDayByDay.AddDayByDay();
            }

            //check pref
            PrefSelect(newItinerary.itineraryId);
            //days table and planner generate - with pref/no pref
            GeneratePlanner();

            Session["startDate"] = tbStartDate.Text;
            Session["endDate"] = tbEndDate.Text;

            string url = "Timeline.aspx?Id=" + newItinerary.itineraryId;
            Response.Redirect(url);
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

        private void PrefSelect(int Id)
        {
            //int itineraryId = Id;
            if (cbBeaches.Checked)
            {
                Session["prefB"] = cbBeaches.Text;

                ItineraryPref newItineraryPref = new ItineraryPref();

                //call ItineraryPref method to add to table
                newItineraryPref.itineraryId = newItinerary.itineraryId;
                newItineraryPref.prefId = 1;
                newItineraryPref.AddItineraryPref();
            }
            if (cbOutdoors.Checked)
            {
                Session["prefO"] = cbOutdoors.Text;

                ItineraryPref newItineraryPref = new ItineraryPref();

                newItineraryPref.itineraryId = newItinerary.itineraryId;
                newItineraryPref.prefId = 2;
                newItineraryPref.AddItineraryPref();
            }
            if (cbMuseums.Checked)
            {
                Session["prefM"] = cbMuseums.Text;

                ItineraryPref newItineraryPref = new ItineraryPref();

                newItineraryPref.itineraryId = newItinerary.itineraryId;
                newItineraryPref.prefId = 3;
                newItineraryPref.AddItineraryPref();
            }
            if (cbHistoric.Checked)
            {
                Session["prefH"] = cbHistoric.Text;

                ItineraryPref newItineraryPref = new ItineraryPref();

                newItineraryPref.itineraryId = newItinerary.itineraryId;
                newItineraryPref.prefId = 4;
                newItineraryPref.AddItineraryPref();
            }
            if (cbShopping.Checked)
            {
                Session["prefS"] = cbShopping.Text;

                ItineraryPref newItineraryPref = new ItineraryPref();

                newItineraryPref.itineraryId = newItinerary.itineraryId;
                newItineraryPref.prefId = 5;
                newItineraryPref.AddItineraryPref();
            }
            if (cbWildlife.Checked)
            {
                Session["prefW"] = cbWildlife.Text;

                ItineraryPref newItineraryPref = new ItineraryPref();

                newItineraryPref.itineraryId = newItinerary.itineraryId;
                newItineraryPref.prefId = 6;
                newItineraryPref.AddItineraryPref();
            }
        }

        private void GeneratePlanner()
        {
            Day newDay = new Day();
            Location getLocation = new Location();

            if (Session["prefB"] == null &&
                Session["prefO"] == null &&
                Session["prefM"] == null &&
                Session["prefH"] == null &&
                Session["prefS"] == null &&
                Session["prefW"] == null)
            {

            }
        }
    }
}