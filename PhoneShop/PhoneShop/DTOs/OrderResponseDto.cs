using PhoneShop.Model;
using PhoneShop.Models;

namespace PhoneShop.DTOs
{
    public class OrderResponseDto
    {
        public string Model { get; set; }

        public OperationSystemType OperationSystemType { get; set; }

        public string MarketLaunchDate { get; set; }

        public string Price { get; set; }

        public static OrderResponseDto ConvertFromPhone(Phone phone)
        {
            var responseDto = new OrderResponseDto
            {
                Model = phone.Model,
                OperationSystemType = phone.OperationSystemType,
                MarketLaunchDate = phone.MarketLaunchDate,
                Price = phone.Price
            };


            return responseDto;
        }

    }
}