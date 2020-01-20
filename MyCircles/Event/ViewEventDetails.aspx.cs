using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;
namespace MyCircles
{
    public partial class ViewEventDetails1 : System.Web.UI.Page
    {
        public Event event1;
        public List<EventSchedule> eventSchedule;
        // public BLL.Event event1 = 
        // List<String> means the list inside must be string ,List<EventSchedule> means the list must be include EventSchedule fields in table 
        // List<String> scheduleList = new List<String>();
        public int count;
        protected void Page_Load(object sender, EventArgs e)
        {
            int requestedEventId = int.Parse(Request.QueryString["eventID"]);
            // Get event data base on the event id 
            event1 = BLL.Event.GetEvent(requestedEventId);
            // get all Event Schedule data bse on the event id
            // eventSchedule = EventSchedule.getAllEventActivity(event1);
            
            // Get total number of event activity
            getEventScheduleData(requestedEventId);
        }

        // get all the event scheduleData
        private void getEventScheduleData(int event1)
        {
            EventSchedule retrieveEventSchedule = new EventSchedule();
            List<EventSchedule> scheduleList = new List<EventSchedule>();

            scheduleList = EventSchedule.getAllEventActivity(event1);

            scheduleList = EventSchedule.getAllEventActivity(event1);
            System.Diagnostics.Debug.WriteLine("gh say: " + scheduleList);
            rpEventSchedule.DataSource = scheduleList;
            rpEventSchedule.DataBind();
        }
    }
}