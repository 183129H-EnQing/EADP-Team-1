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
            SignUpEventDetail newEventSignUpEventData = new SignUpEventDetail();

            newEventSignUpEventData.name = "hello";
            newEventSignUpEventData.contactNumber = "lol";
            newEventSignUpEventData.date = System.Convert.ToDateTime("lol");
            newEventSignUpEventData.numberOfBookingSlot = "1";

            newEventSignUpEventData.Add();
            Response.Redirect("ViewAllEventPage.aspx");
        }
    }
}