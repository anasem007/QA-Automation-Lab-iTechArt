using System;
using System.Collections.Generic;
using PhoneShop.Model;
using PhoneShop.Models;
using PhoneShop.Repositories;
using PhoneShop.Services;

namespace PhoneShop.Controllers
{
    public class ShopController
    {
        private readonly ShopService _shopService;

        public ShopController()
        {
            _shopService = new ShopService();
        }

        public Shop FindShopByName(string name)
        {
            Shop shop;
            try
            { 
                shop = _shopService.FindShopByName(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Такого магазина не существует. Пожалуйста, введите название магазина заново.");
                Console.WriteLine(e);
                throw;
            }

            return shop;
        }

        public void AddShops(List<Shop> shops)
        {
            shops.ForEach(shop =>
            {
                _shopService.AddShop(shop);
            });
        }
    }
}