namespace MyCircles.BLL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyCirclesEntityModel : DbContext
    {
        public MyCirclesEntityModel()
            : base("name=MyCirclesEntityModel")
        {
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<POST> POSTs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.Content)
                .IsFixedLength();

            modelBuilder.Entity<POST>()
                .Property(e => e.Comment)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.EmailAddress)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friends)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.RecieverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friends1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.SourceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.POSTs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
