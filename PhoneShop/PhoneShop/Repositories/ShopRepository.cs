using System.Collections.Generic;
using System.Linq;
using PhoneShop.Exceptions;
using PhoneShop.Models;

namespace PhoneShop.Repositories
{
    public class ShopRepository
    {
        private readonly List<Shop> _shops;

        public ShopRepository()
        {
            _shops = new List<Shop>();
        }

        public Shop FindByName(string name)
        {
            foreach (var shop in _shops.Where(shop => shop.Name.Equals(name))) return shop;

            throw new ShopNotFoundException($"Shop {name} doesn't exist.", 
                name);
        }

        public Shop FindById(int id)
        {
            foreach (var shop in _shops.Where(shop => shop.Id == id)) return shop;

            throw new ShopNotFoundException($"Shop doesn't exist.");
        }

        public void Add(Shop shop)
        {
            _shops.Add(shop);
        }
    }
}