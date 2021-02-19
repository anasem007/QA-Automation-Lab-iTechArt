using System;

namespace ClassesObjectsMethods.Models
{
    public class Candidate : User
    {
        public Job Job { get; set; }
        
        public new void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine($"I want to be a {Job.Title} ({Job.Description}) " +
                              $"with a salary from {Job.Salary}.\n");
        }
    }
}