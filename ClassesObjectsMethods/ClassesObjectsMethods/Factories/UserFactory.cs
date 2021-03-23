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

        public UserFactory()
        {
            _companyFactory = new CompanyFactory();
            _jobFactory = new JobFactory();
        }
        
        public UserFactory(CompanyFactory companyFactory, JobFactory jobFactory)
        {
            _companyFactory = companyFactory;
            _jobFactory = jobFactory;
        }

        public Faker<Employee> CreateEmployee()
        {
            return new Faker<Employee>()
                .Rules((f, e) =>
                {
                    e.FirstName = f.Name.FirstName();
                    e.LastName = f.Name.LastName();
                    e.Job = _jobFactory.CreateJob();
                    e.Company = _companyFactory.CreateCompany();
                });
        }
        
        public Faker<Candidate> CreateCandidate()
        {
            return new Faker<Candidate>()
                .Rules((f, c) =>
                {
                    c.FirstName = f.Name.FirstName();
                    c.LastName = f.Name.LastName();
                    c.Job = _jobFactory.CreateJob();
                }); 
        }
        
        private List<Employee> GenerateEmployees(int count = 1)
        {
            return CreateEmployee().Generate(count).ToList();
        }
        
        private List<Candidate> GenerateCandidates(int count = 1)
        {
            return CreateCandidate().Generate(count).ToList();
        }

        public List<T> GetUsers<T>(int count)
        {
            if (typeof(T) == typeof(Candidate))
            {
                return GenerateCandidates(count) as List<T>;
            }

            if (typeof(T) == typeof(Employee))
            {
                return GenerateEmployees(count) as List<T>;
            }

            return null;
        }
    }
    
}