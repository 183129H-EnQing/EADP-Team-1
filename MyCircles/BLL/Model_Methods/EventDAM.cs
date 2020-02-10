using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL {    // partial - means the extend the modal
    // EventDAM class name can be changed to the modal name,example event table
    public partial class Event
    {
        public Event AddNewEvent()
        {
            return EventDAO.AddNewEvent(this);
        }

        public static Event GetEvent(int eventId)
        {
            return EventDAO.GetEvent(eventId);
        }


        public static List<Event> GetAllEvent()
        {
            return EventDAO.GetAllEvent();
        }

        public List<Event> GetAllEventCreatedByUser(int userId)
        {
            return EventDAO.GetAllEventCreatedByUser(userId);
        }
    }
}