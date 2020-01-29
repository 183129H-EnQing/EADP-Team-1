using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCircles.ItineraryPlanner
{
    public partial class Timeline : System.Web.UI.Page
    {
        public string dayStr1;

        Itinerary newItinerary = new Itinerary();
        MyCirclesEntityModel db = new MyCirclesEntityModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SomeText");

            /*if (!GetExisting())
            {
                getMonthDate();
            }*/
            GetExisting();
        }

        private void getMonthDate()
        {
            string startDateMonth= (string)Session["startDate"];
            string sDate = startDateMonth.Substring(3, 2);          
            string sMonth = startDateMonth.Substring(0, 2);      //start month in numbers.. eg 01

            IDictionary<int, string> monthDict = new Dictionary<int, string>()
            {
                {1, "Jan" }, {2, "Feb" }, {3, "Mar" }, {4, "Apr" }, {5, "May" }, {6, "Jun" },
                {7, "Jul" }, {8, "Aug" }, {9, "Sep" }, {10, "Oct" }, {11, "Nov" }, {12, "Dec" }
            };

            string strMonth;                                //start month in string.. eg Jan
            if (monthDict.TryGetValue(int.Parse(sMonth), out strMonth))
            {
                lbMonth.Text = strMonth;                    //set <asp:label> start date
            }

            string endDateMonth = (string)Session["endDate"];
            string eDate = endDateMonth.Substring(3, 2);
            string eMonth = endDateMonth.Substring(0, 2);      //end month in numbers.. eg 01

            List<int> daysList = new List<int>();
            for(var i = int.Parse(sDate) + 1; i < int.Parse(eDate); i++)
            {
                daysList.Add(i);
            }
            string dayStr = String.Join(",", daysList);

            //noOfDate.Value = dayStr;                        //hidden field to contain dates in-between start and end date
            aStartDate.InnerHtml = sDate;                   //set <a> start
            aEndDate.InnerHtml = eDate;                     //set <a> end
            dayStr1 = dayStr;                               //public var dayStr1 accessed by javascript directly

            string erMonth;                                //end month in string.. eg Jan
            if (monthDict.TryGetValue(int.Parse(eMonth), out erMonth))
            {
                //lbMonth.Text = strMonth;
            }

        }

        private void GetExisting()
        {
            //lbPlannerName.Text = Request.QueryString["Id"];
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            Itinerary retrieveSpecificItinerary = new Itinerary();
            List<Itinerary> itineraryList = new List<Itinerary>();

            itineraryList = retrieveSpecificItinerary.RetrieveSpecificItinerary(Id);

            //rpItinerary.DataSource = itineraryList;
            //rpItinerary.DataBind();

            //create dates in .aspx from db
            DayByDay getByTag = new DayByDay();
            List<DayByDay> daysList = new List<DayByDay>();
            daysList = getByTag.RetrieveByItinerary(Id);

            rpDates.DataSource = daysList;
            rpDates.DataBind();

            //set dates with locations
            //GetPlanDetails();
        }

        private void GetPlanDetails()
        {
            lbMonth.Text = Session["prefB"].ToString();
        }

        /*public static string EvalTrimmed(this RepeaterItem container, string expression, int maxLength)
        { 
            string value = DataBinder.Eval(container, expression) as string;
            if ( value != null ) 
               return null;
            if (value.Length > maxlength)
               value = value.Substring(0,maxLength) + "...";
            return value;
        }*/

        private void AddDateToDB()
        {
            string startDateMonth = (string)Session["startDate"];
            string sDate = startDateMonth.Substring(0, 2);
            string sMonth = startDateMonth.Substring(4, 3);      //start month .. eg Jan

            string endDateMonth = (string)Session["endDate"];
            string eDate = endDateMonth.Substring(0, 2);
            string eMonth = endDateMonth.Substring(4, 3);      //end month .. eg Jan

            //rmb add startdate to db
            List<int> datesList = new List<int>();
            for (var i = int.Parse(sDate) + 1; i < int.Parse(eDate); i++)
            {
                datesList.Add(i);
                //add middle date to db
            }
            //add enddate to db
        }
    }
}