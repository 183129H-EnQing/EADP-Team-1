namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventSchedule")]
    public partial class EventSchedule
    {
        public int eventScheduleID { get; set; }

        [StringLength(50)]
        public string eventDescription { get; set; }

        [StringLength(10)]
        public string startDate { get; set; }

        [StringLength(10)]
        public string startTime { get; set; }

        [StringLength(10)]
        public string endTime { get; set; }

        [StringLength(10)]
        public string endDate { get; set; }

        public string eventActivity { get; set; }

        public int? eventId { get; set; }

        public string usersOptIn { get; set; }
    }
}
