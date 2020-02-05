using MyCircles.BLL;
using MyCircles.DAL;
using MyCircles.DAL.Joint_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class Calendar : System.Web.UI.Page
    {
        public string hello = "5 Feb, 6 Feb";
        protected void Page_Load(object sender, EventArgs e)
        {
            lbDate.Text = hello;
        }

        private void GetExistingCalendar()
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            DayByDay getByTag = new DayByDay();
            List<DayByDay> daybydayList = new List<DayByDay>();
            daybydayList = getByTag.RetrieveByItinerary(Id);
        }
    }
}