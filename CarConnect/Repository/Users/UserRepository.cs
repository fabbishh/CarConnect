using CarConnect.Entities;

namespace CarConnect.Repository.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CarDbContext context) : base(context) { }
    }
}
