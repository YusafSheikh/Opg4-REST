using ObliOpgave;

namespace Opg4_REST.Repository
{
    public class CarRepository
    {
        private List<Car> _cars;
        private int _nextId;

        public CarRepository()
        {
            _nextId = 1;
            _cars = new List<Car>() 
            {
                new Car() { Id = _nextId++, LicensePlate = "DA34241", Model = "W205", Price = 324000 },
                new Car() { Id = _nextId++, LicensePlate = "HA43042", Model = "CLA", Price = 430000 },
                new Car() { Id = _nextId++, LicensePlate = "HG38503", Model = "AMG", Price = 3400000 },
                new Car() { Id = _nextId++, LicensePlate = "DN43780", Model = "E63", Price = 32990000 }
            };
        }

        public List<Car> GetAll()
        {
            return new List<Car>(_cars);
        }

        public Car? GetById(int Id)
        {
            return _cars.Find(car => car.Id == Id);
        }

        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextId++;
            _cars.Add(newCar);
            return newCar;
        }

        public Car? Delete(int Id)
        {
            Car? foundCars = GetById(Id);

            if (foundCars == null)
            {
                return null;
            }

            _cars.Remove(foundCars);
            return foundCars;
        }

        public Car? Update(int Id, Car updateCar)
        {
            updateCar.Validate();
            Car? carToBeUpdated = GetById(Id);
            if (carToBeUpdated == null)
            {
                return null;
            }


            carToBeUpdated.Model = updateCar.Model;
            carToBeUpdated.LicensePlate = updateCar.LicensePlate;
            carToBeUpdated.Price = updateCar.Price;

            return carToBeUpdated;
        }
    }

}
