using System.Collections.Generic;

namespace ClassesObjectsMethods.Interfaces
{
    public interface IReportGenerator<T>
    {
        void CreateReport(List<T> data);
    }
}