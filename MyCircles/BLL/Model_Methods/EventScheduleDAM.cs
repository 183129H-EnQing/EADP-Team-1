using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.DAL;

namespace MyCircles.BLL { 

    public partial class EventSchedule
    {
        // get all eventActivity/event from the event schedule
        public List<EventSchedule> getAllEventActivity(int eventId)
        {
            return EventScheduleDAO.getAllEventActivity(eventId);
        }

        public void AddAndUpdateUserOptIn(string selectedEventToParticipate,int userId)
        {
            EventScheduleDAO.AddAndUpdateUserOptIn(selectedEventToParticipate,userId);
        }

    }
}