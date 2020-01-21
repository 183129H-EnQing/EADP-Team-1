using MyCircles.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class DayByDay
    {
        public void AddDayByDay()
        {
            DayByDayDAO.AddDayByDay(this);
        }
        public List<DayByDay> RetrieveByItinerary(int Id)
        {
            return DayByDayDAO.GetByItinerary(Id);
        }
    }
}