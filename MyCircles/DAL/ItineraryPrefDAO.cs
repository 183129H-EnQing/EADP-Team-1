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
    }
}