using System;
using System.Collections.Generic;
using PhoneShop.Interfaces;
using PhoneShop.Models;

namespace PhoneShop.Generators
{
    public class ShopReportGenerator : IReportGenerator<Shop>
    {
        public void CreateReport(List<Shop> shops)
         {
             Console.WriteLine();
             
             shops.ForEach(shop =>
             {
                 shop.DisplayData();
                 
                 Console.WriteLine();
             });
             
         }
    }
}