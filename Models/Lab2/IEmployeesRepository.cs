using System.Collections.Generic;

namespace OOP.Models.Lab2
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> Employyes { get; }

        Employee GetEmployee(long key);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
