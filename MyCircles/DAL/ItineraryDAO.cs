using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class ItineraryDAO
    {
        public static Itinerary AddItinerayDAO(Itinerary newItinerary)
        {
            using(var db = new MyCirclesEntityModel())
            {
                Itinerary itinerary;
                itinerary = db.Itineraries.Add(newItinerary);
                db.SaveChanges();
                return itinerary;
            }
        }

        public static List<Itinerary> GetUserItinerary(User user)
        {
            List<Itinerary> itineraryList = new List<Itinerary>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                itineraryList = db.Itineraries.Where(i => i.userId == user.Id).ToList();
                return itineraryList;
            }
        }

        public static List<Itinerary> GetSpecificItinerary(int itineraryId)
        {
            List<Itinerary> itineraryList = new List<Itinerary>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                itineraryList = db.Itineraries.Where(i => i.itineraryId == itineraryId).ToList();
                return itineraryList;
            }
        }
    }
}