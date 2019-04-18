using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Progress
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int TraineeId { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
