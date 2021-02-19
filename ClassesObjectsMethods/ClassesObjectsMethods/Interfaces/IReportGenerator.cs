using System.Collections.Generic;

namespace ClassesObjectsMethods.Interfaces
{
    public interface IReportGenerator<T>
    {
        void createReport(List<T> data);
    }
}