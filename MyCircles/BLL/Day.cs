namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Day")]
    public partial class Day
    {
        public int dayId { get; set; }

        public DateTime date { get; set; }

        public int dayByDayId { get; set; }

        public int itineraryId { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public int locationId { get; set; }

        public string notes { get; set; }

        public virtual DayByDay DayByDay { get; set; }

        public virtual Location Location { get; set; }
    }
}
