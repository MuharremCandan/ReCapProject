using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carId);

        IResult Add(CarImage entity);
        IResult Update(CarImage entity);
        IResult Delete(CarImage entity);
        
    }
}
