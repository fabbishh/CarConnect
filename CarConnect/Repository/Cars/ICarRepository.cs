using CarConnect.Entities;

namespace CarConnect.Repository.Cars
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<IEnumerable<Car>> GetUserCarsAsync(Guid userId);
        Task RemoveCarFromAddedAsync(Guid userId, Guid carId);
        Task AddUserCarAsync(Guid userId, Guid carId);
    }
}
