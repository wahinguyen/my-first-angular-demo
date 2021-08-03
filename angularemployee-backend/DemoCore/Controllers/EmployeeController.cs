using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Business;
using DemoCore.Entities;
using DemoCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeBusiness EmployeeBusiness;
        public EmployeeController(EmployeeBusiness employeeBusiness)
        {
            EmployeeBusiness = employeeBusiness;
        }

        [HttpGet("SearchList")]
        public List<EmployeeModelListItem> SearchList(int? statusID)
        {
            return EmployeeBusiness.SearchList(statusID);
        }

        [HttpGet("GetByID")]
        public EmployeeModelDetail GetByID(int Id)
        {
            return EmployeeBusiness.RetrieveByID(Id);
        }

        [HttpPost("Create")]
        public EmployeeModelDetail Create(EmployeeModelCreate bodyData)
        {
            return EmployeeBusiness.Create(bodyData);
        }

        [HttpPut("Update/{Id}")]
        public EmployeeModelDetail Update(int Id, EmployeeModelUpdate bodyData)
        {
            return EmployeeBusiness.Update(Id, bodyData);
        }

        [HttpPut("Restore/{Id}")]
        public bool Restore(int Id)
        {
            return EmployeeBusiness.Restore(Id);
        }

        [HttpDelete("Delete/{Id}")]
        public bool Delete(int Id)
        {
            return EmployeeBusiness.Delete(Id);
        }
    }
}