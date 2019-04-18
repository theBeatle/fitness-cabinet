using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class TraineeAchivement
    {
        public int Id { get; set; }
        public int AchivementId { get; set; }
        public int TraineeId { get; set; }

        public virtual Achivement Achivement { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
