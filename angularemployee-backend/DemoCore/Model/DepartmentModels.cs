using DemoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Model
{
    public class DepartmentModelListItem
    {
        public int CountEmployees { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
    public class DepartmentModelCreate
    {
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }

    public class DepartmentModelUpdate
    {
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }

    public class DepartmentModelSelect
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
