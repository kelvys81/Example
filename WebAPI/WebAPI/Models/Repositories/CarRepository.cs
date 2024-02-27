using System.Drawing;

namespace WebAPI.Models.Repositories
{
    public static class CarRepository
    {
        private static List<Car> cars = new List<Car>() {
            new Car{ CartId = 1,Model = "Model-1", Color = "Blue", Status = "For Sale", Price=30, Mileage=10},
            new Car{ CartId = 2,Model = "Model-2", Color = "Black", Status = "Active", Price=35, Mileage=12},
            new Car{ CartId = 3,Model = "Model-3", Color = "Pink", Status = "For Sale", Price=28, Mileage=8},
            new Car{ CartId = 4,Model = "Model-4", Color = "Yellow", Status = "Active", Price=30, Mileage=9}
        };

        public static List<Car> GetCars() {  return cars; }
        public static Car? GetCarById(int id) 
        {  
            return cars.FirstOrDefault(c => c.CartId == id); 
        }
        public static bool CarExists(int id)
        {
            return cars.Any(c => c.CartId == id);
        }
        public static Car GetCarByProperties(string? model, string? color, string? status, int? price, int? mileage ) 
        {
            return cars.FirstOrDefault(c => !string.IsNullOrWhiteSpace(model) && !string.IsNullOrWhiteSpace(c.Model) && c.Model.Equals(model, StringComparison.OrdinalIgnoreCase) &&
                                            !string.IsNullOrWhiteSpace(color) && !string.IsNullOrWhiteSpace(c.Color) && c.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                                            !string.IsNullOrWhiteSpace(status) && !string.IsNullOrWhiteSpace(c.Status) && c.Status.Equals(status, StringComparison.OrdinalIgnoreCase) &&
                                             price.HasValue && c.Price.HasValue && price.Value == c.Price.Value &&
                                             mileage.HasValue && c.Mileage.HasValue && mileage.Value == c.Mileage.Value);
        }
        public static void AddCar(Car newCar) 
        {
            var maxId = cars.Max(x => x.CartId);
            newCar.CartId = maxId + 1;
            cars.Add(newCar);
        }
        public static void UpdateCar(Car car)
        {
            var carToUpdate = cars.FirstOrDefault(c => c.CartId == car.CartId);
            carToUpdate.Color = car.Color;
            carToUpdate.Status = car.Status;
            carToUpdate.Price = car.Price;
            carToUpdate.Mileage = car.Mileage;
            carToUpdate.Model = car.Model;
        }
        public static void DeleteCar(int cardId) 
        { 
            var c = GetCarById(cardId);
            if (c != null)
            {
                cars.Remove(c);                
            }
        }
    }
}