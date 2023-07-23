namespace CarConnect.Models.Car
{
    public class CarsViewModel
    {
        public IEnumerable<CarViewModel> AddedCars { get; set; }
        public IEnumerable<CarViewModel> DropdownCars { get; set; }
        public Guid SelectedCarId { get; set; }
    }
}
