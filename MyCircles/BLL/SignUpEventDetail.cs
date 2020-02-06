namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SignUpEventDetail
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string date { get; set; }

        [StringLength(8)]
        public string contactNumber { get; set; }

        [StringLength(10)]
        public string numberOfBookingSlot { get; set; }

        public string selectedEventToParticipate { get; set; }

        public int? eventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
