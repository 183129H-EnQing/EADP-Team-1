namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChatRoom")]
    public partial class ChatRoom
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int User1Id { get; set; }

        public int User2Id { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
