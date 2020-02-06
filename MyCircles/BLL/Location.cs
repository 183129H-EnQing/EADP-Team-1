namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            Days = new HashSet<Day>();
        }

        [Key]
        public int locaId { get; set; }

        public int landmarkType { get; set; }

        [Required]
        public string locaPic { get; set; }

        [Required]
        [StringLength(50)]
        public string locaName { get; set; }

        [Required]
        [StringLength(1000)]
        public string locaDesc { get; set; }

        public decimal locaRating { get; set; }

        [StringLength(50)]
        public string locaAddress { get; set; }

        [StringLength(20)]
        public string locaPostalCode { get; set; }

        [StringLength(15)]
        public string locaContact { get; set; }

        [StringLength(100)]
        public string locaWeb { get; set; }

        [Required]
        [StringLength(10)]
        public string locaOpenHour { get; set; }

        [StringLength(10)]
        public string locaCloseHour { get; set; }

        [Required]
        [StringLength(6)]
        public string locaRecom { get; set; }

        [StringLength(30)]
        public string locaGeolocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Day> Days { get; set; }

        public virtual Pref Pref { get; set; }
    }
}
