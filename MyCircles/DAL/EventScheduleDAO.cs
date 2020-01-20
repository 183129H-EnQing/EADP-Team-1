using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class EventScheduleDAO
    {
        public static List<EventSchedule> getAllEventActivity(int event1)
        {
            List<EventSchedule> EventScheduleList = new List<EventSchedule>();

            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                EventScheduleList = db.EventSchedules.Where(eventSchedule => eventSchedule.eventId == event1).ToList();
                //EventScheduleList = db.EventSchedules.ToList();

                return EventScheduleList;
            }

        }
    }
}