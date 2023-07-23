using CarConnect.Models.Car;

namespace CarConnect.Services.Cars
{
    public interface ICarService
    {
        Task<CarsViewModel> GetCarsAsync(Guid userId);
        Task RemoveCarFromAddedAsync(Guid userId, Guid carId);
        Task AddUserCarAsync(Guid userId, Guid carId);
        Task<IEnumerable<CarViewModel>> GetDropdownCars(Guid userId);
    }
}
