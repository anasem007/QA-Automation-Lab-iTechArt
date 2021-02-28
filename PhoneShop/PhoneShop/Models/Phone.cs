using PhoneShop.Model;

namespace PhoneShop.Models
{
    public class Phone
    {
        public string Model { get; set; }

        public OperationSystemType OperationSystemType { get; set; }

        public string MarketLaunchDate { get; set; }

        public string Price { get; set; }

        public bool IsAvailable { get; set; }

        public int ShopId { get; set; }
    }
}