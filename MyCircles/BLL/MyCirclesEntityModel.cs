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

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Circle> Circles { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<DayByDay> DayByDays { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCategory> EventCategories { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Itinerary> Itineraries { get; set; }
        public virtual DbSet<ItineraryPref> ItineraryPrefs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Mutual> Mutuals { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Pref> Prefs { get; set; }
        public virtual DbSet<SignUpEventDetail> SignUpEventDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCircle> UserCircles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.activityName)
                .IsUnicode(false);

            modelBuilder.Entity<Circle>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Circle>()
                .HasMany(e => e.UserCircles)
                .WithRequired(e => e.Circle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Day>()
                .Property(e => e.timeStamp)
                .IsFixedLength();

            modelBuilder.Entity<DayByDay>()
                .Property(e => e.date)
                .IsFixedLength();

            modelBuilder.Entity<DayByDay>()
                .Property(e => e.startTime)
                .IsFixedLength();

            modelBuilder.Entity<DayByDay>()
                .Property(e => e.endTime)
                .IsFixedLength();

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

            modelBuilder.Entity<EventCategory>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<EventCategory>()
                .Property(e => e.categoryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Itinerary>()
                .Property(e => e.startDate)
                .IsFixedLength();

            modelBuilder.Entity<Itinerary>()
                .Property(e => e.endDate)
                .IsFixedLength();

            modelBuilder.Entity<Itinerary>()
                .Property(e => e.groupSize)
                .IsFixedLength();

            modelBuilder.Entity<Location>()
                .Property(e => e.landmarkType)
                .IsFixedLength();

            modelBuilder.Entity<Location>()
                .Property(e => e.locaPic)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.locaName)
                .IsFixedLength();

            modelBuilder.Entity<Location>()
                .Property(e => e.locaDesc)
                .IsFixedLength();

            modelBuilder.Entity<Location>()
                .Property(e => e.locaWeb)
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

            modelBuilder.Entity<Pref>()
                .Property(e => e.prefName)
                .IsFixedLength();

            modelBuilder.Entity<SignUpEventDetail>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<SignUpEventDetail>()
                .Property(e => e.contactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SignUpEventDetail>()
                .Property(e => e.numberOfBookingSlot)
                .IsUnicode(false);

            modelBuilder.Entity<SignUpEventDetail>()
                .Property(e => e.selectedEventToParticipate)
                .IsUnicode(false);

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
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ProfileImage)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.HeaderImage)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

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
