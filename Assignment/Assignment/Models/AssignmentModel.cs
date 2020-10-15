namespace Assignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AssignmentModel : DbContext
    {
        public AssignmentModel()
            : base("name=AssignmentModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityCategory> ActivityCategories { get; set; }
        public virtual DbSet<ActivityPlace> ActivityPlaces { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<JoinLog> JoinLogs { get; set; }
        public virtual DbSet<RatingLog> RatingLogs { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasMany(e => e.JoinLogs)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.RatingLogs)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityCategory>()
                .HasMany(e => e.Activities)
                .WithRequired(e => e.ActivityCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityPlace>()
                .Property(e => e.ActivityPlaceLongitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<ActivityPlace>()
                .Property(e => e.ActivityPlaceLatitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<ActivityPlace>()
                .HasMany(e => e.Activities)
                .WithRequired(e => e.ActivityPlace)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityType>()
                .HasMany(e => e.Activities)
                .WithRequired(e => e.ActivityType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.JoinLogs)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.RatingLogs)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasOptional(e => e.UserProfile)
                .WithRequired(e => e.AspNetUser);
        }
    }
}
