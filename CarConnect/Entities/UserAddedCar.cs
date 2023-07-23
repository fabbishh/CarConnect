using CarConnect.Entities.Base;

namespace CarConnect.Entities
{
    public class UserAddedCar : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
