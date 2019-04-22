using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class TraineeAchivement
    {
        public string Id { get; set; }
        public int AchivementId { get; set; }
        public string TraineeId { get; set; }

        public virtual Achivement Achivement { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
