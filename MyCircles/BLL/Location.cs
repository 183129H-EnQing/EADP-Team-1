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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locaId { get; set; }

        [Required]
        [StringLength(20)]
        public string landmarkType { get; set; }

        [Required]
        public string locaPic { get; set; }

        [Required]
        [StringLength(50)]
        public string locaName { get; set; }

        [Required]
        [StringLength(500)]
        public string locaDesc { get; set; }

        public double locaRating { get; set; }

        public int? locaContact { get; set; }

        [StringLength(100)]
        public string locaWeb { get; set; }
    }
}
