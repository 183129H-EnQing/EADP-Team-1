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
        protected void Page_Load(object sender, EventArgs e)
        {
            getEventRegisteredData();
        }

        private void getEventRegisteredData()
        {
            currentUser = (BLL.User)Session["currentUser"];
            EventSchedule retrieveEventSchedule = new EventSchedule();
            List<EventSchedule> eventScheduleList = new List<EventSchedule>();

            eventScheduleList = retrieveEventSchedule.GetAllEventRegisteredByUser(currentUser.Id);

            System.Diagnostics.Debug.WriteLine("gh say: " + currentUser.Id);
            rpViewEventPageRegistered.DataSource = eventScheduleList;
            rpViewEventPageRegistered.DataBind();
        }
    }
}