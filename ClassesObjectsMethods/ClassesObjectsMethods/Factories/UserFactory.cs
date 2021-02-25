using System.Collections.Generic;
using System.Linq;
using Bogus;
using ClassesObjectsMethods.Models;

namespace ClassesObjectsMethods.Factories
{
    public class UserFactory
    {
        private readonly CompanyFactory _companyFactory;
        private readonly JobFactory _jobFactory;

        public UserFactory(CompanyFactory companyFactory, JobFactory jobFactory)
        {
            _companyFactory = companyFactory;
            _jobFactory = jobFactory;
        }

        public Faker<Employee> CreateEmployee()
        {
            return new Faker<Employee>()
                .Rules((f, u) =>
                {
                    u.FirstName = f.Name.FirstName();
                    u.LastName = f.Name.LastName();
                    u.Job = _jobFactory.CreateJob();
                    u.Company = _companyFactory.CreateCompany();
                });
        }
        
        public Faker<Candidate> CreateCandidate()
        {
            return new Faker<Candidate>()
                .Rules((f, u) =>
                {
                    u.FirstName = f.Name.FirstName();
                    u.LastName = f.Name.LastName();
                    u.Job = _jobFactory.CreateJob();
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
    }
    
}