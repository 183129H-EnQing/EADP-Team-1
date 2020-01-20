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
        [Key]
        public int dayId { get; set; }

        public int dayByDayId { get; set; }

        [Required]
        [StringLength(10)]
        public string startTime { get; set; }

        [Required]
        [StringLength(10)]
        public string endTime { get; set; }

        public int locationId { get; set; }
    }
}
