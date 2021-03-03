using System;

namespace PhoneShop.Exceptions
{
    [Serializable]
    public class PhoneNotFoundException : Exception
    {
        public string PhoneModel { get; }
        
        public PhoneNotFoundException() { }

        public PhoneNotFoundException(string message) : base(message) { }

        public PhoneNotFoundException(string message, Exception inner) : base(message, inner) { }
        
        public PhoneNotFoundException(string message, string phoneModel) : this(message)
        {
            PhoneModel = phoneModel;
        }
    }
}