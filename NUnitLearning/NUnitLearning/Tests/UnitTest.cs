using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitLearning.Tests
{
    public class Tests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            Console.Out.WriteLine("SetUp...");
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Pass()
        {
            Assert.Pass();
        }

        [Test]
        public void Ignore()
        {
            Assert.Ignore();
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive();
        }

        [Test]
        [Category("SmokeTest")]
        [Category("regression")]
        [Property("Priority", 2)]
        public void TestSum()
        {
            Assert.AreEqual(5, _calculator.Sum(2, 3));
        }

        [Test]
        [Category("SmokeTest")]
        [Property("Priority", 1)]
        public void TestDiv()
        {
            Assert.AreEqual(4, _calculator.Div(8, 2));
        }

        [Test]
        [Category("regression")]
        public void TestDivZero()
        {
            Assert.Throws<DivideByZeroException>(
                delegate { _calculator.Div(8, 0); });
        }

        [Test]
        [Property("Priority", 1)]
        public void ConditionAsserIsEmpty()
        {
            var str = "";
            
            Assert.IsEmpty(str);
        }
        
        [Test]
        public void ConditionAssertTrue()
        {
            var a = 1;
            var b = 0;
           
            Assert.True(_calculator.Compare(a, b));
        }
        
        [Test]
        [Property("Priority", 1)]
        public void ConditionAssertFalse()
        {
            var a = 1;
            var b = 2;
            
            Assert.False(_calculator.Compare(a, b));
        }

        public void AssertContains()
        {
            var firstUser = new User() {Id = 3, Age = 32};
            var secondUser = new User() {Id = 2, Age = 17};
            var thirdUser = new User() {Id = 1, Age = 17};

            var users = new Stack<User>();

            users.Push(firstUser);
            users.Push(secondUser);
            users.Push(thirdUser);
            
            Assert.Contains(secondUser, users);

        }
        
        [Test]
        public void ComparisonAssertAreSame()
        {
            User expected = new User() { Id = 2, Age = 21 };  
            
            var userList = new Stack();
            userList.Push(expected);
           
            var actual = userList.Pop();
            
            Assert.AreSame(expected, actual);  
        }

        [Test]
        public void ComparisonAssertGreater()
        {
            int a = 30;
            int b = 1;
            
            Assert.Greater(a, b);
        }
        
        [Test]
        public void ComparisonAssertLess()
        {
            int a = 0;
            int b = 1;
            
            Assert.Less(a,b);
        }
        
       
        [TestCase(1, 2)]
        [TestCase(1, 1)]
        public void ComparisonAssertLessOrEqual(int a, int b)
        {
            Assert.LessOrEqual(a,b);
        }
        
        [TestCase(2, 1)]
        [TestCase(1, 1)]
        public void ComparisonAssertGreaterOrEqual(int a, int b)
        {
            Assert.GreaterOrEqual(a,b);
        }
        
        [Test]
        public void AssertMultiple()
        {
           Assert.Multiple(() =>
               {
                   Assert.AreEqual(3, _calculator.Div(6,2));
                   Assert.AreEqual(6, _calculator.Sum(3,3));
                   Assert.True(_calculator.Compare(5,4));
               });
        }
        

        [Test]
        [Ignore("Ignore a test")]
        public void IgnoredTest()
        {
            Assert.Fail();
        }
        
        [TearDown]
        public void TearDown()
        {
            Console.Out.WriteLine("TearDown...");
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.Out.WriteLine("OneTimeTearDown...");
        }
    }
}