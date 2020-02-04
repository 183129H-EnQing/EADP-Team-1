using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;
namespace MyCircles
{
    public partial class ViewEventDetails : System.Web.UI.Page
    {
        public Event singleEventDetails;
        public List<EventSchedule> eventSchedule;
        // public BLL.Event event1 = 
        // List<String> means the list inside must be string ,List<EventSchedule> means the list must be include EventSchedule fields in table 
        // List<String> scheduleList = new List<String>();
        public int count;
        protected void Page_Load(object sender, EventArgs e)
        {
            int requestedEventId = int.Parse(Request.QueryString["eventID"]);
            // Get single Event Details from the db 
            singleEventDetails = BLL.Event.GetEvent(requestedEventId);

            // Get all event schedule data base on id
            getEventScheduleData(requestedEventId);
        }

        // get all the event scheduleData function
        private void getEventScheduleData(int eventId)
        {
            EventSchedule retrieveEventSchedule = new EventSchedule();
            List<EventSchedule> scheduleList = new List<EventSchedule>();
            
            scheduleList = retrieveEventSchedule.getAllEventActivity(eventId);

            System.Diagnostics.Debug.WriteLine("gh say: " + scheduleList);
            rpEventSchedule.DataSource = scheduleList;
            rpEventSchedule.DataBind();
        }
    }
}