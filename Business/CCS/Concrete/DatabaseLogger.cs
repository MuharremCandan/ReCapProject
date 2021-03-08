using Business.CCS.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS.Concrete
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veritabanı loglandı !");
        }
    }
}
