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
            SignUpEventDetails = new HashSet<SignUpEventDetail>();
        }

        public int eventId { get; set; }

        [StringLength(50)]
        public string eventName { get; set; }

        [StringLength(50)]
        public string eventDescription { get; set; }

        [StringLength(50)]
        public string eventStartDate { get; set; }

        [StringLength(50)]
        public string eventEndDate { get; set; }

        [StringLength(50)]
        public string eventCategory { get; set; }

        [StringLength(50)]
        public string eventHolderName { get; set; }

        public string eventImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SignUpEventDetail> SignUpEventDetails { get; set; }
    }
}
