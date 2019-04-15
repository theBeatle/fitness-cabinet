using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Payment
    {
        public long Id { get; set; }
        public string Bill { get; set; }
    }
}
