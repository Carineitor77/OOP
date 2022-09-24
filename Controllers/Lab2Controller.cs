using Microsoft.AspNetCore.Mvc;
using OOP.Models.Lab2;
using System.Collections.Generic;

namespace OOP.Controllers
{
    public class Lab2Controller : Controller
    {
        private IEmployeesRepository repository;

        public Lab2Controller(IEmployeesRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employyes = repository.Employyes;

            ViewBag.TotalData = new TotalData(employyes);
            return View(employyes);
        }

        public IActionResult UpdateEmployee(long key) 
            => View(key == 0 ? new Employee() : repository.GetEmployee(key));

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                repository.AddEmployee(employee);
            }
            else
            {
                repository.UpdateEmployee(employee);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            repository.DeleteEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
