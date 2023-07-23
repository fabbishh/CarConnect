using CarConnect.Models.Car;
using CarConnect.Services.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarConnect.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly Guid _currentUserId;
        private readonly ICarService _carService;

        public CarController(IHttpContextAccessor httpContextAccessor, ICarService carService)
        {
            _currentUserId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _carService.GetCarsAsync(_currentUserId);
            return View(model);
        }

        [HttpGet]
        public async Task<IEnumerable<CarViewModel>> GetDropdownCars()
        {
            var model = await _carService.GetDropdownCars(_currentUserId);
            return model;
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveCarFromAdded(Guid carId)
        {
            await _carService.RemoveCarFromAddedAsync(_currentUserId, carId);

            var model = await _carService.GetCarsAsync(_currentUserId);
            return PartialView("_AddedCarsTable", model.AddedCars);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserCar(Guid selectedCarId)
        {
            await _carService.AddUserCarAsync(_currentUserId, selectedCarId);

            var model = await _carService.GetCarsAsync(_currentUserId);
            return PartialView("_AddedCarsTable", model.AddedCars);
        }
    }
}
