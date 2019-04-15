using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Progress
    {
        public long Id { get; set; }
        public long TraineeId { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
