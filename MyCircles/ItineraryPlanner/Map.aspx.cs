using MyCircles.BLL;
using MyCircles.DAL;
using MyCircles.DAL.Joint_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace MyCircles.ItineraryPlanner
{
    public class Idk
    {
        //public DayByDay dayByDay;
        public int dayByDayId { get; set; }
        public string date { get; set; }
        public string locations { get; set; }
    }

    public partial class Map : System.Web.UI.Page
    {
        //retrieve location from Days table
        public List<DayLocation> daysList = new List<DayLocation>();

        protected void Page_Load(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            //lbPlannerName.Text = Session["itineraryName"].ToString();

            DayByDay getByTag = new DayByDay();
            List<DayByDay> daybydayList = new List<DayByDay>();
            daybydayList = getByTag.RetrieveByItinerary(Id);

            //rpDates.DataSource = daybydayList;
            //rpDates.DataBind();

            List<Idk> idkList = new List<Idk>();

            foreach (DayByDay dayByDay in daybydayList)
            {
                Idk oneDay = new Idk();
                oneDay.dayByDayId = dayByDay.dayBydayId;
                oneDay.date = dayByDay.date;

                List<Location> locations = new List<Location>();
                foreach (DayLocation day in Day.GetDayAllDayLocation(dayByDay.dayBydayId))
                {
                    Location location = new Location();

                    location.locaLatitude = day.locaLatitude;
                    location.locaLongitude = day.locaLongitude;


                    locations.Add(location);
                }
                oneDay.locations = JsonConvert.SerializeObject(locations);

                idkList.Add(oneDay);
            }

            rpDates.DataSource = idkList;
            rpDates.DataBind();

            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            try
            {
                //have to get daybydayId thru href;
                int daybydayId = int.Parse(Request.QueryString["daybydayId"]);

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

                //rptLocationScript.DataSource = daysList;
                //rptLocationScript.DataBind();
            }
            catch
            {

            }
        }
    }
}