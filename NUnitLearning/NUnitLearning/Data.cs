using System.Collections;
using NUnit.Framework;

namespace NUnitLearning
{
    public class Data
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4).SetName("12 divided by 3 is 4");
                yield return new TestCaseData(12, 2).Returns(6).SetName("12 divided by 2 is 6");
            }
        }  
        
        public static object[] DividedCases =
        {
            new object[] {9, 3, 3},
            new object[] {4, 2, 2}
        };
    }
}