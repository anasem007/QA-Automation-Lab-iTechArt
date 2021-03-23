using System;

namespace PhoneShop.Exceptions
{
    [Serializable]
    public class ShopNotFoundException : Exception
    {
        public string ShopName { get; }
        
        public ShopNotFoundException() { }

        public ShopNotFoundException(string message) : base(message) { }

        public ShopNotFoundException(string message, Exception inner) : base(message, inner) { }
        
        public ShopNotFoundException(string message, string shopName) : this(message)
        {
            ShopName = shopName;
        }
    }
}