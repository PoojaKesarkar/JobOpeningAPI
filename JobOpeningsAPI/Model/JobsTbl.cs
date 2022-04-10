using System;
using System.Collections.Generic;

namespace JobOpeningsAPI.Model
{
    public partial class JobsTbl
    {
        public int JobId { get; set; }
        public string JobCode { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string JobDescription { get; set; } = null!;
        public int JobLocationId { get; set; }
        public int JobDeptId { get; set; }
        public DateTime JobPostedDate { get; set; }
        public DateTime JobClosingDate { get; set; }
    }
}
