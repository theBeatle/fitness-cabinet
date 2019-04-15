using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Trainee
    {
        public Trainee()
        {
            Progress = new HashSet<Progress>();
            RealService = new HashSet<RealService>();
            TraineeAchivements = new HashSet<TraineeAchivements>();
        }

        public long Id { get; set; }
        public long PersonId { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string WorkShedule { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Progress> Progress { get; set; }
        public virtual ICollection<RealService> RealService { get; set; }
        public virtual ICollection<TraineeAchivements> TraineeAchivements { get; set; }
    }
}
