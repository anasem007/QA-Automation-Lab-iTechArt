using System.Collections.Generic;

namespace PhoneShop.Interfaces
{
    public interface IReportGenerator<T>
    {
        void CreateReport(List<T> data);
    }
}