namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int activityId { get; set; }

        [StringLength(50)]
        public string activityName { get; set; }

        public TimeSpan? startTime { get; set; }

        public TimeSpan? endTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int locaId { get; set; }
    }
}
