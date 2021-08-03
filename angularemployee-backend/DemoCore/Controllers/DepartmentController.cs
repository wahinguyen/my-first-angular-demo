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
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentBusiness DepartmentBusiness;
        public DepartmentController(DepartmentBusiness departmentBusiness)
        {
            DepartmentBusiness = departmentBusiness;
        }

        [HttpGet("SearchList")]
        public List<DepartmentModelListItem> SearchList()
        {
            return DepartmentBusiness.SearchList();
        }

        [HttpGet("SearchListSelect")]
        public List<DepartmentModelSelect> SearchListSelect()
        {
            return DepartmentBusiness.SearchListSelect();
        }

        [HttpPost("Create")]
        public int Create(DepartmentModelCreate dataCreate)
        {
            return DepartmentBusiness.Create(dataCreate);
        }

        [HttpPut("Update/{Id}")]
        public int Update(int Id, DepartmentModelUpdate bodyData)
        {
            return DepartmentBusiness.Update(Id, bodyData);
        }

        [HttpDelete("Delete/{Id}")]
        public bool Delete(int Id)
        {
            return DepartmentBusiness.Delete(Id);
        }
    }
}
