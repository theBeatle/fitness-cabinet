using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Reminder
    {
        public long Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long RealServiceId { get; set; }
        public int Frequency { get; set; }
        public bool IsEnabled { get; set; }

        public virtual RealService RealService { get; set; }
    }
}
