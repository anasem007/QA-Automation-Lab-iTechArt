using System;
using System.Collections.Generic;
using System.Linq;
using ClassesObjectsMethods.Interfaces;
using ClassesObjectsMethods.Models;

namespace ClassesObjectsMethods.Generators
{
    public class EmployeeReportGenerator : IReportGenerator<Employee>
    { 
        public void CreateReport(List<Employee> employees) 
        { 
            Console.WriteLine("{0,-36}  |  {1,-40}  |  {2,-25}  |  {3,-10}", 
                "UserId", "Company Name", "User FullName", "Salary"); 
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------"); 
            
            employees
                .OrderBy(u => u.Company.Name)
                .ThenByDescending(u => u.Job.Salary)
                .ToList()
                .ForEach(u=> Console.WriteLine("{0,20}  |  {1,-40}  |  {2,-25}  |  {3,-10}", 
                     u.Id, u.Company.Name, u.FullName, u.Job.Salary)); 
        }
    }
}