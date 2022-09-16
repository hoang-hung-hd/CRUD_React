using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactNet.Models;
using ReactNet.Services;

namespace ReactNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForm model)
        {
            _employeeService.CreateEmployee(model);
            return Ok(new { message = "Employee created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee model)
        {
            _employeeService.UpdateEmployee(id, model);
            return Ok(new { message = "Employee updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok(new { message = "Employee Delete" });
        }
    }
}
