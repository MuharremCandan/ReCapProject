using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage entity)
        {
            var result = BusinessRules.Run(CheckNumOfCarImages(entity.CarId));

            if (result != null)
            {
                return result;
            }

            entity.ImagePath = FileHelper.AddAsync(file);
            entity.ImageDate = DateTime.Now;
            _carImageDal.Add(entity);

            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(IFormFile file, CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId));
        }

        public IResult Update(IFormFile file, CarImage entity)
        {
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckNumOfCarImages(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageNumError);
            }
            return new SuccessResult();

        }

       
    }
}
