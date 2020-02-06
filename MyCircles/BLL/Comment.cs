namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public int? PostId { get; set; }

        [StringLength(500)]
        public string comment_text { get; set; }

        [StringLength(50)]
        public string comment_by { get; set; }

        public DateTime? comment_date { get; set; }

        public int UserId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
