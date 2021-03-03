using System.Collections.Generic;
using PhoneShop.Exceptions;
using PhoneShop.Models;
using PhoneShop.Repositories;

namespace PhoneShop.Controllers
{
    public class ShopController
    {
        private readonly ShopRepository _shopRepository;
        
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
       
        public ShopController()
        {
            _shopRepository = new ShopRepository();
        }

        public Shop FindShopByName(string name)
        {
            try
            {
                return _shopRepository.FindByName(name);
            }
            catch (ShopNotFoundException e)
            {
                _logger.Error(e.Message);
            }

            return null;
        }

        public List<Shop> FindShopsByIds(List<Phone> phones)
        {
            try
            {
                var shops = new List<Shop>();

                phones.ForEach(phone =>
                {
                    if (shops.Contains(_shopRepository.FindById(phone.ShopId))) return;
                    shops.Add(_shopRepository.FindById(phone.ShopId));
                });

                return shops;
            }

            catch (ShopNotFoundException e)
            {
                _logger.Error(e.Message);
            }

            return null;
        }

        public void AddShops(List<Shop> shops)
        {
            shops.ForEach(shop =>
            {
                _shopRepository.Add(shop);
            });
        }
    }
}