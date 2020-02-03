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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatRoom()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int User1Id { get; set; }

        public int User2Id { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
