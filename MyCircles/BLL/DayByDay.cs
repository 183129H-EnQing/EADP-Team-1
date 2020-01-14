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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int itineraryId { get; set; }

        public int dayByDayId { get; set; }

        [Required]
        [StringLength(10)]
        public string date { get; set; }

        [Required]
        [StringLength(10)]
        public string startTime { get; set; }

        [Required]
        [StringLength(10)]
        public string endTime { get; set; }
    }
}
