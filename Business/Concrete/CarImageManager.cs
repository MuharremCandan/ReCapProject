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
        public IResult Add(IFormFile file,CarImage entity)
        {
            var fileUpload = FileHelper.AddAsync(file);
            IResult result = BusinessRules.Run(CheckCountOfCarImages(entity.CarId) , fileUpload);
            if (result != null)
            {
                return result;
            }
            entity.ImagePath = fileUpload.Data;
            entity.ImageDate = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.Added);
            
             
        }

        private IResult CheckCountOfCarImages(int carId)
        {
            var result = _carImageDal.GetAll(c=> c.CarId==carId).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CarImageNumError);
            }
            return new SuccessResult();
            
        }

        public IResult Delete(IFormFile file ,CarImage entity)
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

        public IResult Update(IFormFile file ,CarImage entity)
        {
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
