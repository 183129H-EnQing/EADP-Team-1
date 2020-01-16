using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCircles.BLL;

namespace MyCircles
{
    public partial class SignUpFreeEventPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButt_Click(object sender, EventArgs e)
        {
            Event newEventSignUpEventData = new Event();

            newEventSignUpEventData.eventName = "hello";
            newEventSignUpEventData.eventId = 1;
            newEventSignUpEventData.eventDescription = "lol";
            newEventSignUpEventData.eventEndDate = "lol";
            newEventSignUpEventData.eventStartDate = "lol";

            newEventSignUpEventData.Add();
            Response.Redirect("ViewAllEventPage.aspx");
        }
    }
}