using System;
using ClassesObjectsMethods.Interfaces;

namespace ClassesObjectsMethods.Models
{
    public abstract class User : IDisplayable
    {
        public Guid Id => Guid.NewGuid();
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;
        
        public void DisplayData()
        {
            Console.WriteLine($"Hello, I'm {FullName}.");
        }
    }
}