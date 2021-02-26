using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface ICarSevice
    {
        List<Car> GetAll();
    }
}
