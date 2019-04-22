using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Achivement
    {
        public Achivement()
        {
            TraineeAchivements = new HashSet<TraineeAchivement>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<TraineeAchivement> TraineeAchivements { get; set; }
    }
}
