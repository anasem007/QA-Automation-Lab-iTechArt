using System;
using System.Collections.Generic;
using PhoneShop.Interfaces;
using PhoneShop.Model;

namespace PhoneShop.Models
{
    public class Shop : IDisplayable
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Phone> Phones { get; set; }

        public (int, int) CountAvailablePhones()
        {
            var ios = 0;
            var android = 0;
            
            Phones.ForEach(phone =>
            {
                if (phone.IsAvailable)
                    switch (phone.OperationSystemType)
                    {
                        case OperationSystemType.Android:
                            android++;
                            break;
                        case OperationSystemType.IOS:
                            ios++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
            });
            return (ios, android);
        }

        public void DisplayData()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Available Ios Quantity: {CountAvailablePhones().Item1}");
            Console.WriteLine($"Available Android Quantity: {CountAvailablePhones().Item2}");
        }
    }
}