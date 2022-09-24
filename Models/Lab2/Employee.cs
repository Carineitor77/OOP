using System.ComponentModel.DataAnnotations.Schema;

namespace OOP.Models.Lab2
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Salary { get; set; }
        public double Withheld { get; set; }
        [NotMapped]
        public double Issued => Salary - Withheld;
    }
}
