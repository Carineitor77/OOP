using System.Collections.Generic;
using System.Linq;

namespace OOP.Models.Lab2
{
    public class EFEmployeeRepository : IEmployeesRepository
    {
        private OOPDbContext context;

// #pragma warning disable CS8618
        public EFEmployeeRepository(OOPDbContext ctx)
// #pragma warning restore CS8618
        {
            context = ctx;
        }

        public IEnumerable<Employee> Employyes => context.Employees;

        public Employee GetEmployee(long key)
            => context.Employees.FirstOrDefault(e => e.Id == key) ?? new Employee();

        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            //context.Employees.Update(employee);
            Employee? emp = context.Employees.Find(employee.Id);

            if (emp is Employee e)
            {
                e.Name = employee.Name;
                e.Salary = employee.Salary;
                e.Withheld = employee.Withheld;
            }

            context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
