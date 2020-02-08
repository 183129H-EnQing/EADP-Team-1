using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL.Joint_Models
{
    public class DayLocation
    {
        public int dayId { get; set; }
        public string date { get; set; }
        public int itineraryId { get; set; }
        public int locationId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string notes { get; set; }


        //public int locaId { get; set; }
        public int landmarkType { get; set; }
        public string locaPic { get; set; }
        public string locaName { get; set; }
        public string locaDesc { get; set; }
        public decimal locaRating { get; set; }
        public string locaContact { get; set; }
        public string locaWeb { get; set; }
        public string locaOpenHour { get; set; }
        public string locaCloseHour { get; set; }

        public DayLocation(Day d, Location l)
        {
            this.dayId = d.dayId;
            this.date = d.date;
            this.itineraryId = d.itineraryId;
            this.locationId = d.locationId;
            this.startTime = d.startTime;
            this.endTime = d.endTime;
            this.notes = d.notes;

            landmarkType = l.landmarkType;
            locaPic = l.locaPic;
            locaName = l.locaName;
            locaDesc = l.locaDesc;
            locaRating = l.locaRating;
            locaContact = l.locaContact;
            locaWeb = l.locaWeb;
            locaOpenHour = l.locaOpenHour;
            locaCloseHour = l.locaCloseHour;
        }
    }
}