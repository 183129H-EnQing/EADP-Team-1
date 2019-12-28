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
        [StringLength(10)]
        public string Type { get; set; }

        [StringLength(20)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
