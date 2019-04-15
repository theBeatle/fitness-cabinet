using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class RealService
    {
        public RealService()
        {
            Reminder = new HashSet<Reminder>();
        }

        public long Id { get; set; }
        public long ServiceId { get; set; }
        public long CoachId { get; set; }
        public long TraineeId { get; set; }
        public int PlaceId { get; set; }
        public decimal Price { get; set; }
        public string CreationTime { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Place Place { get; set; }
        public virtual Service Service { get; set; }
        public virtual Trainee Trainee { get; set; }
        public virtual ICollection<Reminder> Reminder { get; set; }
    }
}
