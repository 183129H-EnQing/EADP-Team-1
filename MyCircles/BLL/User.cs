namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Helpers;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Friends = new HashSet<Friend>();
            Friends1 = new HashSet<Friend>();
            Notifications = new HashSet<Notification>();
            IsDeleted = false;
            IsLoggedIn = false;
            IsPrivileged = false;
        }

        public int Id { get; set; }

        [Required]
        [CustomValidation(typeof(User), "ValidateContact")]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string EmailAddress { get; set; }

        private string _password;

        [StringLength(256)]
        public string Password
        {
            get { return this._password; }
            set { _password = Crypto.HashPassword(value); }
        }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Bio { get; set; }

        public double? xGeoPos { get; set; }

        public double? yGeoPos { get; set; }

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
    }
}
