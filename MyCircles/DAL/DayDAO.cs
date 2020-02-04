using MyCircles.BLL;
using MyCircles.DAL.Joint_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL
{
    public static class DayDAO
    {
        public static List<DayLocation> GetAllDayLocationByItinerary(int Id)
        {
            //insert parameter for dayID for selective dates??
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var dayLocation = db.Days
                    .Where(
                        day => day.itineraryId == Id
                    )
                    .ToList()
                    .Join(
                        db.Locations,
                        daysLocationId => daysLocationId.locationId,
                        locationId => locationId.locaId,
                        (daysLocationId, locationId) => new DayLocation(daysLocationId, locationId)
                    )
                    .ToList();

                return dayLocation;
            }
        }
    }
}