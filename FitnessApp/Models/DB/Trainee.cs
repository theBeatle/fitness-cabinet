using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Trainee
    {
        public Trainee()
        {
            Progress = new HashSet<Progress>();
            RealService = new HashSet<RealService>();
            TraineeAchivements = new HashSet<TraineeAchivement>();
        }

        public string Id { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string WorkShedule { get; set; }
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Progress> Progress { get; set; }
        public virtual ICollection<RealService> RealService { get; set; }
        public virtual ICollection<TraineeAchivement> TraineeAchivements { get; set; }
    }
}
