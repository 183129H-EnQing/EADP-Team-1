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
        public static List<DayLocation> GetAllDayLocation(int daybydayId)
        {
            //insert parameter for dayID for selective dates??
            using (var db = new MyCirclesEntityModel())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var dayLocation = db.Days
                    .Where(
                        day => day.dayByDayId == daybydayId
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

        public static void DeleteDay(int itineraryId)
        {
            using (var db = new MyCirclesEntityModel())
            {
                db.Days.RemoveRange(db.Days.Where(i => i.itineraryId == itineraryId));
                db.SaveChanges();
            }
        }

        public static void AddDay(Itinerary itinerary)
        {
            using (var db = new MyCirclesEntityModel())
            {
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan endTime = new TimeSpan(21, 0, 0);

                DateTime userDateTime = itinerary.startDate + startTime;
                DateTime endDate = itinerary.endDate + endTime;
                int interval = 30;

                List<Location> locations = db.Locations.ToList();

                foreach (Location location in locations)
                {
                    TimeSpan nextEventFinishTime = userDateTime.AddMinutes(int.Parse(location.locaRecom)).TimeOfDay;

                    if ((nextEventFinishTime > endTime))
                    {
                        userDateTime = userDateTime.AddDays(1);
                        userDateTime = userDateTime.Date + startTime;
                    }

                    if (userDateTime > endDate)
                    {
                        break;
                    }

                    string dayByDayDate = userDateTime.ToString("dd MMM");
                    DayByDay dayByDay = db.DayByDays.Where(i => i.date == dayByDayDate && i.itineraryId == itinerary.itineraryId).FirstOrDefault();

                    Day newDay = new Day();
                    newDay.date = userDateTime;
                    newDay.itineraryId = itinerary.itineraryId;
                    newDay.locationId = location.locaId;
                    newDay.startTime = userDateTime;
                    newDay.dayByDayId = dayByDay.dayBydayId;
                    newDay.endTime = userDateTime.AddMinutes(int.Parse(location.locaRecom));

                    db.Days.Add(newDay);
                    db.SaveChanges();

                    userDateTime = userDateTime.AddMinutes(int.Parse(location.locaRecom));
                    userDateTime = userDateTime.AddMinutes(interval);
                }
            }
        }
    }
}