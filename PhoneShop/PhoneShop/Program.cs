using System;
using PhoneShop.Controllers;
using PhoneShop.Utils;
using JsonReader = PhoneShop.Utils.JsonReader;

namespace PhoneShop
{
    class Program
    {
        private PhoneController _phoneController;
        
        static void Main(string[] args)
        {

            var shopController = new ShopController();
            var phoneController = new PhoneController();
            
            var shops = Converter.GetShopList(JsonReader.ReadJsonFile());
            var phones = Converter.GetPhoneList(shops);
            
            shopController.AddShops(shops);
            phoneController.AddPhones(phones);
            
            shopController.GetShops().ForEach(shop => shop.DisplayData());
            Console.WriteLine();
            
            var phoneShop = new PhoneShop(phoneController, shopController);

            phoneShop.OrderPhone();
        }
    }
}