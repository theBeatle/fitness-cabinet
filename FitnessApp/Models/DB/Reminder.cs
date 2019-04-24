﻿using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Reminder
    {
        public string Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Frequency { get; set; }
        public bool IsEnabled { get; set; }
        public string RealServiceId { get; set; }

        public virtual RealService RealService { get; set; }
    }
}
