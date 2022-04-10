using System;
using System.Collections.Generic;

namespace JobOpeningsAPI.Model
{
    public partial class DepartmentTbl
    {
        public int DeptId { get; set; }
        public string DeptTitle { get; set; } = null!;
    }
}
