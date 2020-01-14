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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int prefId { get; set; }

        [Required]
        [StringLength(10)]
        public string prefName { get; set; }
    }
}
