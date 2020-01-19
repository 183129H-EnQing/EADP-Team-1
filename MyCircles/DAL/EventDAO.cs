using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCircles.BLL;

namespace MyCircles.DAL
{
    public class EventDAO
    {

        public static List<Event> GetAllEvent()
        {
            List<Event> eventList = new List<Event>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                eventList = db.Events.ToList();
                return eventList;
            }
        }

    }
}