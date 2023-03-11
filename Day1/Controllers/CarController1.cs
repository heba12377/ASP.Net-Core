using Microsoft.AspNetCore.Mvc;
using Day1.Models;
namespace Day1.Controllers
{
    public class CarController1 : Controller
    {
        public IActionResult getAll()
        {
            var cars = Car.GetCars();
            return View(cars);
        }

        public IActionResult getDetails(string man, string from)
        {
            Data data= new Data();
            var car = Car.GetCars().FirstOrDefault(c=>c.Manufacturer ==man);

            data.car = car;
            data.Status = from;

            return View(data);
        }
    }
}
