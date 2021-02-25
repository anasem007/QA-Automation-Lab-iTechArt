using System;
using Bogus;
using ClassesObjectsMethods.Factories;
using ClassesObjectsMethods.Generators;
using ClassesObjectsMethods.Models;
using ClassesObjectsMethods.Utils;

namespace ClassesObjectsMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new UserFactory();

            Candidate candidate = factory.CreateCandidate();
            candidate.DisplayData();

            Employee employee = factory.CreateEmployee();
            employee.DisplayData();
            
            Console.WriteLine("\n");

            var candidates = factory.GenerateCandidates(new Faker()
                .Random.Int(Constants.MinUsersNumber, Constants.MaxUsersNumber));
            var reportGenerator1 = new CandidateReportGenerator();
            reportGenerator1.CreateReport(candidates);
            
            Console.WriteLine("\n");

            var employees = factory.GenerateEmployees(new Faker()
                .Random.Int(Constants.MinUsersNumber, Constants.MaxUsersNumber));
            var reportGenerator2 = new EmployeeReportGenerator();
            reportGenerator2.CreateReport(employees);
        }
    }
}