namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserCircle
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CircleId { get; set; }

        public virtual Circle Circle { get; set; }

        public virtual User User { get; set; }
    }
}
