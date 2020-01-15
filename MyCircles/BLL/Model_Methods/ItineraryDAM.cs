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

        public static Itinerary RetrieveItinerary(Itinerary itinerary)
        {
            return ItineraryDAO.GetItinerary(itinerary);
        }
    }
}