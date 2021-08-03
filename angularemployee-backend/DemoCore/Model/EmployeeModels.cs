using DemoCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Model
{
    public class EmployeeModelListItem
    {
        public int Id { get; set; }
        public int DepartmentID { get; set; }
        public string name { get; set; }
        public string DOB { get; set; }
        public string employeeCode { get; set; }
        public string email { get; set; }
        public string jobTitle { get; set; }
        public string phone { get; set; }
        public string imageUrl { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }

        public static EmployeeModelListItem Convert(Employees em) => new EmployeeModelListItem()
        {
            Id = em.Id,
            DepartmentID = em.DepartmentID,
            name = em.name,
            DOB = em.DOB,
            employeeCode = em.employeeCode,
            email = em.email,
            jobTitle = em.jobTitle,
            phone = em.phone,
            imageUrl = em.imageUrl,
            Description = em.Description,
            StatusID = em.StatusID,
        };

    }
    public class EmployeeModelDetail
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string DOB { get; set; }
        public string employeeCode { get; set; }
        public string email { get; set; }
        public string jobTitle { get; set; }
        public string phone { get; set; }
        public string imageUrl { get; set; }
        public int departmentID { get; set; }
        public string departmentName { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
    }
    public class EmployeeModelCreate
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string DOB { get; set; }
        public string employeeCode { get; set; }
        public string email { get; set; }
        public string jobTitle { get; set; }
        public string phone { get; set; }
        public string imageUrl { get; set; }
        public int departmentID { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
    }

    public class EmployeeModelUpdate
    {
        public string name { get; set; }
        public string DOB { get; set; }
        public string employeeCode { get; set; }
        public string email { get; set; }
        public string jobTitle { get; set; }
        public string phone { get; set; }
        public string imageUrl { get; set; }
        public int departmentID { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
    }
}
