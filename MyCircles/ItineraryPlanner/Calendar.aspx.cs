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
        public string location = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GetExistingCalendar();
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

            foreach (var i in daysList)
            {
                location += i.locaName + ",";
                location += i.date.ToString("dd MMM") + ",";
                location += i.startTime.ToString("HHmm") + ",";
                location += i.endTime.ToString("HHmm") + ",";
                location += i.locationId;
                location += "|";
            }


            lbLocation.Text = location;
        }
    }
}