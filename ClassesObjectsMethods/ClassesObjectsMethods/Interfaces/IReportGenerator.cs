using System.Collections.Generic;

namespace ClassesObjectsMethods.Interfaces
{
    public interface IReportGenerator<T>
    {
        List<T> getReport(List<T> data);
    }
}