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
        public int itineraryId { get; set; }

        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string itineraryName { get; set; }

        [Required]
        [StringLength(15)]
        public string startDate { get; set; }

        [Required]
        [StringLength(15)]
        public string endDate { get; set; }

        [Required]
        [StringLength(3)]
        public string groupSize { get; set; }
    }
}
