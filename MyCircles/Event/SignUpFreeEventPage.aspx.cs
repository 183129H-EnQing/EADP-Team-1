using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;

namespace MyCircles
{
    public partial class SignUpFreeEventPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           //GetDates();
        }

        protected void submitButt_Click(object sender, EventArgs e)
        {
            SignUpEventDetail newEventSignUpEventData = new SignUpEventDetail();

            newEventSignUpEventData.name = nameTB.Text;
            newEventSignUpEventData.contactNumber = contactNumberTB.Text;
            //newEventSignUpEventData.date = "hello";
            newEventSignUpEventData.numberOfBookingSlot = "1";

            newEventSignUpEventData.Add();
            Response.Redirect("ViewAllEventPage.aspx");
        }

        public List<EventSchedule> GetDates()
        {
            EventSchedule eventSchedule = new EventSchedule();
            List<EventSchedule> scheduleList = new List<EventSchedule>();
            //scheduleList = eventSchedule.getAllEventActivity();

            List<String> datesList = new List<String>();
            foreach (EventSchedule eventScheduleBB in scheduleList)
            {
                System.Diagnostics.Debug.WriteLine("gh say: " + eventScheduleBB.startDate);
                datesList.Add(eventScheduleBB.startDate);
            }
            dateDDL.DataSource = datesList;
            dateDDL.DataBind();
            return scheduleList;

        }
    }
}