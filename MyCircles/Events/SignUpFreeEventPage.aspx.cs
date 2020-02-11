using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MyCircles.BLL;
using static MyCircles.DAL.UserDAO;
using PayPal.Api;
using MyCircles.Models;

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
            int bookingQuantity = 0;
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
                    bookingQuantity = Int32.Parse(NumberOfBookingSlotsDLL.Text);
                }
                else
                {
                    newEventSignUpEventData.numberOfBookingSlot = NumberOfBookingSlotsTB.Text;
                    bookingQuantity = Int32.Parse(NumberOfBookingSlotsTB.Text);
                }
                newEventSignUpEventData.selectedEventToParticipate = selectedEventToParticipate;
                newEventSignUpEventData.eventId = currentEventID;
                newEventSignUpEventData.date = dateDDL.Text;
                //  System.Diagnostics.Debug.WriteLine(String.Join("\n", userOptInEvent));
                //System.Diagnostics.Debug.WriteLine(currentUser.Name);

                //System.Diagnostics.Debug.WriteLine("gh say hello: " + NumberOfBookingSlotsDLL.Text);
                newEventSignUpEventData.Add();
                eventSchedule.AddAndUpdateUserOptIn(selectedEventToParticipate, currentUser.Id);

                var totalCost = TotalCost.Text;
              
                if (singleEventDetails.eventEntryFeesStatus == "Free")
                {
                    Response.Redirect("ViewAllEventPage.aspx");
                }
                else
                {
                    goPayPalRoute(bookingQuantity);
                }

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

        private void goPayPalRoute(int bookingQuantity)
        {
            var apiContext = PaypalConfiguration.GetAPIContext();

            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                // ###Items
                // Items within a transaction.
                var itemList = new ItemList()
                {
                    items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "15",
                            quantity = "5",
                            sku = "sku"
                        }
                    }
                };

                // ###Payer
                // A resource representing a Payer that funds a payment
                // Payment Method
                // as `paypal`
                var payer = new Payer() { payment_method = "paypal" };

                // ###Redirect URLS
                // These URLs will determine how the user is redirected from PayPal once they have either approved or canceled the payment.
                var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Events/testing1.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var redirectUrl = baseURI + "guid=" + guid;
                var redirUrls = new RedirectUrls()
                {
                    cancel_url = redirectUrl + "&cancel=true",
                    return_url = redirectUrl
                };

                // ###Details
                // Let's you specify details of a payment amount.
                var details = new Details()
                {
                    tax = "15",
                    shipping = "10",
                    subtotal = "75"
                };

                // ###Amount
                // Let's you specify a payment amount.
                var amount = new Amount()
                {
                    currency = "USD",
                    total = "100.00", // Total must be equal to sum of shipping, tax and subtotal.
                    details = details
                };

                // ###Transaction
                // A transaction defines the contract of a
                // payment - what is the payment for and who
                // is fulfilling it. 
                var transactionList = new List<Transaction>();

                // The Payment creation API requires a list of
                // Transaction; add the created `Transaction`
                // to a List
                transactionList.Add(new Transaction()
                {
                    description = "Transaction description.",
                    invoice_number = Common.GetRandomInvoiceNumber(),
                    amount = amount,
                    item_list = itemList
                });

                // ###Payment
                // A Payment Resource; create one using
                // the above types and intent as `sale` or `authorize`
                var payment = new Payment()
                {
                    intent = "sale",
                    payer = payer,
                    transactions = transactionList,
                    redirect_urls = redirUrls
                };

                // Create a payment using a valid APIContext
                var createdPayment = payment.Create(apiContext);

                // Using the `links` provided by the `createdPayment` object, we can give the user the option to redirect to PayPal to approve the payment.
                var links = createdPayment.links.GetEnumerator();
                while (links.MoveNext())
                {
                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        Response.Redirect(link.href);
                    }
                }
                Session.Add(guid, createdPayment.id);

            }
            else
            {
                var guid = Request.Params["guid"];


                // Using the information from the redirect, setup the payment to execute.
                var paymentId = Session[guid] as string;
                var paymentExecution = new PaymentExecution() { payer_id = payerId };
                var payment = new Payment() { id = paymentId };


                // Execute the payment.
                var executedPayment = payment.Execute(apiContext, paymentExecution);


                // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
            }


        }

    }
}