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
    public partial class ViewEventPageCreated : System.Web.UI.Page
    {
        public BLL.User currentUser, requestedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            getEventCreatedData();
           
        }

        private void getEventCreatedData()
        {
            currentUser = (BLL.User)Session["currentUser"];
            Event retrieveEventData = new Event();
            List<Event> createdEventDataList = new List<Event>();

            createdEventDataList = retrieveEventData.GetAllEventCreatedByUser(currentUser.Id);

            System.Diagnostics.Debug.WriteLine("gh say: " + currentUser.Id);
            rpViewEventPageCreated.DataSource = createdEventDataList;
            rpViewEventPageCreated.DataBind();
        }


    }
}