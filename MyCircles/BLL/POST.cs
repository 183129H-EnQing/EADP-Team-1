namespace MyCircles.BLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            ReportedPosts = new HashSet<ReportedPost>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Content { get; set; }

        public string Image { get; set; }

        [StringLength(20)]
        public string Comment { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(64)]
        public string CircleId { get; set; }

        public virtual Circle Circle { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportedPost> ReportedPosts { get; set; }
    }
}
