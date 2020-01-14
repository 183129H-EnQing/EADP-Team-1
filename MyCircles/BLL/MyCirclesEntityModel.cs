namespace MyCircles.BLL
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

        public virtual DbSet<Circle> Circles { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Mutual> Mutuals { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCircle> UserCircles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Circle>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Circle>()
                .HasMany(e => e.UserCircles)
                .WithRequired(e => e.Circle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.eventName)
                .IsFixedLength();

            modelBuilder.Entity<Event>()
                .Property(e => e.eventDescription)
                .IsFixedLength();

            modelBuilder.Entity<Event>()
                .Property(e => e.eventStartDate)
                .IsFixedLength();

            modelBuilder.Entity<Event>()
                .Property(e => e.eventEndDate)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Content)
                .IsFixedLength();

            modelBuilder.Entity<Post>()
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
                .HasMany(e => e.Follows)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FollowerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Follows1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.FollowingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Mutuals)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User1Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Mutuals1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.User2Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserCircles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
