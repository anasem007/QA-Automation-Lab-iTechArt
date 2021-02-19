using System;
using System.Collections.Generic;
using System.Linq;
using ClassesObjectsMethods.Interfaces;
using ClassesObjectsMethods.Models;

namespace ClassesObjectsMethods.Generators
{
    public class CandidateReportGenerator : IReportGenerator<Candidate>
    {
        public void CreateReport(List<Candidate> candidates) 
        { 
            Console.WriteLine("{0,-36}  |  {1,-25}  |  {2,-40}  |  {3,-10}", 
                "UserId", "FullName", "JobTittle", "Salary"); 
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------"); 
            
            candidates
                .OrderBy(u => u.Job.Title)
                .ThenBy(u => u.Job.Salary)
                .ToList()
                .ForEach(u=> Console.WriteLine("{0,20}  |  {1,-25}  |  {2,-40}  |  {3,-10}", 
                         u.Id, u.FullName, u.Job.Title, u.Job.Salary));
        }
    }
}