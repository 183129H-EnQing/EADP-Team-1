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

        // means add user opt in event that is listed in the event schedule
        public static void AddUserOptIn()
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                //   db.EventSchedules.Add(userSignUpDetails);
              //  db.EventSchedules.Where(eventSchedule => eventSchedule.eventId == eventId
             //   && eventSchedule.startTime == startTime

             //   );

                foreach (EventSchedule userOptIn in db.EventSchedules)
                {
                 //   userOptIn.
                }
                db.SaveChanges();
            }
        }

    }
}