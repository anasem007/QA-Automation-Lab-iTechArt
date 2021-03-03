using System;
using System.Collections.Generic;
using PhoneShop.Interfaces;
using PhoneShop.Models;

namespace PhoneShop.Generators
{
    public class PhoneReportGenerator : IReportGenerator<Phone>
    {
        public void CreateReport(List<Phone> phones)
        {
            Console.WriteLine();
             
            phones.ForEach(phone =>
            {
                phone.DisplayData();
                 
                Console.WriteLine();
            });
        }
    }
}