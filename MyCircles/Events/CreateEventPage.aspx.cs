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
    public partial class CreateEventPage : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;
        public BLL.Circle circleData;
        protected void Page_Load(object sender, EventArgs e)
        {
            LocationDLL.Attributes["onChange"] = "hideOrShowExtraTB(this.value)";
            entryFeeStatusDDL.Attributes["onChange"] = "hideOrShowExtraTB(this.value)";
            maxTimeAPersonCanRegisterDLL.Attributes["onChange"] = "hideOrShowExtraTB(this.value)";
            maxSlotAvaliableDDL.Attributes["onChange"] = "hideOrShowExtraTB(this.value)";

            getAllCircleData();
        }

        protected void eventScheduleDataAddTB(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("hello world testing");
        }
        protected void submitButt_Click(object sender, EventArgs e)
        {  
            Event newEventData = new Event();
            EventSchedule eventSchedule = new EventSchedule();
            currentUser = (BLL.User)Session["currentUser"];
            signedOutErrorContainer.Visible = false;


            if (String.IsNullOrEmpty(eventTitleTB.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "Event Title not filled up under basic info!");
            }

            if (String.IsNullOrEmpty(eventDescriptionTB.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "Event Title not filled up under basic info!");
            }

            if (String.IsNullOrEmpty(CategoryDropDownList.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "Category not selected!");
            }

            if (String.IsNullOrEmpty(organizerTB.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "Orgainzer not filled up under basic info");
            }

            if(LocationDLL.Text == "Venue")
            {
                if (String.IsNullOrEmpty(LocationTB.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Venue place not filled up under Location");
                }
            }
            else
            {
                if (String.IsNullOrEmpty(LocationDLL.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Don't itchy hand delete the values from f12");
                }
            }

            if (String.IsNullOrEmpty(startDateTB.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "Start Date not filled up under Date And Time");
            }

            if (String.IsNullOrEmpty(endDateTB.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "End Date nor filled up under Date And Time");
            }

            if (String.IsNullOrEmpty(startTimeDLL.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "Start Date nor filled up under Date And Time");
            }

            if (String.IsNullOrEmpty(endTimeDLL.Text))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "Start Date nor filled up under Date And Time");
            }

            DateTime startDate;
            DateTime endDate;

            DateTime.TryParse(startDateTB.Text,out startDate);
            DateTime.TryParse(endDateTB.Text, out endDate);

            string startTime = startTimeDLL.Text;
            string endTime = endTimeDLL.Text;

            string startTimeHour = startTime.Substring(0, 2);
            string startTimeMinutes = startTime.Substring(2, 2);
            string endTimeHour = endTime.Substring(0, 2);
            string endTimeMinutes = endTime.Substring(2, 2);


            if (startDate > endDate)
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "why start date later than end date?");
            }
            else
            {
                if(startDate == endDate)
                {
                    if (Int32.Parse(startTimeHour) > Int32.Parse(endTimeHour))
                    {
                        GeneralHelpers.AddValidationError(Page, "addEvent", "Start Time cannot be Later than End Time Since Date is the same");
                    }
                }
          
            }

            if (entryFeeStatusDDL.Text == "Not Free")
            {
                if (String.IsNullOrEmpty(entryFeeTB.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Entry Fee not filled up under Details");
                }
            }
            else
            {
                if (String.IsNullOrEmpty(entryFeeStatusDDL.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Don't itchy hand delete the values from f12");
                }
            }

            if (maxTimeAPersonCanRegisterDLL.Text == "Limit")
            {
                if (String.IsNullOrEmpty(maxTimeAPersonCanRegisterTB.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Max Time A Person Can Register not filled up under Details");
                }
            }
            else
            {
                if (String.IsNullOrEmpty(maxTimeAPersonCanRegisterDLL.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Don't itchy hand delete the values from f12");
                }
            }

            if (maxSlotAvaliableDDL.Text == "Limit")
            {
                if (String.IsNullOrEmpty(maxSlotTB.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Max Time A Person Can Register not filled up under Details");
                }
            }
            else
            {
                if (String.IsNullOrEmpty(maxSlotAvaliableDDL.Text))
                {
                    GeneralHelpers.AddValidationError(Page, "addEvent", "Don't itchy hand delete the values from f12");
                }
            }

            if (!(imageUpload.HasFile && (imageUpload.PostedFile.ContentType == "image/jpeg" || imageUpload.PostedFile.ContentType == "image/jpeg" || imageUpload.PostedFile.ContentType == "image/png")))
            {
                GeneralHelpers.AddValidationError(Page, "addEvent", "File empty or upload wrong format");
            }

            if (!Page.IsValid)
            {
                signedOutErrorContainer.Visible = true;
                lbErrorMsg.Text = GeneralHelpers.GetFirstValidationError(Page.Validators);
            }
            else
            {
                newEventData.eventName = eventTitleTB.Text;
                newEventData.eventDescription = eventDescriptionTB.Text;
                newEventData.eventCategory = CategoryDropDownList.Text;              
                newEventData.eventHolderName = organizerTB.Text;
                newEventData.eventHolderId = currentUser.Id;
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
                //System.Diagnostics.Debug.WriteLine("hello world testing",imagePath);
                newEventData.eventImage = imagePath;

                newEventData.eventStatus = "onGoing";

                if (singleEventRadioButton.Checked)
                {
                    newEventData.singleOrRecurring = "Single";
                }

                if (entryFeeStatusDDL.Text == "Free")
                {
                    newEventData.eventTicketCost = "$0.00";
                }
                else
                {
                    newEventData.eventTicketCost = "$" + entryFeeTB.Text;
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

                UserCircleDAO.ChangeUserCirclePoints(currentUser.Id, CategoryDropDownList.Text, 20, "Creating An Event",true);
                Event newCreatedEvt = newEventData.AddNewEvent();

                Response.Redirect("EventSchedulePage.aspx?eventID=" + newCreatedEvt.eventId);
            }


        }


        private void getAllCircleData()
        {
            Circle retrieveAllCircleData = new Circle();
            List<Circle> allCircleData = new List<Circle>();
            List<String> circleDataList = new List<String>();

            allCircleData = CircleDAO.GetAllCircles();
            foreach (Circle singleCircleData in allCircleData)
            {
                circleDataList.Add(singleCircleData.Id);
            }
            System.Diagnostics.Debug.WriteLine("hello world testing", circleDataList);
            CategoryDropDownList.DataSource = circleDataList;
            CategoryDropDownList.DataBind();

        }
    }

}