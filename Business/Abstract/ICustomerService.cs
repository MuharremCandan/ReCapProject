using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer entity);
        IResult Update(Customer entity);
        IResult Delete(Customer entity);
        IDataResult<Customer> GetCustomerByUserId(int id);
    }
}
