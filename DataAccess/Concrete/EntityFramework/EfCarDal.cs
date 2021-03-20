using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {


        //public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join x in context.Colors
        //                     on c.ColorId equals x.ColorId
        //                     select new CarDetailDto
        //                     {
        //                         CarId = c.Id,
        //                         CarName = c.Name,
        //                         DailyPrice = c.DailyPrice,
        //                         ColorName = x.ColorName,
        //                         BrandName = b.BrandName,
        //                         ModelYear = c.ModelYear,
        //                         Description = c.Description


        //                     };
        //        return result.ToList();


        //    }


        //}

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Set<Car>().Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join x in context.Colors
                             on c.ColorId equals x.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 ColorId=x.ColorId,
                                 ColorName = x.ColorName,
                                 BrandId=b.BrandId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description


                             };
                return result.ToList();


            }


        }




    }
}
