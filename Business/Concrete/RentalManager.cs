using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            IResult result = BusinessRules.Run(CheckIfReturnDateIsNull());
            if (!result.Success)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Added);

            }
            return new ErrorResult(Messages.ReturnDateInvalid);
        }

        public IResult Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.RentalDetails());
        }

        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfReturnDateIsNull()
        {
            var result = _rentalDal.Get(p => p.ReturnDate == null);
            if (result == null)
            {
                return new ErrorResult(Messages.CarIsNotAbleToRent);
            }
            return new SuccessResult();
        }
    }
}
