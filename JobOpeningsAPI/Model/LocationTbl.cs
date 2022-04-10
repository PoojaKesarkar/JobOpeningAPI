using System;
using System.Collections.Generic;

namespace JobOpeningsAPI.Model
{
    public partial class LocationTbl
    {
        public int LocationId { get; set; }
        public string LocationTitle { get; set; } = null!;
        public string LocationCity { get; set; } = null!;
        public string LocationState { get; set; } = null!;
        public string LocationCountry { get; set; } = null!;
        public int LocationZip { get; set; }
    }
}
