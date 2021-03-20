﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public string BrandName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastname { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}