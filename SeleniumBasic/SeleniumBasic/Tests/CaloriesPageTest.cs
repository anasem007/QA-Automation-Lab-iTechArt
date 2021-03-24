using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasic.Pages;

namespace SeleniumBasic.Tests
{
    public class CaloriesPageTest
    {
        private IWebDriver _driver;
        private CaloriesPage _page;
       
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _page = new CaloriesPage(_driver);
        }
        
        [Test]
        public void CalculateCalories()
        {
            _page
                .GoToCaloriesPage()
                .SelectPhysicalActivity()
                .TypeAge()
                .TypeHeight()
                .TypeWeight()
                .ClickCalculateCaloriesButton();

            var actualResult = _page.GetInfoMessage();
            
            Assert.AreEqual("Сколько нужно калорий в день, чтобы вес не менялся: 3028 ккал/день", actualResult);
        }
        
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}