using System.Collections.Generic;
using PhoneShop.Model;
using PhoneShop.Models;
using PhoneShop.Repositories;

namespace PhoneShop.Services
{
    public class PhoneService
    {
        private readonly PhoneRepository _phoneRepository;

        public PhoneService()
        {
            _phoneRepository = new PhoneRepository();
        }

        public void AddPhone(Phone phone)
        {
            _phoneRepository.AddPhone(phone);
        }


        public List<Phone> FindPhonesByModel(string model)
        {
            return _phoneRepository.FindPhonesByModel(model);
        }

        public List<Phone> FindAvailablePhonesByModel(string model)
        {
            return _phoneRepository.FindAvailablePhonesByModel(model);
        }

        public Phone FindAvailablePhoneByModelAndShopId(string model, int shopId)
        {
            return _phoneRepository.FindAvailablePhoneByModelAndShopId(model, shopId);
        }

        public List<Phone> GetPhones()
        {
            return _phoneRepository.GetPhones();
        }
            
    }
}