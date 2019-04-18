using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Progress
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
