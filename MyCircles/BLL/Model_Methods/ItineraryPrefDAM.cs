using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class ItineraryPref
    {
        public void AddItineraryPref()
        {
            ItineraryPrefDAO.ItineraryPref(this);
        }
    }
}