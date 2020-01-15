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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dayByDayId { get; set; }

        [Required]
        [StringLength(10)]
        public string timeStamp { get; set; }

        public int activityId { get; set; }
    }
}
