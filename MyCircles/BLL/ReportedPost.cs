namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportedPost
    {
        public int Id { get; set; }

        [Required]
        public string reason { get; set; }

        public int postId { get; set; }

        public int reporterUserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateCreated { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
