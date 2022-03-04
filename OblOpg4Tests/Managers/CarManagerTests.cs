using Microsoft.VisualStudio.TestTools.UnitTesting;
using OblOpg4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;


namespace OblOpg4.Managers.Tests
{
    [TestClass()]
    public class CarManagerTests
    {
        private CarManager _carManager;
        [TestInitialize]
        public void TestInitialize()
        {
            _carManager = new CarManager();
        }
        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<Car> cars = null;
            cars = _carManager.GetAll(null, null);
            Assert.AreEqual(7, cars.Count());
            cars = _carManager.GetAll(null, 2500);
            Assert.AreEqual(4, cars.Count());
            cars = _carManager.GetAll("Hyundai", null);
            Assert.AreEqual(3, cars.Count());
            cars = _carManager.GetAll("Hyundai", 2000);
            Assert.AreEqual(2, cars.Count());
        }
        [TestMethod()]
        public void GetCarByIdTest()
        {
            Car car1 = null;
            car1 = _carManager.GetById(3);
            Car car2 = new Car(3, "Audi A5", 3000, "jy183");
            Assert.AreEqual(car2.Price,car1.Price);
            Assert.AreEqual(car2.Id, car1.Id);
            Assert.AreEqual(car2.Model, car1.Model);
            Assert.AreEqual(car2.LicensePlate, car1.LicensePlate);
        }

        [TestMethod()]
        public void DeleteCarTest()
        {
            //IEnumerable<Car> cars = null;
            //cars = _carManager.GetAll(null, null);
            Car car1 = _carManager.GetById(6);
            Car car2 = new Car(6, "Peugeot 3008", 3500, "kt865");
            Assert.AreEqual(car2.Price, car1.Price);
            Assert.AreEqual(car2.Id, car1.Id);
            Assert.AreEqual(car2.Model, car1.Model);
            Assert.AreEqual(car2.LicensePlate, car1.LicensePlate);

            _carManager.DeleteCar(6);
            Assert.AreEqual(null, _carManager.GetById(6));
        }
        [TestMethod()]
        public void AddCarTest()
        {
            _carManager.AddCar(new Car(8, "TestCar", 9999, "Test"));
            Car car = _carManager.GetById(8);
            Assert.IsNotNull(car);
        }
    }
}