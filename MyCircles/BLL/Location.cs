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
            DayByDays = new HashSet<DayByDay>();
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
        [StringLength(500)]
        public string locaDesc { get; set; }

        public decimal locaRating { get; set; }

        public int? locaContact { get; set; }

        [StringLength(100)]
        public string locaWeb { get; set; }

        [Required]
        [StringLength(10)]
        public string locaOpenHour { get; set; }

        [StringLength(10)]
        public string locaCloseHour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DayByDay> DayByDays { get; set; }

        public virtual Pref Pref { get; set; }
    }
}
