using System.ComponentModel.DataAnnotations;

namespace OOP.Models.Lab1.Task2
{
    public class InputValue
    {
        [Required(ErrorMessage = "Input a value")]
        public int? Value { get; set; }
    }
}
