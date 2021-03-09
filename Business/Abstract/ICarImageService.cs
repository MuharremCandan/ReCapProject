using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage , bool>> filter = null);
        IDataResult<CarImage> GetById(int carId);  
        IResult Add(IFormFile file ,CarImage entity);
        IResult Update(IFormFile file ,CarImage entity);
        IResult Delete(IFormFile file ,CarImage entity);

    }
}
