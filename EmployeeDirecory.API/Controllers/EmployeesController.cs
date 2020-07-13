using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectory.BAL;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDirectoryService _employeeDirectoryService;
        public EmployeesController(EmployeeDirectoryService employeeDirectoryService)
        {
            _employeeDirectoryService = employeeDirectoryService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok(_employeeDirectoryService.GetAllEmployees());
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_employeeDirectoryService.GetEmployee(id));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
           return Ok( new { EmployeeId = _employeeDirectoryService.AddEmployee(employee) });
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            return Ok(_employeeDirectoryService.UpdateEmployee(employee) ? "Update succesfully." : "Filed to update!");
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_employeeDirectoryService.DeleteEmployee(id)? "Deleted succesfully." : "Filed to delete!");
        }
    }
}
