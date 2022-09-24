using Microsoft.AspNetCore.Mvc;
using OOP.Models.Lab1.Task2;
using OOP.Models.Lab1.Task3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP.Controllers
{
    public class Lab1Controller : Controller
    {
        public IActionResult Task1()
        {
            string result = $"Algash Anatoly {DateTime.Now}";
            return View("Task1", result);
        }

        public IActionResult Task2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task2(InputValue inputValue)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Result = $"Output: {Math.Pow(Convert.ToDouble(inputValue.Value), 0.5)}";
                return View();
            }

            return View();
        }

        public IActionResult Task3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task3(InputValues inputValues)
        {
            if (inputValues.FirstValue >= inputValues.SecondValue)
            {
                ModelState.AddModelError("", "Second value must be more then first");
            }
            if (ModelState.IsValid)
            {
                TemperatureRange result = new TemperatureRange(GetRange(inputValues));
                ViewBag.Result = result;
                ViewBag.Count = result?.Fahrenheit?.Count();
            }

            return View();
        }

        private List<double> GetRange(InputValues inputValues)
        {
            List<double> result = new List<double>();

            for (double? i = inputValues.FirstValue; i <= inputValues.SecondValue; i++)
            {
                result.Add((double)i);
            }

            return result;
        }
    }
}
