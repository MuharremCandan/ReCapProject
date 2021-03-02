using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsolUI
{
    public class Program
        
    {
        public static void Main(String [] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand {  BrandName = "Toyota" });
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Blue" });
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car{ ColorId = 1, BrandId = 1, Name="Araba",ModelYear = 1999, Description = "Null.", DailyPrice = 15000 });

            foreach (var car in carManager.GetAll())
            {
              Console.WriteLine(car.Name);

            }

            

        }
       
    }
}
