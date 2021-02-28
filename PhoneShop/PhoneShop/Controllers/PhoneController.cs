using System.Collections.Generic;
using PhoneShop.DTOs;
using PhoneShop.Models;
using PhoneShop.Services;

namespace PhoneShop.Controllers
{
    public class PhoneController
    {
        private readonly PhoneService _phoneService;

        public PhoneController()
        { 
            _phoneService = new PhoneService();
        }

        public void AddPhones(List<Phone> phones)
        {
            phones.ForEach(phone =>
            {
                _phoneService.AddPhone(phone);
            });
        }
        
        public OrderResponseDto FindAvailablePhonesByModelAndShopId(string model, int shopId)
        {
            var phone = _phoneService.FindAvailablePhoneByModelAndShopId(model, shopId);
            var responseDto = OrderResponseDto.ConvertFromPhone(phone);

            return responseDto;
        }

        public List<Phone> FindPhonesByModel(string model)
        {
            return _phoneService.FindPhonesByModel(model);
        }
        
        public List<Phone> FindAvailablePhonesByModel(string model)
        {
            return _phoneService.FindAvailablePhonesByModel(model);
        }

        public List<Phone> GetPhones()
        {
            return _phoneService.GetPhones();
        }

       
    }
}