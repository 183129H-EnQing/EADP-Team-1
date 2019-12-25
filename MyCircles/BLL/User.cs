namespace MyCircles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
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

        public double? xGeoPos { get; set; }

        public double? yGeoPos { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProfileImage { get; set; }

        [Column(TypeName = "image")]
        public byte[] HeaderImage { get; set; }

        public bool IsLoggedIn { get; set; }

        public bool IsPrivileged { get; set; }
    }
}
