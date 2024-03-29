﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarSevice
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
       
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetDetailsByColordId(int colorId);
        IResult AddTransactionalTest(Car car);
    }
}
