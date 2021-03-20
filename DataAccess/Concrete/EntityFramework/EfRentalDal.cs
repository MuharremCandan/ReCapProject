using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> RentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.UserId

                             select new RentalDetailDto()
                             {
                                 BrandName = brand.BrandName,
                                 CustomerName = user.FirstName,
                                 CustomerLastname = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate

                             };
                return result.ToList();

            }
        }
    }
}
