using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class DayByDayDAO
    {
        public static void AddDayByDay(DayByDay newdaybyday)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.DayByDays.Add(newdaybyday);
                db.SaveChanges();
            }
        }

        public static List<DayByDay> GetByItinerary(int Id)
        {
            List<DayByDay> daybydayList = new List<DayByDay>();
            using (MyCirclesEntityModel db = new MyCirclesEntityModel())
            {
                daybydayList = db.DayByDays.Where(i => i.itineraryId == Id).ToList();
                return daybydayList;
            }
        }
    }
}