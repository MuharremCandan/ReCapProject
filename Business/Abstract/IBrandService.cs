using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService 
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand entity);
        IResult Update(Brand entity);
        IResult Delete(Brand entity);
        IDataResult<Brand> GetCarsByBrandId(int id);
    }
}
