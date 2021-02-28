using PhoneShop.Models;
using PhoneShop.Repositories;

namespace PhoneShop.Services
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;

        public ShopService()
        {
            _shopRepository = new ShopRepository();
        }

        public Shop FindShopByName(string name)
        {
            return _shopRepository.FindShopByName(name);
        }

        
        public void AddShop(Shop shop)
        {
            _shopRepository.AddShop(shop);
        }
    }
}