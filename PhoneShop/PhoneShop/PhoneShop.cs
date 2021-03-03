using System;
using System.Collections.Generic;
using NLog;
using PhoneShop.Controllers;
using PhoneShop.Generators;
using PhoneShop.Models;

namespace PhoneShop
{
    public class PhoneShop
    {
        private readonly PhoneController _phoneController;
        private readonly ShopController _shopController;
        
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        private bool _phonesWithoutGivenModel = true;
        private bool _shopNotExist = true;

        public PhoneShop(PhoneController phoneController, ShopController shopController)
        {
            _phoneController = phoneController;
            _shopController = shopController;
        }
        
        public void OrderPhone()
        {
            while (_phonesWithoutGivenModel)
            {
                var phoneModel = DisplayMessageWhatPhoneDoYouWant();
                
                Console.WriteLine();

                if (_phoneController.FindPhonesByModel(phoneModel) == null) continue;
                
                var availablePhones = _phoneController
                    .FindAvailablePhonesByModel(phoneModel);
                
                if (availablePhones == null) continue;
                   
                DisplayMessageModelFound();
                        
                _phonesWithoutGivenModel = false;

                var shopsWithAvailablePhones = _shopController
                    .FindShopsByIds(availablePhones);

                DisplayAvailablePhones(availablePhones);
                
                DisplayShopsAvailablePhones(shopsWithAvailablePhones);

                DetermineInWhichShopBuyPhone(phoneModel, shopsWithAvailablePhones);
            }
        }

        private void DetermineInWhichShopBuyPhone(string phoneModel, 
            List<Shop> shopsWithAvailablePhones)
        {
            while (_shopNotExist)
            {
                var shopName = DisplayMessageInWhichShopWantBuyPhone(phoneModel);
                
                var shop = _shopController.FindShopByName(shopName);

                if (!shopsWithAvailablePhones.Contains(shop)) continue;

                var phoneResult = _phoneController
                    .FindAvailablePhonesByModelAndShopId(phoneModel, shop.Id);

                DisplayMessageOrderIsCompleted(phoneResult);
                                
                _shopNotExist = false;
            }
        }

        private string DisplayMessageWhatPhoneDoYouWant()
        {
            _logger.Info("What phone do you want to buy?");
            _logger.Info("Enter phone model: ");
            
           return Console.ReadLine();
        }
        
        private void DisplayMessageModelFound()
        {
            _logger.Info("The required model has been found.");
            Console.WriteLine();
        }
        
        private string DisplayMessageInWhichShopWantBuyPhone(string phoneModel)
        {
            _logger.Info($"In which shop do you want to buy {phoneModel}?");
            _logger.Info("Enter shop name: ");

            return Console.ReadLine();
        }

        private void DisplayMessageOrderIsCompleted(Phone phoneResult)
        {
            Console.WriteLine();
            _logger.Info($"Your order {phoneResult.Model}, {phoneResult.OperationSystemType}," +
                         $"{phoneResult.MarketLaunchDate} " +
                         $"for the amount {phoneResult.Price} has been successfully completed! ");
        }

        private void DisplayAvailablePhones(List<Phone> phones)
        {
            var phoneReportGenerator = new PhoneReportGenerator();
            
            _logger.Info("AVAILABLE PHONES");
            
            phoneReportGenerator.CreateReport(phones);
            Console.WriteLine();
        }
        
        private void DisplayShopsAvailablePhones(List<Shop> shops)
        {
            var shopReportGenerator = new ShopReportGenerator();
           
            _logger.Info("Shops where you can buy goods:");
            
            shopReportGenerator.CreateReport(shops);
        }
    }
}