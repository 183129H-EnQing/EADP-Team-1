namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Itinerary")]
    public partial class Itinerary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Itinerary()
        {
            DayByDays = new HashSet<DayByDay>();
            ItineraryPrefs = new HashSet<ItineraryPref>();
        }

        public int itineraryId { get; set; }

        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string itineraryName { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        [Required]
        [StringLength(3)]
        public string groupSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DayByDay> DayByDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItineraryPref> ItineraryPrefs { get; set; }
    }
}
