using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public class ItineraryDAO
    {
        public static void AddItinerayDAO(Itinerary newItinerary)
        {
            using(var db = new MyCirclesEntityModel())
            {
                db.Itineraries.Add(newItinerary);
                db.SaveChanges();
            }
        }

        public static Itinerary GetItinerary(Itinerary itinerary, User user)
        {
            Itinerary sItinerary = null;
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                itinerary = db.Itineraries.Where(i => i.itineraryId == itinerary.itineraryId && i.userId == itinerary.userId).FirstOrDefault();
            }
            return sItinerary;
        }
    }
}