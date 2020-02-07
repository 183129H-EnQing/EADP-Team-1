using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class ItineraryPrefDAO
    {
        public static void ItineraryPref(ItineraryPref newPref)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.ItineraryPrefs.Add(newPref);
                db.SaveChanges();
            }
        }

        public static void DeleteItineraryPref(int itineraryId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.ItineraryPrefs.RemoveRange(db.ItineraryPrefs.Where(i => i.itineraryId == itineraryId));
                db.SaveChanges();
            }
        }
    }
}