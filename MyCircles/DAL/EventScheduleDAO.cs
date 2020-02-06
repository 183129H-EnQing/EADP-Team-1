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
        public static void AddAndUpdateUserOptIn(string selectedEventToParticipate,int userId)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {

                //System.Diagnostics.Debug.WriteLine(selectedEventToParticipate);
                // IsNullOrWhiteSpace remove the blank space beceause we did "value" + "," so we can get each value by spliting ,
                // so the last element will be blank because of our + "," . example,  1 , ???   the question mark means blank, 
                // if we never use IsNullOrWhiteSpace then the string array count will be 2 , if we use then it would be 1 only :O
                var selectedEventArray = selectedEventToParticipate.Split(',').Where(x=> !string.IsNullOrWhiteSpace(x)).ToList();
                System.Diagnostics.Debug.WriteLine(selectedEventArray.Count());
                foreach (string x in selectedEventArray)
                {
                    System.Diagnostics.Debug.WriteLine(x);
                    // es means event schedule
                    int eventScheduleId = Int32.Parse(x);
                    EventSchedule eventSchedule = db.EventSchedules.Where(es => es.eventScheduleID == eventScheduleId).FirstOrDefault();

                    eventSchedule.usersOptIn += userId + ",";
                    db.SaveChanges();
                }

            }
        }


        //public static void UpdateIsEventHost(int id, bool isEventHost)
        //{
        //    using (MyCirclesEntityModel db = new MyCirclesEntityModel())
        //    {
        //        User user = db.Users
        //                .Where(u => u.Id == id)
        //                .FirstOrDefault();

        //        user.IsEventHolder = isEventHost;

        //        db.SaveChanges();
        //    }
        //}

    }
}