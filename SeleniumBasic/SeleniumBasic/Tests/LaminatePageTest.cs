using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasic.Pages;

namespace SeleniumBasic.Tests
{
    public class LaminatePageTest
    {
        private IWebDriver _driver;
        private LaminatePage _page;
       
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _page = new LaminatePage(_driver);
        }
        
        [Test]
        public void CalculateLaminate()
        {
            _page
                .GoToLaminatePage()
                .SelectLayingMethod()
                .TypeRoomLength()
                .TypeRoomWidth()
                .TypeLaminatePanelLength()
                .TypeLaminatePanelWidth()
                .SelectLayingDirection()
                .ClickCalculationButton();

            var boardNumberMessage = _page.GetBoardsNumberMessage();
            var packagesNumberMessage = _page.GetPackagesNumberMessage();
            
            Assert.AreEqual("Требуемое количество досок ламината: 53", boardNumberMessage);
            Assert.AreEqual("Количество упаковок ламината: 7", packagesNumberMessage);
        }
        
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}