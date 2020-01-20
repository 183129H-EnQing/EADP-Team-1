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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DayByDay()
        {
            Days = new HashSet<Day>();
        }

        public int dayBydayId { get; set; }

        public int itineraryId { get; set; }

        [Required]
        [StringLength(10)]
        public string date { get; set; }

        public int dayId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Day> Days { get; set; }

        public virtual Itinerary Itinerary { get; set; }
    }
}
