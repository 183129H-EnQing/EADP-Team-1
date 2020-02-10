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
    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            lbPlannerName.Text = Session["itineraryName"].ToString();

            DayByDay getByTag = new DayByDay();
            List<DayByDay> daybydayList = new List<DayByDay>();
            daybydayList = getByTag.RetrieveByItinerary(Id);

            rpDates.DataSource = daybydayList;
            rpDates.DataBind();

            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            try
            {
                //have to get daybydayId thru href;
                int daybydayId = int.Parse(Request.QueryString["daybydayId"]);

                //retrieve location from Days table
                List<DayLocation> daysList = new List<DayLocation>();

                daysList = DayDAO.GetAllDayLocation(daybydayId);

                var date = "";
                var count = 0;
                foreach (var i in daysList)
                {
                    count += 1;
                    if (count == 1)
                    {
                        url += "?lat=" + count + i.locaLatitude + "?lon=" + count + i.locaLongitude;
                    }
                    else if (i.date.ToString() == date)
                    {
                        url += "?lat=" + count + i.locaLatitude + "?lon=" + count + i.locaLongitude;
                    }
                    else
                    {
                        date = i.date.ToString();
                        url += "?date=" + date + "?lat=" + count + i.locaLatitude + "?lon=" + count + i.locaLongitude;
                    }
                }
            }
            catch
            {

            }
        }
    }
}