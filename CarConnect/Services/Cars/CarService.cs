using CarConnect.Entities;
using CarConnect.Models.Car;
using CarConnect.Repository.Cars;

namespace CarConnect.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarsViewModel> GetCarsAsync(Guid userId)
        {

            var addedCars = await _carRepository.GetUserCarsAsync(userId);

            var addedCarIds = addedCars.Select(car => car.Id).ToList();
            var notAddedCars = await _carRepository.FindAsync(car => !addedCarIds.Contains(car.Id));

            var response = new CarsViewModel
            {
                AddedCars = MapCars(addedCars),
                DropdownCars = MapCars(notAddedCars)
            };

            return response;
        }

        public async Task<IEnumerable<CarViewModel>> GetDropdownCars(Guid userId)
        {
            var addedCars = await _carRepository.GetUserCarsAsync(userId);

            var addedCarIds = addedCars.Select(car => car.Id).ToList();
            var notAddedCars = await _carRepository.FindAsync(car => !addedCarIds.Contains(car.Id));

            return MapCars(notAddedCars);
        }

        public async Task RemoveCarFromAddedAsync(Guid userId, Guid carId)
        {
            await _carRepository.RemoveCarFromAddedAsync(userId, carId);
        }

        public async Task AddUserCarAsync(Guid userId, Guid carId)
        {
            await _carRepository.AddUserCarAsync(userId, carId);
        }

        private IEnumerable<CarViewModel> MapCars(IEnumerable<Car> cars)
        {
            var mappedCars = new List<CarViewModel>();
            foreach (var car in cars)
            {
                mappedCars.Add(new CarViewModel
                {
                    Id = car.Id,
                    Model = car.Model
                });
            }

            return mappedCars;
        }
    }
}
