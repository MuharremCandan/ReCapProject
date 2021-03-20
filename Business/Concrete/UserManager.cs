using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using User = Core.Entities.Concrete.User;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal  _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return  new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
            
        }


      //  [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
      
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
