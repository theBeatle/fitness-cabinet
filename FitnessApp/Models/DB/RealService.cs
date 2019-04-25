using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class RealService
    {
        public RealService()
        {
            Reminder = new HashSet<Reminder>();
        }

        public string Id { get; set; }
        public int Price { get; set; }
        public string CreationTime { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string CoachId { get; set; }
        public string PlaceId { get; set; }
        public string ServiceId { get; set; }
        public string TraineeId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Place Place { get; set; }
        public virtual Service Service { get; set; }
        public virtual Trainee Trainee { get; set; }
        public virtual ICollection<Reminder> Reminder { get; set; }
    }
}
