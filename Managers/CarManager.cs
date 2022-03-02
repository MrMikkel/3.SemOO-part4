using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;

namespace OblOpg4.Managers
{
    public class CarManager : ICarManager
    {
        public CarManager()
        {
        }

        private static int _nextId = 1;

        private static List<Car> _list = new List<ClassLibrary.Car>()
        {
            new Car(_nextId++,"Hyundai i20",1000,"tb723"),
            new Car(_nextId++,"Hyundai Ioniq 5",2500,"hf154"),
            new Car(_nextId++,"Audi A5",3000,"jy183"),
            new Car(_nextId++,"Hyundai i30",2000,"ad123"),
            new Car(_nextId++,"Audi Q4 e-tron",4000,"gb826"),
            new Car(_nextId++,"Peugeot 3008",3500,"kt865"),
            new Car(_nextId++,"Toyota Aygo",500,"pl654"),
        };

        public List<Car> GetAll(string filterString, int? priceFilter)
        {
            List<Car> resultList = _list;
            if (!string.IsNullOrWhiteSpace(filterString))
            {
                resultList = resultList.FindAll(c => c.Model.Contains(filterString, StringComparison.OrdinalIgnoreCase));
            }

            if (priceFilter!=null)
            {
                resultList = resultList.FindAll(c => c.Price <= priceFilter);
            }

            return resultList;
        }

        public Car GetById(int id)
        {
            return _list.Find(c => c.Id == id);
        }

        public Car DeleteCar(int id)
        {
            Car c = GetById(id);
            _list.Remove(c);
            return c;
        }

        public bool AddCar(Car car)
        {
            car.Id = _nextId++;
            _list.Add(car);
            return true;
        }
    }
}
