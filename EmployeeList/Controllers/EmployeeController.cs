using EmployeeList.Data;
using EmployeeList.Models;
using EmployeeList.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeList.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeDbContext DbContext_;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            DbContext_ = employeeDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            var employees = new Employees
            {
                Name = addEmployeeViewModel.Name,
                Email = addEmployeeViewModel.Email,
                PhoneNumber = addEmployeeViewModel.PhoneNumber,
                Employed = addEmployeeViewModel.Employed
            };

            await DbContext_.Employees.AddAsync(employees);
            await DbContext_.SaveChangesAsync();


            return RedirectToAction("EmployeeList", "Employee");
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var employees = await DbContext_.Employees.ToListAsync();
            return View(employees);

        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(Guid id)
        {
            var currentEmployee = await DbContext_.Employees.FindAsync(id);
            return View(currentEmployee);

        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employees employees)
        {
            var employee = await DbContext_.Employees.FindAsync(employees.Id);
            if (employee is not null)
            {
                employee.Name = employees.Name;
                employee.PhoneNumber = employees.PhoneNumber;
                employee.Email = employees.Email;
                employee.Employed = employees.Employed;

                await DbContext_.SaveChangesAsync();
            }
            return RedirectToAction("EmployeeList", "Employee");

        }
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Employees employees)
        {
            var employee = await DbContext_.Employees.FindAsync(employees.Id);
            if (employee is not null)
            {
                DbContext_.Employees.Remove(employee);
                await DbContext_.SaveChangesAsync();
            }
            return RedirectToAction("EmployeeList", "Employee");

        }
    }
}
