using System;
using PhoneShop.Interfaces;
using PhoneShop.Model;

namespace PhoneShop.Models
{
    public class Phone : IDisplayable
    {
        public string Model { get; set; }

        public OperationSystemType OperationSystemType { get; set; }

        public string MarketLaunchDate { get; set; }

        public string Price { get; set; }

        public bool IsAvailable { get; set; }

        public int ShopId { get; set; }
        
        public void DisplayData()
        {
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Operation System Type: {OperationSystemType}");
            Console.WriteLine($"Market Launch Date: {MarketLaunchDate}");
            Console.WriteLine($"Price: {Price}");
        }
    }
}