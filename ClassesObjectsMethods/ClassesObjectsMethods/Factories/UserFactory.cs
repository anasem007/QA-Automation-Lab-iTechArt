using System.Collections.Generic;
using System.Linq;
using Bogus;
using ClassesObjectsMethods.Models;

namespace ClassesObjectsMethods.Factories
{
    public class UserFactory
    {
        public Faker<Employee> CreateEmployee()
        {
            return new Faker<Employee>()
                .Rules((f, u) =>
                {
                    u.FirstName = f.Name.FirstName();
                    u.LastName = f.Name.LastName();
                    u.Job = CreateJob();
                    u.Company = CreateCompany();
                });
        }
        
        public Faker<Candidate> CreateCandidate()
        {
            return new Faker<Candidate>()
                .Rules((f, u) =>
                {
                    u.FirstName = f.Name.FirstName();
                    u.LastName = f.Name.LastName();
                    u.Job = CreateJob();
                }); 
        }
        
        public List<Employee> GenerateEmployees(int count = 1)
        {
            return CreateEmployee().Generate(count).ToList();
        }
        
        public List<Candidate> GenerateCandidates(int count = 1)
        {
            return CreateCandidate().Generate(count).ToList();
        }

        private Job CreateJob()
        {
            return new Faker<Job>()
                .Rules((f, j) =>
                {
                    j.Title = f.Name.JobTitle();
                    j.Description = f.Name.JobDescriptor();
                    j.Salary = f.Random.Int(200, 5000);
                });
        }
        
        private Company CreateCompany()
        {
            return new Faker<Company>()
                .Rules((f, c) =>
                {
                    c.Name = f.Company.CompanyName();
                    c.Country = f.Address.Country();
                    c.City = f.Address.City();
                    c.Street = f.Address.StreetAddress();
                });
        }
    }
    
}