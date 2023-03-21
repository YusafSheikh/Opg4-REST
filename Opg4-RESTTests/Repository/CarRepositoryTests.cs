using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opg4_REST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObliOpgave;

namespace Opg4_REST.Repository.Tests
{
    [TestClass()]
    public class CarRepositoryTests
    {


        [TestMethod()]
        public void GetAllTest()
        {
            CarRepository carRepository = new CarRepository();
            List<Car> cars = carRepository.GetAll();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            CarRepository carRepository = new CarRepository(); 
            Car? car = carRepository.GetById(1);
            
            Assert.AreEqual(car.Id, 1);
            Assert.AreNotEqual(car.Id, 4390);
            
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}