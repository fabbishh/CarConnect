using CarConnect.Entities.Base;

namespace CarConnect.Entities
{
    public class Car : EntityBase
    {
        public string Model { get; set; }
        public List<UserAddedCar> UserCars { get; set; }
    }
}
