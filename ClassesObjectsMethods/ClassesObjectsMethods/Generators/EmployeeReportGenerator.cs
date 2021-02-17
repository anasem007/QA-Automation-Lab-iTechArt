using System.Collections.Generic;
using System.Linq;
using ClassesObjectsMethods.Interfaces;
using ClassesObjectsMethods.Models;

namespace ClassesObjectsMethods.Generators
{
    public class EmployeeReportGenerator : IReportGenerator<Employee>
    {
       public List<Employee> getReport(List<Employee> employees)
       {
           var sortedEmployees = (List<Employee>) employees.OrderBy(e => e.Company.Name)
               .ThenByDescending(c => c.Job.Salary);

           return sortedEmployees;
       }
    }
}