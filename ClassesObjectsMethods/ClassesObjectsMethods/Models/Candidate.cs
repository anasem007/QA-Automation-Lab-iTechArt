using System;
using ClassesObjectsMethods;

namespace ClassesObjectsMethods.Models
{
    public class Candidate : User, IDisplayable<Candidate>
    {
        public void DisplayData(Candidate candidate)
        {
            Console.WriteLine($"Hello, I'm {candidate.FullName}, " +
                              $"I want to be a {candidate.Job.Title}({candidate.Job.Description})" +
                              $"with a salary from {candidate.Job.Salary}");
        }
    }
}