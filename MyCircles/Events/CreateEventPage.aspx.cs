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
    public partial class CreateEventPage : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButt_Click(object sender, EventArgs e)
        {
            Event newEventData = new Event();
            EventSchedule eventSchedule = new EventSchedule();
            List<String> userOptInEvent = new List<string>();
            currentUser = (BLL.User)Session["currentUser"];

            newEventData.eventName = eventTitleTB.Text;
            newEventData.eventCategory = CategoryDropDownList.Text;
            newEventData.eventHolderName = organizerTB.Text;
            newEventData.eventId = currentUser.Id;
            if (LocationDLL.Text == "To Be Announced")
            {
                newEventData.eventLocation = LocationDLL.Text;
            }
            else
            {
                newEventData.eventLocation = LocationTB.Text;
            }
            newEventData.eventLocation = LocationTB.Text;

            newEventData.eventStartDate = startDateTB.Text;
            newEventData.eventEndDate = endDateTB.Text;
            newEventData.eventStartTime = startTimeDLL.Text;
            newEventData.eventEndTime = endTimeDLL.Text;

            newEventData.eventEntryFeesStatus = entryFeeStatusDDL.Text;
            
            var imagePath = GeneralHelpers.UploadFile(imageUpload);
            System.Diagnostics.Debug.WriteLine(imagePath);
            newEventData.eventImage = imagePath;

            if (entryFeeStatusDDL.Text == "Free")
            {
                newEventData.eventTicketCost = "$0.00";
            }
            else
            {
                newEventData.eventTicketCost = "$" + entryFee.Text;
            }
         
            if (maxTimeAPersonCanRegisterDLL.Text == "No Limit")
            {
                newEventData.maxTimeAPersonCanRegister = maxTimeAPersonCanRegisterDLL.Text;
            }
            else
            {
                newEventData.maxTimeAPersonCanRegister = maxTimeAPersonCanRegisterTB.Text;
            }

            if (maxSlotAvaliableDDL.Text == "No Limit")
            {
                newEventData.eventMaxSlot = maxSlotAvaliableDDL.Text;
            }
            else
            {
                newEventData.eventMaxSlot = maxSlotTB.Text;
            }
            
            newEventData.AddNewEvent(); 
            //Response.Redirect("ViewAllEventPage.aspx");
        }
    }

}