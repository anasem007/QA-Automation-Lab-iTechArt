using System;
using NUnit.Framework;

namespace NUnitLearning.Tests
{
    public class TestCaseTest
    {
        [TestCase("admin")]
        [TestCase("user")]
        public void RoleTest(string userName)
        {
            if (userName.Equals("admin"))
            {
                var ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        throw new ArgumentException($"This is {userName}", userName);
                    });
                
                Assert.AreEqual("This is admin (Parameter 'admin')", ex.Message);
                Assert.That(ex.ParamName, Is.EqualTo("admin"));
            }
            else
            {
                Assert.AreEqual("user", userName);
            }
        }

        [TestCaseSource(typeof(Data), nameof(Data.DividedCases))]
        public void DivideTest(int a, int b, int result)
        {
            Assert.AreEqual(a / b, result);
        }
        
        [TestCaseSource(typeof(Data), nameof(Data.TestCases))]
        public int DivideTest(int a, int b)
        {
            return a / b;
        }
    }
}