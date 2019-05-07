﻿// <auto-generated />
using System;
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(FitnessCabinetContext))]
    partial class FitnessCabinetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dal.Achivement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("Quantity");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Achivements");
                });

            modelBuilder.Entity("Dal.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Latitude")
                        .IsRequired();

                    b.Property<string>("Longitude")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Dal.Chat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ReceiverId");

                    b.Property<long>("SenderId");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Dal.Coach", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<int>("Height");

                    b.Property<long>("PersonId");

                    b.Property<int>("Weight");

                    b.Property<string>("WorkShedule")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("Dal.CoachPlace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CoachId");

                    b.Property<int>("PlaceId");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("PlaceId");

                    b.ToTable("CoachPlaces");
                });

            modelBuilder.Entity("Dal.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bill")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Dal.People", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<bool>("IsBanned");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("SexStatusId");

                    b.HasKey("Id");

                    b.HasIndex("SexStatusId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Dal.PersonsPhotos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PersonId");

                    b.Property<long>("PhotoId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PhotoId");

                    b.ToTable("PersonsPhotos");
                });

            modelBuilder.Entity("Dal.Photos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Dal.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<bool>("IsSimplePlace")
                        .HasColumnName("isSimplePlace");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.Property<string>("Track")
                        .HasMaxLength(500);

                    b.Property<string>("WorkShedule")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Dal.PlacesPhotos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PhotoId");

                    b.Property<int>("PlaceId");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlacesPhotos");
                });

            modelBuilder.Entity("Dal.Progress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<long>("TraineeId");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("TraineeId");

                    b.ToTable("Progresses");
                });

            modelBuilder.Entity("Dal.RealService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CoachId");

                    b.Property<string>("CreationTime")
                        .IsRequired()
                        .HasColumnName("Creation_Time")
                        .HasMaxLength(300);

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnName("End_Time")
                        .HasMaxLength(300);

                    b.Property<int>("PlaceId");

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney");

                    b.Property<long>("ServiceId");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnName("Start_Time")
                        .HasMaxLength(300);

                    b.Property<long>("TraineeId");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TraineeId");

                    b.ToTable("RealServices");
                });

            modelBuilder.Entity("Dal.Receiver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Receivers");
                });

            modelBuilder.Entity("Dal.Reminder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnName("End_Time")
                        .HasMaxLength(300);

                    b.Property<int>("Frequency");

                    b.Property<bool>("IsEnabled")
                        .HasColumnName("Is_Enabled");

                    b.Property<long>("RealServiceId");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnName("Start_Time")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("RealServiceId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Dal.Sender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Senders");
                });

            modelBuilder.Entity("Dal.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<string>("TrainingName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Dal.SexStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("SexStatuses");
                });

            modelBuilder.Entity("Dal.Speciality", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CoachId");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<int>("Rating");

                    b.Property<string>("Speciality1")
                        .IsRequired()
                        .HasColumnName("Speciality")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("Dal.Trainee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<int>("Height");

                    b.Property<long>("PersonId");

                    b.Property<int>("Weight");

                    b.Property<string>("WorkShedule")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("Dal.TraineeAchivements", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AchivementId");

                    b.Property<long>("TraineeId");

                    b.HasKey("Id");

                    b.HasIndex("AchivementId");

                    b.HasIndex("TraineeId");

                    b.ToTable("TraineeAchivements");
                });

            modelBuilder.Entity("Dal.Usabilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("PlaceId");

                    b.Property<int>("Quantity");

                    b.Property<string>("UsabilityName")
                        .IsRequired()
                        .HasColumnName("Usability_Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Usabilities");
                });

            modelBuilder.Entity("Dal.Chat", b =>
                {
                    b.HasOne("Dal.Receiver", "Receiver")
                        .WithMany("Chat")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Dal.Sender", "Sender")
                        .WithMany("Chat")
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("Dal.Coach", b =>
                {
                    b.HasOne("Dal.People", "Person")
                        .WithMany("Coach")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Dal.CoachPlace", b =>
                {
                    b.HasOne("Dal.Coach", "Coach")
                        .WithMany("CoachPlace")
                        .HasForeignKey("CoachId");

                    b.HasOne("Dal.Place", "Place")
                        .WithMany("CoachPlace")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("Dal.People", b =>
                {
                    b.HasOne("Dal.SexStatus", "SexStatus")
                        .WithMany("Person")
                        .HasForeignKey("SexStatusId");
                });

            modelBuilder.Entity("Dal.PersonsPhotos", b =>
                {
                    b.HasOne("Dal.People", "Person")
                        .WithMany("PersonsPhotos")
                        .HasForeignKey("PersonId");

                    b.HasOne("Dal.Photos", "Photo")
                        .WithMany("PersonsPhotos")
                        .HasForeignKey("PhotoId");
                });

            modelBuilder.Entity("Dal.Place", b =>
                {
                    b.HasOne("Dal.Address", "Address")
                        .WithMany("Place")
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Dal.PlacesPhotos", b =>
                {
                    b.HasOne("Dal.Photos", "Photo")
                        .WithMany("PlacesPhotos")
                        .HasForeignKey("PhotoId");

                    b.HasOne("Dal.Place", "Place")
                        .WithMany("PlacesPhotos")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("Dal.Progress", b =>
                {
                    b.HasOne("Dal.Trainee", "Trainee")
                        .WithMany("Progress")
                        .HasForeignKey("TraineeId");
                });

            modelBuilder.Entity("Dal.RealService", b =>
                {
                    b.HasOne("Dal.Coach", "Coach")
                        .WithMany("RealService")
                        .HasForeignKey("CoachId");

                    b.HasOne("Dal.Place", "Place")
                        .WithMany("RealService")
                        .HasForeignKey("PlaceId");

                    b.HasOne("Dal.Service", "Service")
                        .WithMany("RealService")
                        .HasForeignKey("ServiceId");

                    b.HasOne("Dal.Trainee", "Trainee")
                        .WithMany("RealService")
                        .HasForeignKey("TraineeId");
                });

            modelBuilder.Entity("Dal.Receiver", b =>
                {
                    b.HasOne("Dal.People", "Person")
                        .WithMany("Receiver")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Dal.Reminder", b =>
                {
                    b.HasOne("Dal.RealService", "RealService")
                        .WithMany("Reminder")
                        .HasForeignKey("RealServiceId");
                });

            modelBuilder.Entity("Dal.Sender", b =>
                {
                    b.HasOne("Dal.People", "Person")
                        .WithMany("Sender")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Dal.Speciality", b =>
                {
                    b.HasOne("Dal.Coach", "Coach")
                        .WithMany("Speciality")
                        .HasForeignKey("CoachId");
                });

            modelBuilder.Entity("Dal.Trainee", b =>
                {
                    b.HasOne("Dal.People", "Person")
                        .WithMany("Trainee")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Dal.TraineeAchivements", b =>
                {
                    b.HasOne("Dal.Achivement", "Achivement")
                        .WithMany("TraineeAchivements")
                        .HasForeignKey("AchivementId");

                    b.HasOne("Dal.Trainee", "Trainee")
                        .WithMany("TraineeAchivements")
                        .HasForeignKey("TraineeId");
                });

            modelBuilder.Entity("Dal.Usabilities", b =>
                {
                    b.HasOne("Dal.Place", "Place")
                        .WithMany("Usabilities")
                        .HasForeignKey("PlaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
