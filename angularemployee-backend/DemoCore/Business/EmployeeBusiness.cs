using DemoCore.DBContext;
using DemoCore.Entities;
using DemoCore.Extensions.Commons;
using DemoCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Business
{
    public class EmployeeBusiness
    {
        private CoreContext CoreContext;
        public EmployeeBusiness(CoreContext coreContext)
        {
            CoreContext = coreContext;
        }

        public List<EmployeeModelListItem> SearchList(int? statusID)
        {
            var query = CoreContext.Employees
                .AsEnumerable();

            if(statusID.HasValue)
            {
                query = query.Where(status => status.StatusID == statusID.Value);
            }

            var data = query
                .Select(EmployeeModelListItem.Convert)
                .ToList();

            return data;
        }
        public EmployeeModelDetail RetrieveByID(int Id)
        {
            var employee = CoreContext.Employees
                .AsEnumerable()
                .Where(employee =>
                    employee.Id == Id)
                .Select(employee => new EmployeeModelDetail()
                {
                    Id = employee.Id,
                    name = employee.name,
                    DOB = employee.DOB,
                    employeeCode = employee.employeeCode,
                    email = employee.email,
                    jobTitle = employee.jobTitle,
                    phone = employee.phone,
                    imageUrl = employee.imageUrl,
                    departmentID = employee.DepartmentID,
                    departmentName = CoreContext.Departments
                                        .Where(dp => dp.DepartmentID == employee.DepartmentID)
                                        .Select(dp => dp.DepartmentName)
                                        .FirstOrDefault(),
                    Description = employee.Description,
                    StatusID = employee.StatusID,
                }).FirstOrDefault();

            if (employee == null)
                throw new Exception("Data Entry Cannot Be Found!");

            return employee;
        }
        public EmployeeModelDetail Create(EmployeeModelCreate dataCreate)
        {
            var employee = new Employees()
            {
                name = dataCreate.name,
                DOB = dataCreate.DOB,
                email = dataCreate.email,
                employeeCode = dataCreate.employeeCode,
                jobTitle = dataCreate.jobTitle,
                phone = dataCreate.phone,
                imageUrl = dataCreate.imageUrl,
                DepartmentID = dataCreate.departmentID,
                Description = dataCreate.Description,
                StatusID = (int)StatusID.Active,
            };

            CoreContext.Employees.Add(employee);
            CoreContext.SaveChanges();

            return RetrieveByID(employee.Id);
        }

        public EmployeeModelDetail Update(int Id, EmployeeModelUpdate dataUpdate)
        {
            var employee = CoreContext.Employees
                .AsEnumerable()
                .Where(employee => employee.Id == Id)
                .FirstOrDefault();

            if (employee == null)
                throw new Exception("Data Entry Cannot Be Found!");

            employee.name = dataUpdate.name;
            employee.DOB = dataUpdate.DOB;
            employee.email = dataUpdate.email;
            employee.employeeCode = dataUpdate.employeeCode;
            employee.jobTitle = dataUpdate.jobTitle;
            employee.phone = dataUpdate.phone;
            employee.imageUrl = dataUpdate.imageUrl;
            employee.DepartmentID = dataUpdate.departmentID;
            employee.Description = dataUpdate.Description;
            employee.StatusID = dataUpdate.StatusID;

            CoreContext.SaveChanges();
            return RetrieveByID(Id);
        }

        public bool Restore(int Id)
        {
            var employee = CoreContext.Employees
                .AsEnumerable()
                .Where(employee => employee.Id == Id)
                .FirstOrDefault();

            if (employee == null)
                throw new Exception("Data Entry Cannot Be Found!");

            employee.StatusID = (int)StatusID.Offline;

            CoreContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var employee = CoreContext.Employees
                .AsEnumerable()
                .Where(employee => employee.Id == Id)
                .FirstOrDefault();

            if (employee == null)
                throw new Exception("Data Entry Cannot Be Found!");

            employee.StatusID = (int)StatusID.Deleted;

            CoreContext.SaveChanges();
            return true;
        }
    }
}
