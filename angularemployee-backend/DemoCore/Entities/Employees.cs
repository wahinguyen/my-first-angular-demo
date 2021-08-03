using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Entities
{
    public partial class Employees
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentID { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string DOB { get; set; }
        [StringLength(50)]
        public string employeeCode { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(50)]
        public string jobTitle { get; set; }
        [StringLength(50)]
        public string phone { get; set; }
        [StringLength(200)]
        public string imageUrl { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int StatusID { get; set; }
    }
}
