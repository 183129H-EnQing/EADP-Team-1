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

        public int dayByDayId { get; set; }

        [Required]
        [StringLength(16)]
        public string startTime { get; set; }

        [Required]
        [StringLength(16)]
        public string endTime { get; set; }

        public int locationId { get; set; }

        public virtual DayByDay DayByDay { get; set; }

        public virtual Location Location { get; set; }
    }
}
