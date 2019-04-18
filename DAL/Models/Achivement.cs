using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Achivement
    {
        public Achivement()
        {
            TraineeAchivements = new HashSet<TraineeAchivements>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<TraineeAchivements> TraineeAchivements { get; set; }
    }
}
