namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DayByDay")]
    public partial class DayByDay
    {
        public int dayBydayId { get; set; }

        public int itineraryId { get; set; }

        [Required]
        [StringLength(10)]
        public string date { get; set; }

        [Required]
        [StringLength(10)]
        public string timeStamp { get; set; }

        public int activityId { get; set; }

        public virtual Itinerary Itinerary { get; set; }

        public virtual Location Location { get; set; }
    }
}
