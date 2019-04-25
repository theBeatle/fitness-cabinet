using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Trainee
    {
        public Trainee()
        {
            Progress = new HashSet<Progress>();
            RealService = new HashSet<RealService>();
            TraineeAchivements = new HashSet<TraineeAchivements>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
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
