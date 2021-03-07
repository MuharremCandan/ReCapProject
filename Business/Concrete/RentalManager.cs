using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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

            if (entity.ReturnDate == null)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.ReturnDateInvalid);
            }
            
        }

        public IResult Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
