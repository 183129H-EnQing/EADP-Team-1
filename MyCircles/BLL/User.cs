namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Friends = new HashSet<Friend>();
            Friends1 = new HashSet<Friend>();
            Notifications = new HashSet<Notification>();
            POSTs = new HashSet<POST>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string EmailAddress { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Bio { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProfileImage { get; set; }

        [Column(TypeName = "image")]
        public byte[] HeaderImage { get; set; }

        public bool IsLoggedIn { get; set; }

        public bool IsPrivileged { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POST> POSTs { get; set; }
    }
}
