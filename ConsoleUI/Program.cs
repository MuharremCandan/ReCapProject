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
        public static void Main(String[] args)
        {
            //Color İşlemleri
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Ekleme
            //colorManager.Add(new Color { ColorName = "Blue" });
            //colorManager.Add(new Color { ColorName = "White" });
            //colorManager.Add(new Color { ColorName = "Red" });
            //colorManager.Add(new Color { ColorName = "Metallic" });
            //colorManager.Add(new Color { ColorName = "Grey" });

            //Silme
            //colorManager.Delete(new Color { ColorId = 3020 });

            //Güncelleme
            //colorManager.Update(new Color { ColorId = 3019 , ColorName= "White" });

            //Hepsini Çağırma
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            //BUnun sayesinde verilen renkteki araçları getiriri ama araç yok şu an o yüzden andom giriyom sayıyı
            //foreach (var color in colorManager.GetCarsByColorId(1))
            //{
            //    Console.WriteLine(color.);
            //}



            // Brand İşlemleri
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Ekleme
            //brandManager.Add(new Brand { BrandName = "BMW" });
            //brandManager.Add(new Brand { BrandName = "Toyota" });
            //brandManager.Add(new Brand { BrandName = "Honda" });
            //brandManager.Add(new Brand { BrandName = "Chevrolet" });

            //Silme
            //brandManager.Delete(new Brand { BrandId = 3021 });

            //Güncelleme
            //brandManager.Update(new Brand { BrandId = 3020, BrandName = "Cadillac" });

            //Hepsini Getirme
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

            // spesifik getirme . Random sayı brandId si 1 olan araç yok şu an 
            //foreach (var brand in brandManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(brand);
            //}


            CarManager carManager = new CarManager(new EfCarDal());
            // Araç Ekleme
            //carManager.Add(new Car
            //{
            //    ColorId = 3016,
            //    BrandId = 3018,
            //    Name = "New Cadillac Series",
            //    ModelYear = 2019,
            //    Description = "Null.",
            //    DailyPrice = 150000
            //});
            //carManager.Add(new Car
            //{
            //    ColorId = 3017,
            //    BrandId = 3018,
            //    Name = "New BMW Series",
            //    ModelYear = 2020,
            //    Description = "Null.",
            //    DailyPrice = 100000
            //});
            
            // Araç Silme 
            //carManager.Delete(new Car { Id=3027 });

            //Araç Güncelleme
            //carManager.Update(new Car { Id = 3026, BrandId=3019,ColorId=3017, Name="Corolla",DailyPrice=120000});

            //Tüm Araçları Getirme
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id+" / "+ car.Name);
            //}

            // tabloların birleştirilmesi sonucu araç getirme  Bunu Dto ile ilişkili joinler vs.
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Name: {0} \nBrand :{1}  \nColor: {2}  \nPrice: {3} ", car.CarName,car.BrandName,
                    car.ColorName,car.DailyPrice);
                Console.WriteLine();
            }



            


        }




    }
}
