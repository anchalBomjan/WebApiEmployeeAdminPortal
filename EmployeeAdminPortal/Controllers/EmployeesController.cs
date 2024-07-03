using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
      
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployee() 
        { 
            var allEmployees= _context.Employees.ToList();

            return Ok(allEmployees);
        }



        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetEmployeeById(Guid id)
        {

            var employee = _context.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

           _context.Employees.Add(employeeEntity);
            _context.SaveChanges();
            return Ok(employeeEntity);
        }




        [HttpPut]
        [Route("{id:guid}")]


        public IActionResult UpdateEmployee(Guid id,AddEmployeeDto addEmployeeDto)
        {
            var employee = _context.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();

            }
            employee.Name=addEmployeeDto.Name;
            employee.Email=addEmployeeDto.Email;
            employee.Phone = addEmployeeDto.Phone;
            employee.Salary=addEmployeeDto.Salary;
            _context.SaveChanges();
            return Ok(employee);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public  IActionResult  DeleteEmployee(Guid id)
        {
            var employee = _context.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok();
        }

    }
}
