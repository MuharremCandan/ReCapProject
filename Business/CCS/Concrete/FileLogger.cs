using Business.CCS.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS.Concrete
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyalar loglandı !");
        }
    }
}
