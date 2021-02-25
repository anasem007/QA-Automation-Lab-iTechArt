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
            var candidateReportGenerator = new CandidateReportGenerator();
            candidateReportGenerator.CreateReport(candidates);
            
            Console.WriteLine("\n");

            var employees = factory.GenerateEmployees(new Faker()
                .Random.Int(Constants.MinUsersNumber, Constants.MaxUsersNumber));
            var employeeReportGenerator = new EmployeeReportGenerator();
            employeeReportGenerator.CreateReport(employees);
        }
    }
}