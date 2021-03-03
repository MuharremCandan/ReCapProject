using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarSevice
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            if (entity.Name.Length >= 2 && entity.DailyPrice > 0)
            {
                _carDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Your name of car must be longer than 2 character and your daily price of your car must be more expensive than 0.");
            }
           
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
