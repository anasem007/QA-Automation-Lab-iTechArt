using Bogus;
using ClassesObjectsMethods.Models;

namespace ClassesObjectsMethods.Factories
{
    public class CompanyFactory
    {
        public Faker<Company> CreateCompany()
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