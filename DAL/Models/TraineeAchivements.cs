using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class TraineeAchivements
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int AchivementId { get; set; }

        public virtual Achivement Achivement { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
