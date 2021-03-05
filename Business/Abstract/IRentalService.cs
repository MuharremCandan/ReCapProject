using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public  interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental entity);
        IResult Update(Rental entity);
        IResult Delete(Rental entity);
    }
}
