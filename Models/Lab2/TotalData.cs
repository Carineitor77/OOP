using System.Collections.Generic;
using System.Linq;

namespace OOP.Models.Lab2
{
    public class TotalData
    {
        public TotalData(IEnumerable<Employee> employyes)
        {
            Salary = employyes.Sum(e => e.Salary);
            Withheld = employyes.Sum(e => e.Withheld);
            Issued = employyes.Sum(e => e.Issued);
        }
        
        public double Salary { get; }
        public double Withheld { get; }
        public double Issued { get; }
    }
}
