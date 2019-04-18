using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class TraineeAchivements
    {
        public long Id { get; set; }
        public long TraineeId { get; set; }
        public long AchivementId { get; set; }

        public virtual Achivement Achivement { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
