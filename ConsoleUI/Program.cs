using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsolUI
{
    public class Program
        
    {
        public static void Main(String [] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
               
                Console.WriteLine("Price:"+car.DailyPrice);
                Console.WriteLine("Model Year:"+car.ModelYear);
                Console.WriteLine("Description: "+car.Description);
                Console.WriteLine("---------------");
            }

        }
       
    }
}
