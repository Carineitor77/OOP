using System.ComponentModel.DataAnnotations;

namespace OOP.Models.Lab1.Task3
{
    public class InputValues
    {
        [Required(ErrorMessage = "Input a first value")]
        public double? FirstValue { get; set; }

        [Required(ErrorMessage = "Input a second value")]
        public double? SecondValue { get; set; }
    }
}
