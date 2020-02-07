using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class Itinerary
    {
        public void AddItinerary()
        {
            ItineraryDAO.AddItinerayDAO(this);
        }

        public List<Itinerary> RetrieveItinerary(User user)
        {
            return ItineraryDAO.GetUserItinerary(user);
        }

        public List<Itinerary> RetrieveSpecificItinerary(int itinerary)
        {
            return ItineraryDAO.GetSpecificItinerary(itinerary);

        }

        public static void DeletePlanner(int itineraryId)
        {
            DayDAO.DeleteDay(itineraryId);
            DayByDayDAO.DeleteDayByDay(itineraryId);
            ItineraryDAO.DeleteItinerary(itineraryId);
        }
    }
}