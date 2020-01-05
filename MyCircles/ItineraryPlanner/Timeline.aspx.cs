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
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SomeText");

            string startDate = (string)Session["startDate"];
            string sDate = startDate.Substring(3, 2);
            string sMonth = startDate.Substring(0,2);

            IDictionary<int, string> monthDict = new Dictionary<int, string>()
            {
                {1, "Jan" }, {2, "Feb" }, {3, "Mar" }, {4, "Apr" }, {5, "May" }, {6, "Jun" },
                {7, "Jul" }, {8, "Aug" }, {9, "Sep" }, {10, "Oct" }, {11, "Nov" }, {12, "Dec" }
            };
            string strMonth;
            if (monthDict.TryGetValue(int.Parse(sMonth), out strMonth)){
                lbMonth.Text = strMonth;
            }
        }
    }
}