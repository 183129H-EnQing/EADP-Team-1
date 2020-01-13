namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int eventId { get; set; }

        [StringLength(50)]
        public string eventName { get; set; }

        [StringLength(50)]
        public string eventDescription { get; set; }

        [StringLength(50)]
        public string eventStartDate { get; set; }

        [StringLength(50)]
        public string eventEndDate { get; set; }
    }
}
