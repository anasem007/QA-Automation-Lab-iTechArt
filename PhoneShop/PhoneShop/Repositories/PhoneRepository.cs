using System.Collections.Generic;
using System.Linq;
using PhoneShop.Exceptions;
using PhoneShop.Models;

namespace PhoneShop.Repositories
{
    public class PhoneRepository
    {
        private readonly List<Phone> _phones;

        public PhoneRepository()
        {
            _phones = new List<Phone>();
        }

        public List<Phone> FindByModel(string model)
        {
            var phones = _phones
                    .Where(phone => phone.Model.Equals(model))
                    .ToList();

            if (phones.Count == 0)
            {
                throw new PhoneNotFoundException($"Phones with model " +
                                                 $"{model} don't exist.", model);
            }
            
            return phones;
        }

        public List<Phone> FindAvailablePhonesByModel(string model)
        {
            var phones = FindByModel(model)
                .Where(phone => phone.IsAvailable)
                .ToList();

            if (phones.Count == 0)
            {
                throw new PhoneNotFoundException($"The phone of  model {model} is not in stock.",
                    model);
            }

            return phones;
        }
        
        public Phone FindAvailablePhoneByModelAndShopId(string model, int shopId)
        {
            return FindAvailablePhonesByModel(model)
                .First(p => p.ShopId == shopId);
        }

        public void Add(Phone phone)
        {
            _phones.Add(phone);
        }

        public List<Phone> GetPhones()
        {
            return _phones;
        }
    }
}