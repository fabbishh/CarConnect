using CarConnect.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarConnect.Repository.Cars
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(CarDbContext context) : base(context) { }

        public async Task<IEnumerable<Car>> GetUserCarsAsync(Guid userId)
        {
            var carsAddedByUser = await _dbSet
                .Join(
                    _context.UserAddedCars,
                    car => car.Id,
                    userAddedCar => userAddedCar.CarId,
                    (car, userAddedCar) => new { Car = car, UserAddedCar = userAddedCar }
                )
                .Where(joinResult => joinResult.UserAddedCar.UserId == userId)
                .Select(joinResult => joinResult.Car)
                .ToListAsync();

            return carsAddedByUser;
        }

        public async Task RemoveCarFromAddedAsync(Guid userId, Guid carId)
        {
            var userAddedCarToRemove = await _context.UserAddedCars
                .FirstOrDefaultAsync(uac => uac.UserId == userId && uac.CarId == carId);

            if (userAddedCarToRemove != null)
            {
                _context.UserAddedCars.Remove(userAddedCarToRemove);
                _context.SaveChanges();
            }
        }

        public async Task AddUserCarAsync(Guid userId, Guid carId)
        {
            var existingUserCar = await _context.UserAddedCars
                .FirstOrDefaultAsync(uac => uac.UserId == userId && uac.CarId == carId);
            if(existingUserCar == null)
            {
                await _context.UserAddedCars.AddAsync(new UserAddedCar
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CarId = carId,
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
