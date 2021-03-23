using System.Collections.Generic;
using NLog;
using PhoneShop.Exceptions;
using PhoneShop.Models;
using PhoneShop.Repositories;

namespace PhoneShop.Controllers
{
    public class PhoneController
    {
        private readonly PhoneRepository _phoneRepository;
        
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public PhoneController()
        { 
            _phoneRepository = new PhoneRepository();
        }

        public void AddPhones(List<Phone> phones)
        {
            phones.ForEach(phone =>
            {
                _phoneRepository.Add(phone);
            });
        }
        
        public Phone FindAvailablePhonesByModelAndShopId(string model, int shopId)
        {
            try
            {
                return _phoneRepository.FindAvailablePhoneByModelAndShopId(model, shopId);
            }
            catch (PhoneNotFoundException e)
            {
                _logger.Error(e.Message);
            }

            return null;
        }

        public List<Phone> FindPhonesByModel(string model)
        {
            try
            {
                return _phoneRepository.FindByModel(model);
            }
            catch (PhoneNotFoundException e)
            {
               _logger.Error(e.Message);
            }

            return null;
        }

        public List<Phone> FindAvailablePhonesByModel(string model)
        {
            try
            {
                return _phoneRepository.FindAvailablePhonesByModel(model);
            }
            catch (PhoneNotFoundException e)
            {
                _logger.Error(e.Message);
            }

            return null;
        }

        public List<Phone> GetPhones()
        {
            return _phoneRepository.GetPhones();
        }
    }
}