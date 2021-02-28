using System.Collections.Generic;
using System.Linq;
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

        public List<Phone> FindPhonesByModel(string model)
        {
            var phonesWithDesiredModel =
                from phone in _phones
                where phone.Model == model
                select phone;

            return phonesWithDesiredModel.ToList();
        }

        public List<Phone> FindAvailablePhonesByModel(string model)
        {
            var phones = FindPhonesByModel(model);
           
            var availablePhonesWithDesiredModel =
                from phone in phones
                where phone.IsAvailable
                select phone;
            
            return availablePhonesWithDesiredModel.ToList();
        }
        
        public Phone FindAvailablePhoneByModelAndShopId(string model, int shopId)
        {
            var phones = FindAvailablePhonesByModel(model);
           
            var availablePhoneWithDesiredModelAndShopId =
                from phone in phones
                where phone.ShopId == shopId
                select phone;

            return availablePhoneWithDesiredModelAndShopId as Phone;
        }

        public void AddPhone(Phone phone)
        {
            _phones.Add(phone);
        }

        public List<Phone> GetPhones()
        {
            return _phones;
        }
    }
    
        
        
}