﻿using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Service
    {
        public Service()
        {
            RealService = new HashSet<RealService>();
        }

        public int Id { get; set; }
        public string TrainingName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RealService> RealService { get; set; }
    }
}