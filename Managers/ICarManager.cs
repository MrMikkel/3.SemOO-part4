using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;

namespace OblOpg4.Managers
{
    public interface ICarManager
    {
        List<Car> GetAll(string filterString, int? priceFilter);
        Car GetById(int id);
        Car DeleteCar(int id);
        bool AddCar(Car car);
    }
}
