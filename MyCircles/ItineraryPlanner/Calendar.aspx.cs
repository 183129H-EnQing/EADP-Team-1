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
        public string location = "hello";
        protected void Page_Load(object sender, EventArgs e)
        {
            lbDate.Text = hello;
        }

        private void GetExistingCalendar()
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            List<DayLocation> daysList = new List<DayLocation>();
            daysList = DayDAO.GetAllDayLocationByItinerary(Id);

            /*List<string> locationList = new List<string>();     //list for passing to asp label
            foreach (var i in daysList)
            {
                locationList.Add(i.locaName.ToString());
                locationList.Add(i.locaOpenHour.ToString());
                locationList.Add(i.locaCloseHour.ToString());
            }*/
            location = daysList.ToString();
        }
    }
}