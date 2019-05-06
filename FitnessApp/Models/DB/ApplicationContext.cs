using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace FitnessApp.Models.DB
{
    public class ApplicationContext : IdentityDbContext<Person>
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions options)
        : base(options)
        {
        }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FitnessCabinet;Trusted_Connection=True;");
        //    }
        //}

        public virtual DbSet<Achivement> Achivement { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<CoachPlace> CoachPlace { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<RealService> RealService { get; set; }
        public virtual DbSet<Receiver> Receiver { get; set; }
        public virtual DbSet<Reminder> Reminder { get; set; }
        public virtual DbSet<Sender> Sender { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SexStatus> SexStatus { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<Trainee> Trainee { get; set; }
        public virtual DbSet<TraineeAchivement> TraineeAchivements { get; set; }
        public virtual DbSet<Usabilities> Usabilities { get; set; }

        //public virtual DbSet<PersonPhoto> PersonPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<PersonPhoto>(entity =>
            //{
            //    //entity.Property(e => e.PersonId).HasColumnName("Person_Id");

            //    //entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");

            //    entity.HasOne(d => d.Person)
            //        .WithMany(p => p.PersonPhotos)
            //        .HasForeignKey(d => d.PersonId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //       /* .HasConstraintName("FK__PersonsPh__Perso__60A75C0F")*/;

            //    entity.HasOne(d => d.Photo)
            //        .WithMany(p => p.PersonPhotos)
            //        .HasForeignKey(d => d.PhotoId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        /*.HasConstraintName("FK__PersonsPh__Photo__619B8048")*/;
            //});


            modelBuilder.Entity<Achivement>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Building)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Latitude).IsRequired();

                entity.Property(e => e.Logtitude).IsRequired();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.ReceiverId);

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.Property(e => e.WorkShedule)
                    .IsRequired();

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<CoachPlace>()
                .HasKey(d => new { d.PlaceId, d.CoachId });

            modelBuilder.Entity<CoachPlace>()
                .HasOne(d => d.Coach)
                .WithMany(d => d.CoachPlaces)
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<CoachPlace>()
                .HasOne(d => d.Place)
                .WithMany(d => d.CoachPlaces)
                .HasForeignKey(d => d.Id);
           

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Bill)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(300);
                                
                entity.HasOne(d => d.SexStatus)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.SexStatusId);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Path)
                    .IsRequired();
            });

            modelBuilder.Entity<PersonPhoto>()
                .HasKey(d => new { d.PersonId, d.PhotoId });

            modelBuilder.Entity<PersonPhoto>()
                .HasOne(d => d.Person)
                .WithMany(d => d.PersonPhotos)
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<PersonPhoto>(entity =>
            {
                entity.HasOne(d => d.Photo)
                    .WithMany(d => d.PersonPhotos)
                    .HasForeignKey(d => d.Id);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Track).HasMaxLength(500);

                entity.Property(e => e.WorkShedule)
                    .IsRequired();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.AddressId);
            });

            modelBuilder.Entity<PlacePhoto>()
                .HasKey(d => new { d.PlaceId, d.PhotoId });

            modelBuilder.Entity<PlacePhoto>()
                .HasOne(d => d.Place)
                .WithMany(d => d.PlacePhotos)
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<PlacePhoto>()
                .HasOne(d => d.Place)
                .WithMany(d => d.PlacePhotos)
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.TraineeId);
            });

            modelBuilder.Entity<RealService>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.CoachId);

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.PlaceId);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.ServiceId);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Receiver)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.RealService)
                    .WithMany(p => p.Reminder)
                    .HasForeignKey(d => d.RealServiceId);
            });

            modelBuilder.Entity<Sender>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Sender)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.TrainingName).IsRequired();
            });

            modelBuilder.Entity<SexStatus>(entity =>
            {
                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.Property(e => e.Experience)
                    .IsRequired();

                entity.Property(e => e.Specialities)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Speciality)
                    .HasForeignKey(d => d.CoachId);
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.Property(e => e.WorkShedule)
                    .IsRequired();

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Trainee)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<TraineeAchivement>()
                .HasKey(d => new { d.TraineeId, d.AchivementId });

            modelBuilder.Entity<TraineeAchivement>()
                .HasOne(d => d.Achivement)
                .WithMany(d => d.TraineeAchivements)
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<TraineeAchivement>()
                .HasOne(d => d.Trainee)
                .WithMany(d => d.TraineeAchivements)
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<Usabilities>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);
                
                entity.Property(e => e.UsabilityName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Usabilities)
                    .HasForeignKey(d => d.PlaceId);
            });
        }
    }
}
