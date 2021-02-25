using Bogus;
using ClassesObjectsMethods.Models;
using ClassesObjectsMethods.Utils;

namespace ClassesObjectsMethods.Factories
{
    public class JobFactory
    {
        public Faker<Job> CreateJob()
        {
            return new Faker<Job>()
                .Rules((f, j) =>
                {
                    j.Title = f.Name.JobTitle();
                    j.Description = f.Name.JobDescriptor();
                    j.Salary = f.Random.Int(Constants.MinSalary, Constants.MaxSalary);
                });
        }
    }
}