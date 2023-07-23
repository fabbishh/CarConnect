using CarConnect.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarConnect
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserAddedCar> UserAddedCars { get; set; }
    }
}
