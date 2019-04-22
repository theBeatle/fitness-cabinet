using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Progress
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string TraineeId { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
