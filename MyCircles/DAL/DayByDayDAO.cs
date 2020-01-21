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
    }
}