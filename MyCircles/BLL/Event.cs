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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            EventSchedules = new HashSet<EventSchedule>();
            SignUpEventDetails = new HashSet<SignUpEventDetail>();
        }

        public int eventId { get; set; }

        [StringLength(50)]
        public string eventName { get; set; }

        [StringLength(50)]
        public string eventDescription { get; set; }

        [StringLength(50)]
        public string eventStartTime { get; set; }

        [StringLength(50)]
        public string eventEndTime { get; set; }

        [StringLength(50)]
        public string eventStartDate { get; set; }

        [StringLength(50)]
        public string eventEndDate { get; set; }

        [StringLength(50)]
        public string eventCategory { get; set; }

        [StringLength(50)]
        public string eventHolderName { get; set; }

        public int? eventHolderId { get; set; }

        public string eventImage { get; set; }

        [StringLength(10)]
        public string eventMaxSlot { get; set; }

        [StringLength(20)]
        public string eventEntryFeesStatus { get; set; }

        [StringLength(20)]
        public string eventStatus { get; set; }

        [StringLength(20)]
        public string singleOrRecurring { get; set; }

        [StringLength(10)]
        public string maxTimeAPersonCanRegister { get; set; }

        [StringLength(50)]
        public string eventLocation { get; set; }

        [StringLength(10)]
        public string eventTicketCost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventSchedule> EventSchedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SignUpEventDetail> SignUpEventDetails { get; set; }

        public virtual User User { get; set; }
    }
}
