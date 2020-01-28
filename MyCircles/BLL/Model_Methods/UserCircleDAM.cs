using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCircles.BLL
{
    [MetadataType(typeof(UserCircleMetadata))]
    public partial class UserCircle 
    {
        public UserCircle()
        {

        }
    }

    [Serializable]
    public class UserCircleMetadata
    {
        [field: NonSerialized]
        public int Id { get; set; }

        [field: NonSerialized]
        public int UserId { get; set; }

        [Required]
        [StringLength(64)]
        [field: NonSerialized]
        public string CircleId { get; set; }

        [field: NonSerialized]
        public int Points { get; set; }

        [field: NonSerialized]
        public virtual Circle Circle { get; set; }

        [field: NonSerialized]
        public virtual User User { get; set; }
    }
}