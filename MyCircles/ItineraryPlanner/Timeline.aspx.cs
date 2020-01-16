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

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SomeText");

            getMonthDate();
            
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
    }
}