using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MyCircles.BLL;
using static MyCircles.DAL.UserDAO;
namespace MyCircles.Events
{
    public partial class SignUpFreeEventPage : System.Web.UI.Page
    {
        public int currentEventID;
        public BLL.User currentUser, requestedUser;
        public Event singleEventDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
        
            int requestedEventID = int.Parse(Request.QueryString["eventID"]);
            singleEventDetails = BLL.Event.GetEvent(requestedEventID);
            requestedUser = GetUserByIdentifier(Request.QueryString["username"]);
           // nameTB.Text = requestedUser.Name;

            // System.Diagnostics.Debug.WriteLine(requestedEventID);
            getEventScheduleData(requestedEventID);
            currentEventID = requestedEventID;

            // i dk why must put like that then the check box can become true or false one... 
            // online say what sequence of event....
            if (!IsPostBack)
            {
                GetDates();
                getNumberOfSlots();
                rpEventSchedule.DataBind();
               
            }
        }

        protected void submitButt_Click(object sender, EventArgs e)
        {
            SignUpEventDetail newEventSignUpEventData = new SignUpEventDetail();
            EventSchedule eventSchedule = new EventSchedule();
            List<String> userOptInEvent = new List<string>();
            string selectedEventToParticipate = "";
            foreach (Control control in rpEventSchedule.Controls)
            {
                var OptIncheckBox = (CheckBox)control.FindControl("optInCB");
                var eventDescriptionLabel = (Label)control.FindControl("eventDescription");
                var eventScheduleId = (Label)control.FindControl("secretEventSheduleId");
 

                if (OptIncheckBox.Checked)
                {
                    userOptInEvent.Add(eventScheduleId.Text);
                    selectedEventToParticipate += eventScheduleId.Text + ",";
                }      

            }

            newEventSignUpEventData.name = nameTB.Text;
            newEventSignUpEventData.contactNumber = contactNumberTB.Text;
            currentUser = (BLL.User)Session["currentUser"];
            newEventSignUpEventData.userId = currentUser.Id;
            newEventSignUpEventData.numberOfBookingSlot = NumberOfBookingSlotsDLL.SelectedItem.Text;
            newEventSignUpEventData.selectedEventToParticipate = selectedEventToParticipate;
            newEventSignUpEventData.eventId = currentEventID;
            //  System.Diagnostics.Debug.WriteLine(String.Join("\n", userOptInEvent));
            //System.Diagnostics.Debug.WriteLine(currentUser.Name);

            newEventSignUpEventData.Add();
            eventSchedule.AddAndUpdateUserOptIn(selectedEventToParticipate, currentUser.Id);
            //Response.Redirect("ViewAllEventPage.aspx");
        }

        public List<EventSchedule> GetDates()
        {
            EventSchedule eventSchedule = new EventSchedule();
            List<EventSchedule> scheduleList = new List<EventSchedule>();
            var scheduleData = eventSchedule.getAllEventActivity(currentEventID);

            List<String> datesList = new List<String>();
            foreach (EventSchedule eventScheduleBB in scheduleData)
            {
               // System.Diagnostics.Debug.WriteLine("gh say: " + eventScheduleBB.startDate);
               if (datesList.Contains(eventScheduleBB.startDate) == false)
                {
                    datesList.Add(eventScheduleBB.startDate);
                }
               
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

            rpEventSchedule.DataSource = scheduleList;
        
        }

        private void getNumberOfSlots()
        {
            int maxSlot = System.Convert.ToInt16(singleEventDetails.maxTimeAPersonCanRegister);
            List<String> slotList = new List<String>();
        
            for (var x = 1; x < maxSlot + 1; x++)
            {
                var avaliableSlotOption = x.ToString();
                slotList.Add(avaliableSlotOption);
            }
            NumberOfBookingSlotsDLL.DataSource = slotList;
            NumberOfBookingSlotsDLL.DataBind();
            //System.Diagnostics.Debug.WriteLine(String.Join("\n", slotList));
        }
    }
}