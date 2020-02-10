using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;
using static MyCircles.DAL.UserDAO;

namespace MyCircles.Events
{
    public partial class ViewEventPageRegistered : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;
        public  List<String> userRegisteredEventId;

        public List<String> SelectedEventToPaticipiate = new List<String>();
        public List<String> startTimeList = new List<String>();
        public List<String> EndTimeList = new List<String>();
        public string selectedEventToParticipate;


        // { eventId: startTIme:"", endTime: "", eventDescription:""}
        // 

        // Dictionary<int,List<String>,List<String>,List<String>> = new Dictionary<int, List<String>, List<String>, List<String>>
        protected void Page_Load(object sender, EventArgs e)
        {
            getEventRegisteredData();
            //getSelectedEventToParticipate();
       
        }

        // get the data from event schedule
        //private void getSelectedEventToParticipate()
        //{
        //    currentUser = (BLL.User)Session["currentUser"];
        //    EventSchedule retrieveEventSchedule = new EventSchedule();
        //    List<EventSchedule> eventScheduleList = new List<EventSchedule>();

        //    eventScheduleList = retrieveEventSchedule.GetAllEventRegisteredByUser(currentUser.Id);
        //    // end time will updateds be updated 
        //    foreach (EventSchedule x in eventScheduleList)
        //    {
              
        //        // if user selected the event scheudle event then view all the event selected
        //        // else say Participate All
        //        // if user registered include in the registeredList then we add start time and end time differencely
        //        // else just get the start and end time of the event -> so we need do validation in the html to do that
        //        if (userRegisteredEventId.Contains(x.eventId.ToString())){


        //            startTimeList.Add(x.startTime);
        //            EndTimeList.Add(x.endTime);
        //            SelectedEventToPaticipiate.Add(x.eventDescription);
        //        }
        //        else
        //        {
        //            selectedEventToParticipate = "Participate All";
        //            // start time and end time
        //        }
        //    }
        //    System.Diagnostics.Debug.WriteLine("gh say: " + currentUser.Id);
     
        //}

        private void getEventRegisteredData()
        {
            currentUser = (BLL.User)Session["currentUser"];
            SignUpEventDetail retrieveSignUpEventDetails = new SignUpEventDetail();
            List<SignUpEventDetail> userSignUpEventDetail = new List<SignUpEventDetail>();
            List<String> registeredEventId = new List<String>();

            userSignUpEventDetail = retrieveSignUpEventDetails.getUserSignUpEventDetails(currentUser.Id);

            foreach(SignUpEventDetail x in userSignUpEventDetail)
            {
                registeredEventId.Add(x.eventId.ToString());
            }
            userRegisteredEventId = registeredEventId;

            rpViewEventPageRegistered.DataSource = userSignUpEventDetail;
            rpViewEventPageRegistered.DataBind();

        }
    }
}