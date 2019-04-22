using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Service
    {
        public Service()
        {
            RealService = new HashSet<RealService>();
        }

        public string Id { get; set; }
        public string TrainingName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RealService> RealService { get; set; }
    }
}
