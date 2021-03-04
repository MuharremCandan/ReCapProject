using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IResult Add(Car entity)
        {
            if (entity.Name.Length >= 2 && entity.DailyPrice > 0)
            {
                _carDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.NameInvalid);
           
           
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return  new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
