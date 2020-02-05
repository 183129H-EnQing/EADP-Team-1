namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    public partial class UserCircle
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(64)]
        public string CircleId { get; set; }

        public int Points { get; set; }


        [field: NonSerialized]
        public virtual Circle Circle { get; set; }

        [field: NonSerialized]

        public virtual User User { get; set; }
    }
}
