using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class TraineeAchivements
    {
        public int Id { get; set; }

        public virtual Achivement Achivement { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
