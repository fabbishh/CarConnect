using CarConnect.Entities.Base;

namespace CarConnect.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<UserAddedCar> UserCars { get; set; }
    }
}
