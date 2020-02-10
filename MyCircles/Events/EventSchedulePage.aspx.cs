using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;
using static MyCircles.DAL.UserDAO;
using MyCircles.DAL;

namespace MyCircles.Events
{
    public partial class EventSchedulePage : System.Web.UI.Page
    {
        public int currentEventId;
        protected void Page_Load(object sender, EventArgs e)
        {
            int requestedEventId = int.Parse(Request.QueryString["eventID"]);
            currentEventId = requestedEventId;
            System.Diagnostics.Debug.WriteLine("gh say hello: " + requestedEventId);

            refreshGv();
        }

        protected void submitButt_Click(object sender, EventArgs e)
        {
            EventSchedule addNeweventScheduleData = new EventSchedule();
            
            addNeweventScheduleData.startTime = startTimeDLL.Text;
            addNeweventScheduleData.endTime = endTimeDLL.Text;
            addNeweventScheduleData.startDate = startDateTB.Text;
            addNeweventScheduleData.endDate = endDateTB.Text;
            addNeweventScheduleData.eventActivity = eventNameEventTBSchedule.Text;
            addNeweventScheduleData.eventDescription = eventDescriptionTBEventSchedule.Text;
            addNeweventScheduleData.eventId = currentEventId;
            addNeweventScheduleData.AddNewEventSchedule();

            refreshGv();
        }

        public void refreshGv()
        {
            List<BLL.EventSchedule> eventSchedule = DAL.EventScheduleDAO.getAllEventActivity(currentEventId);

            eventScheduleDatagv.DataSource = eventSchedule;
            eventScheduleDatagv.DataBind();
        }


    }
}