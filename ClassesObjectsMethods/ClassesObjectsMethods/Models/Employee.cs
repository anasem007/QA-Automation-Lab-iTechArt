using System;

namespace ClassesObjectsMethods.Models
{
    public class Employee : User
    {
        public Company Company { get; set; }
        
        public Job Job { get; set; }
       
        public new void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine($"I'm {this.Job.Title} in {this.Company.Name} " +
                              $"({this.Company.Country}, {this.Company.City}, {this.Company.Street})" +
                              $" and my salary {this.Job.Salary}.\n");   
        }
    }
}