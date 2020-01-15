namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventCategory")]
    public partial class EventCategory
    {
        [Key]
        [Column("eventCategory")]
        public int eventCategory1 { get; set; }

        [StringLength(50)]
        public string categoryName { get; set; }

        [StringLength(50)]
        public string categoryDescription { get; set; }
    }
}
