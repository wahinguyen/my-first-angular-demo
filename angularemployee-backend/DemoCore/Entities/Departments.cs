using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Entities
{
    public partial class Departments
    {
        [Key]
        public int DepartmentID { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
    }
}
