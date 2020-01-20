using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL.Joint_Models
{
    public class Days
    {
        public Day Day { get; set; }
        public DayByDay DayByDay { get; set; }

        public Days(Day day, DayByDay daybyday)
        {
            this.Day = day;
            this.DayByDay = daybyday;
        }
    }
}