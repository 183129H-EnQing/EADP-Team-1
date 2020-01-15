using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class ItineraryDAO
    {
        public static void AddItinearay(Itinerary newItinerary)
        {
            using(var db = new MyCirclesEntityModel())
            {


                db.Itineraries.Add(newItinerary);
                db.SaveChanges();
            }
        }
    }
}