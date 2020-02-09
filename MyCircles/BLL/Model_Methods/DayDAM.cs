using MyCircles.DAL;
using MyCircles.DAL.Joint_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    public partial class Day
    {
        public static List<DayLocation> GetDayAllDayLocation(int daybydayId)
        {
            return DayDAO.GetAllDayLocation(daybydayId);
        }

        //public void AddDay()
        //{
        //    DayDAO.AddDay(this);
        //}
        public static void UpdateDay(int dayId, string notes)
        {
            DayDAO.UpdateDay(dayId, notes);
        }
    }
}