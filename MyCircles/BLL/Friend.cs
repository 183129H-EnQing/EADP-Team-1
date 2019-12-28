namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Friend")]
    public partial class Friend
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int SourceId { get; set; }

        public int RecieverId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
