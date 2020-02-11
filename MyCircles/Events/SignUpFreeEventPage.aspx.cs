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


            //if (String.IsNullOrEmpty(NumberOfBookingSlotsTB.Text))
            //{
            //    GeneralHelpers.AddValidationError(Page, "registerEvent", "Booking Slot Amount is empty");
            //}

            if (NumberOfBookingSlotsDLL.Text == "Please Select Number of Slots")
            {
                GeneralHelpers.AddValidationError(Page, "registerEvent", "Please select numbers only");
            }


            if (!Page.IsValid)
            {
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators);
            }
            else
            {
                newEventSignUpEventData.name = nameTB.Text;
                newEventSignUpEventData.contactNumber = contactNumberTB.Text;
                currentUser = (BLL.User)Session["currentUser"];
                newEventSignUpEventData.userId = currentUser.Id;

                System.Diagnostics.Debug.WriteLine("gh say hello: " + NumberOfBookingSlotsDLL.Text);
                if (NumberOfBookingSlotsDLL.Text != "")
                {
                    newEventSignUpEventData.numberOfBookingSlot = NumberOfBookingSlotsDLL.Text;
                }
                else
                {
                    newEventSignUpEventData.numberOfBookingSlot = NumberOfBookingSlotsTB.Text;
                }
                newEventSignUpEventData.selectedEventToParticipate = selectedEventToParticipate;
                newEventSignUpEventData.eventId = currentEventID;
                newEventSignUpEventData.date = dateDDL.Text;
                //  System.Diagnostics.Debug.WriteLine(String.Join("\n", userOptInEvent));
                //System.Diagnostics.Debug.WriteLine(currentUser.Name);

                //System.Diagnostics.Debug.WriteLine("gh say hello: " + NumberOfBookingSlotsDLL.Text);
                newEventSignUpEventData.Add();
                eventSchedule.AddAndUpdateUserOptIn(selectedEventToParticipate, currentUser.Id);
                var ticketPrice = singleEventDetails.eventTicketCost;

                Response.Redirect("ViewAllEventPage.aspx");
            }
     
        }

        public void GetDates()
        {
            DateTime startDate;
            DateTime endDate;
            DateTime startDateTemp;
            List<String> datesList = new List<String>();

            DateTime.TryParse(singleEventDetails.eventStartDate, out startDate);
            DateTime.TryParse(singleEventDetails.eventEndDate, out endDate);
            DateTime.TryParse(singleEventDetails.eventEndDate, out startDateTemp);

            System.Diagnostics.Debug.WriteLine(startDate + " " +endDate);
            if (startDate == endDate)
            {
                //System.Diagnostics.Debug.WriteLine("gh say:11 " + (startDate - endDate).TotalDays);
                datesList.Add(startDate.ToShortDateString().ToString());
            }
            else
            {
                var dateDifference = (endDate - startDate).TotalDays;
               // System.Diagnostics.Debug.WriteLine("hello world:" + dateDifference);
                for (var i = 0; i <= (endDate - startDate).TotalDays;i++)
                {
                    DateTime newstartDate;
                    newstartDate = startDate.AddDays(i);
                    //System.Diagnostics.Debug.WriteLine("startDate: " +startDate);
                    datesList.Add(newstartDate.ToShortDateString().ToString());
 
                }
            }


            dateDDL.DataSource = datesList;
            dateDDL.DataBind();

        }

        // get all the event scheduleData function << planning to reuse the code if can
        private void getEventScheduleData(int eventId)
        {
            EventSchedule retrieveEventSchedule = new EventSchedule();
            List<EventSchedule> scheduleList = new List<EventSchedule>();

            scheduleList = retrieveEventSchedule.getAllEventActivity(eventId);

            //System.Diagnostics.Debug.WriteLine(scheduleList);
            rpEventSchedule.DataSource = scheduleList;
        
        }

        private void getNumberOfSlots()
        {
            if (singleEventDetails.maxTimeAPersonCanRegister != "No Limit")
            {
                int maxSlot = System.Convert.ToInt16(singleEventDetails.maxTimeAPersonCanRegister);
                List<String> slotList = new List<String>();
                slotList.Add("Please Select Number of Slots");
                for (var x = 1; x < maxSlot + 1; x++)
                {
                    var avaliableSlotOption = x.ToString();
                    slotList.Add(avaliableSlotOption);
                }
                NumberOfBookingSlotsDLL.DataSource = slotList;
                NumberOfBookingSlotsDLL.DataBind();
                //System.Diagnostics.Debug.WriteLine(String.Join("\n", slotList));
            }
            else
            {

            }
        }
   
    }
}