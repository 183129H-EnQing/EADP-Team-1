namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItineraryPref")]
    public partial class ItineraryPref
    {
        public int itineraryPrefId { get; set; }

        public int itineraryId { get; set; }

        public int prefId { get; set; }

        public virtual Itinerary Itinerary { get; set; }

        public virtual Pref Pref { get; set; }
    }
}
