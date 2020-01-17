namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pref")]
    public partial class Pref
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pref()
        {
            ItineraryPrefs = new HashSet<ItineraryPref>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int prefId { get; set; }

        [Required]
        [StringLength(20)]
        public string prefName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItineraryPref> ItineraryPrefs { get; set; }
    }
}
