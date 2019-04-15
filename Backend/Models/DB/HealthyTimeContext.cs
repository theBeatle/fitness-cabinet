using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DB
{
    public class HealthyTimeContext : DbContext
    {
        public HealthyTimeContext()
        {

        }

        public HealthyTimeContext(DbContextOptions<HealthyTimeContext> options)
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
    }
}
