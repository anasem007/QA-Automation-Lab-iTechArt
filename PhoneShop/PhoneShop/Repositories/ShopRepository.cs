using System.Collections.Generic;
using System.Linq;
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

        public Shop FindShopByName(string name)
        {
            var shopWithGivenName =
                from shop in _shops
                where shop.Name.Equals(name)
                select shop;
            
            return  shopWithGivenName as Shop;
        }

        public void AddShop(Shop shop)
        {
            _shops.Add(shop);
        }
    }
}