using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class EventDAO
    {
        public static Event GetEvent(int eventId)
        {
            Event eventList = new Event();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                eventList = db.Events.Where(event1 => event1.eventId == eventId).FirstOrDefault();
                return eventList;
            }
        }

        public static List<Event> GetAllEvent()
        {
            List<Event> eventList = new List<Event>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                eventList = db.Events.ToList();
                return eventList;
            }
        }

        public static void AddNewEvent(Event eventData)
        {
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                db.Events.Add(eventData);

                db.SaveChanges();
            }
        }

        public static List<Event> GetAllEventCreatedByUser(int userId)
        {
            List<Event> eventList = new List<Event>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                eventList = db.Events.Where(event1 => event1.eventHolderId == userId).ToList();
                return eventList;
            }
        }

    }
}