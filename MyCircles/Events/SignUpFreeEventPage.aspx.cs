using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MyCircles.BLL;

namespace MyCircles.Events
{
    public partial class SignUpFreeEventPage : System.Web.UI.Page
    {

        public BLL.User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
        
            int requestedEventID = int.Parse(Request.QueryString["eventID"]);
            getEventScheduleData(requestedEventID);
            // i dk why must put like that then the check box can become true or false one... 
            // online say what sequence of event....
            if (!IsPostBack)
            {
                GetDates();
                rpEventSchedule.DataBind();
               
            }
        }

        protected void submitButt_Click(object sender, EventArgs e)
        {
            SignUpEventDetail newEventSignUpEventData = new SignUpEventDetail();
            EventSchedule eventSchedule = new EventSchedule(); 

            newEventSignUpEventData.name = nameTB.Text;
            newEventSignUpEventData.contactNumber = contactNumberTB.Text;
            //newEventSignUpEventData.date = "hello";

            currentUser = (BLL.User)Session["currentUser"];
            System.Diagnostics.Debug.WriteLine("hello" + currentUser.Id.ToString());
            newEventSignUpEventData.numberOfBookingSlot = "1";
            foreach (Control control in rpEventSchedule.Controls)
            {
                //System.Diagnostics.Debug.WriteLine("hello qing" + control.UniqueID);
                var OptIncheckBox = (CheckBox)control.FindControl("optInCB");
                var eventDescriptionLabel = (Label)control.FindControl("eventDescription");

                System.Diagnostics.Debug.WriteLine(OptIncheckBox.Checked);

                if (OptIncheckBox.Checked)
                {

                }
              
                System.Diagnostics.Debug.WriteLine("hello qing" + eventDescriptionLabel.Text);
            
            }
               
    


            newEventSignUpEventData.Add();
         //   eventSchedule.AddOptIn();
            //Response.Redirect("ViewAllEventPage.aspx");
        }

        public List<EventSchedule> GetDates()
        {
            EventSchedule eventSchedule = new EventSchedule();
            List<EventSchedule> scheduleList = new List<EventSchedule>();
            //scheduleList = eventSchedule.getAllEventActivity();

            List<String> datesList = new List<String>();
            foreach (EventSchedule eventScheduleBB in scheduleList)
            {
               //System.Diagnostics.Debug.WriteLine("gh say: " + eventScheduleBB.startDate);
                datesList.Add(eventScheduleBB.startDate);
            }
            dateDDL.DataSource = datesList;
            dateDDL.DataBind();

            return scheduleList;

        }

        // get all the event scheduleData function << planning to reuse the code if can
        private void getEventScheduleData(int eventId)
        {
            EventSchedule retrieveEventSchedule = new EventSchedule();
            List<EventSchedule> scheduleList = new List<EventSchedule>();

            scheduleList = retrieveEventSchedule.getAllEventActivity(eventId);

            System.Diagnostics.Debug.WriteLine("gh say: " + scheduleList);
            rpEventSchedule.DataSource = scheduleList;
        
        }
    }
}