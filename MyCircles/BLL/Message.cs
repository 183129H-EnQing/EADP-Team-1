namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ChatRoomId { get; set; }

        public string Content { get; set; }

        public bool HasGeolocation { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Image { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}
