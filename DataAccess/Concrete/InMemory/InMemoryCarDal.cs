using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars =new List<Car>
            {

                 new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=75000,Description="null",ModelYear=1999},
                 new Car{Id=2,BrandId=2,ColorId=1,DailyPrice=45000,Description="Old Van",ModelYear=1989},
                 new Car{Id=3,BrandId=1,ColorId=2,DailyPrice=750000,Description="Faster than time.",ModelYear=2020}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carTODelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
