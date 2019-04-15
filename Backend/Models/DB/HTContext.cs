using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models.DB
{
    public partial class HTContext : DbContext
    {
        public HTContext()
        {
        }

        public HTContext(DbContextOptions<HTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achivement> Achivement { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<CoachPlace> CoachPlace { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonsPhotos> PersonsPhotos { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlacesPhotos> PlacesPhotos { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<RealService> RealService { get; set; }
        public virtual DbSet<Receiver> Receiver { get; set; }
        public virtual DbSet<Reminder> Reminder { get; set; }
        public virtual DbSet<Sender> Sender { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SexStatus> SexStatus { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<Trainee> Trainee { get; set; }
        public virtual DbSet<TraineeAchivements> TraineeAchivements { get; set; }
        public virtual DbSet<Usabilities> Usabilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

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

                entity.Property(e => e.Longitude).IsRequired();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.ReceiverId).HasColumnName("Receiver_Id");

                entity.Property(e => e.SenderId).HasColumnName("Sender_Id");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat__Receiver_I__2F10007B");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat__Sender_Id__2E1BDC42");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("Person_Id");

                entity.Property(e => e.WorkShedule)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Coach__Person_Id__31EC6D26");
            });

            modelBuilder.Entity<CoachPlace>(entity =>
            {
                entity.Property(e => e.CoachId).HasColumnName("Coach_Id");

                entity.Property(e => e.PlaceId).HasColumnName("Place_Id");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.CoachPlace)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoachPlac__Coach__4BAC3F29");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.CoachPlace)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoachPlac__Place__4CA06362");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Bill)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.IsBanned).HasColumnName("Is_Banned");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_Deleted");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SexStatusId).HasColumnName("SexStatus_Id");

                entity.HasOne(d => d.SexStatus)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.SexStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__SexStatu__25869641");
            });

            modelBuilder.Entity<PersonsPhotos>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("Person_Id");

                entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonsPhotos)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonsPh__Perso__60A75C0F");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.PersonsPhotos)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonsPh__Photo__619B8048");
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.IsSimplePlace).HasColumnName("isSimplePlace");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Track).HasMaxLength(500);

                entity.Property(e => e.WorkShedule)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Place__Address_I__3B75D760");
            });

            modelBuilder.Entity<PlacesPhotos>(entity =>
            {
                entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");

                entity.Property(e => e.PlaceId).HasColumnName("Place_Id");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.PlacesPhotos)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlacesPho__Photo__5DCAEF64");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.PlacesPhotos)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlacesPho__Place__5CD6CB2B");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.TraineeId).HasColumnName("Trainee_Id");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Progress__Traine__52593CB8");
            });

            modelBuilder.Entity<RealService>(entity =>
            {
                entity.Property(e => e.CoachId).HasColumnName("Coach_Id");

                entity.Property(e => e.CreationTime)
                    .IsRequired()
                    .HasColumnName("Creation_Time")
                    .HasMaxLength(300);

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasColumnName("End_Time")
                    .HasMaxLength(300);

                entity.Property(e => e.PlaceId).HasColumnName("Place_Id");

                entity.Property(e => e.Price).HasColumnType("smallmoney");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasColumnName("Start_Time")
                    .HasMaxLength(300);

                entity.Property(e => e.TraineeId).HasColumnName("Trainee_Id");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RealServi__Coach__4222D4EF");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RealServi__Place__440B1D61");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RealServi__Servi__412EB0B6");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.RealService)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RealServi__Train__4316F928");
            });

            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("Person_Id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Receiver)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Receiver__Person__2B3F6F97");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasColumnName("End_Time")
                    .HasMaxLength(300);

                entity.Property(e => e.IsEnabled).HasColumnName("Is_Enabled");

                entity.Property(e => e.RealServiceId).HasColumnName("RealService_Id");

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasColumnName("Start_Time")
                    .HasMaxLength(300);

                entity.HasOne(d => d.RealService)
                    .WithMany(p => p.Reminder)
                    .HasForeignKey(d => d.RealServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reminder__RealSe__46E78A0C");
            });

            modelBuilder.Entity<Sender>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("Person_Id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Sender)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sender__Person_I__286302EC");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

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
                entity.Property(e => e.CoachId).HasColumnName("Coach_Id");

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Speciality1)
                    .IsRequired()
                    .HasColumnName("Speciality")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Speciality)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specialit__Coach__4F7CD00D");
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("Person_Id");

                entity.Property(e => e.WorkShedule)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Trainee)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trainee__Person___34C8D9D1");
            });

            modelBuilder.Entity<TraineeAchivements>(entity =>
            {
                entity.Property(e => e.AchivementId).HasColumnName("Achivement_Id");

                entity.Property(e => e.TraineeId).HasColumnName("Trainee_Id");

                entity.HasOne(d => d.Achivement)
                    .WithMany(p => p.TraineeAchivements)
                    .HasForeignKey(d => d.AchivementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TraineeAc__Achiv__5812160E");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeAchivements)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TraineeAc__Train__571DF1D5");
            });

            modelBuilder.Entity<Usabilities>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PlaceId).HasColumnName("Place_Id");

                entity.Property(e => e.UsabilityName)
                    .IsRequired()
                    .HasColumnName("Usability_Name")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Usabilities)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usabiliti__Place__3E52440B");
            });
        }
    }
}
