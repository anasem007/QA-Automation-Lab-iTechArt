using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PhoneShop.Models;

namespace PhoneShop.Utils
{
    public class Converter
    {
        public static List<Shop> GetShopList(string jsonObject)
        {
            return JsonConvert
                .DeserializeObject<Dictionary<string, List<Shop>>>(jsonObject)
                .SelectMany(pair => pair.Value).ToList();
        }
        
        public static List<Phone> GetPhoneList(List<Shop> shops)
        {
            var phones = new List<Phone>();
            
            shops.ForEach(shop =>
            {
                shop.Phones.ForEach(phone => phones.Add(phone));
            });
            
            return phones;
        }
    }
}