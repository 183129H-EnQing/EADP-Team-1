namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POST")]
    public partial class POST
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Content { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [Required]
        [StringLength(20)]
        public string Comment { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
