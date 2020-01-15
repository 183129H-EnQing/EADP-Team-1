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
        [StringLength(10)]
        public string locaPic { get; set; }

        [Required]
        [StringLength(10)]
        public string locaName { get; set; }

        [Required]
        [StringLength(10)]
        public string locaRating { get; set; }

        [StringLength(10)]
        public string locaContact { get; set; }

        [StringLength(10)]
        public string locaWeb { get; set; }
    }
}
