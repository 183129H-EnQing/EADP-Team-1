using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class EventScheduleDAO
    {
        public static List<EventSchedule> getAllEventActivity()
        {
            List<EventSchedule> EventScheduleList = new List<EventSchedule>();

            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                // EventScheduleList = db.EventSchedules.Where(i => i)
                EventScheduleList = db.EventSchedules.ToList();

                return EventScheduleList;
            }

        }
    }
}