using DemoCore.DBContext;
using DemoCore.Entities;
using DemoCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Business
{
    public class DepartmentBusiness
    {
        private CoreContext CoreContext;
        public DepartmentBusiness(CoreContext coreContext)
        {
            CoreContext = coreContext;
        }

        public List<DepartmentModelListItem> SearchList()
        {
            var lstDepartments = CoreContext.Departments
                .AsEnumerable()
                .ToList();

            var data = CoreContext.Departments
                .AsEnumerable()
                .Select(department => new DepartmentModelListItem()
                {
                    CountEmployees = CoreContext.Employees.Where(employee => employee.DepartmentID == department.DepartmentID).Count(),
                    DepartmentID = department.DepartmentID,
                    DepartmentName = department.DepartmentName,
                    Description = department.Description,
                }).ToList();

            return data;
        }

        public List<DepartmentModelSelect> SearchListSelect()
        {
            var lstDepartments = CoreContext.Departments
                .AsEnumerable()
                .Select(department => new DepartmentModelSelect()
                {
                    Key = department.DepartmentID,
                    Value = department.DepartmentName,
                })
                .ToList();

            return lstDepartments;
        }

        public int Create(DepartmentModelCreate dataCreate)
        {
            var department = new Departments()
            {
                DepartmentName = dataCreate.DepartmentName,
                Description = dataCreate.Description,
            };

            CoreContext.Departments.Add(department);
            CoreContext.SaveChanges();

            return department.DepartmentID;
        }

        public int Update(int Id, DepartmentModelUpdate dataUpdate)
        {
            var department = CoreContext.Departments
                .AsEnumerable()
                .Where(department => department.DepartmentID == Id)
                .FirstOrDefault();

            if (department == null)
                throw new Exception("Data Entry Cannot Be Found!");

            department.DepartmentName = dataUpdate.DepartmentName;
            department.Description = dataUpdate.Description;

            CoreContext.SaveChanges();
            return department.DepartmentID;
        }

        public bool Delete(int Id)
        {
            var department = CoreContext.Departments
                .AsEnumerable()
                .Where(department => department.DepartmentID == Id)
                .FirstOrDefault();

            if (department == null)
                throw new Exception("Data Entry Cannot Be Found!");

            var employee = CoreContext.Employees
                .AsEnumerable()
                .Where(employee => employee.DepartmentID == Id)
                .Any();

            if(employee == true)
                throw new Exception("Department is using!");

            CoreContext.Departments.Remove(department);
            CoreContext.SaveChanges();
            return true;
        }
    }
}
