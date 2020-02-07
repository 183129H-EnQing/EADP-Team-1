namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Type { get; set; }

        [Required]
        [StringLength(128)]
        public string Action { get; set; }

        [Required]
        [StringLength(128)]
        public string Source { get; set; }

        [Column(TypeName = "text")]
        public string AdditionalMessage { get; set; }

        [StringLength(128)]
        public string CallToAction { get; set; }

        [StringLength(128)]
        public string CallToActionLink { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
