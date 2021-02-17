using System;

namespace ClassesObjectsMethods.Models
{
    public class Employee : User, IDisplayable<Employee>
    {
        public Company Company { get; set; }
        
        public void DisplayData(Employee employee)
        {
            Console.WriteLine($"Hello, I'm {employee.FullName }, {employee.Job.Title} in {employee.Company.Name} " +
                              $"({employee.Company.Country}, {employee.Company.City}, {employee.Company.Street}" +
                              $" and my salary {employee.Job.Salary}");   
        }
    }
}