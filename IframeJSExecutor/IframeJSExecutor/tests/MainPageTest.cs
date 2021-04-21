using System.Threading;
using IframeJSExecutor.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IframeJSExecutor.tests
{ 
    public class Tests 
    {
        private IWebDriver _driver;
        private MainPage _mainPage;
        private IJavaScriptExecutor _executor;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _mainPage = new MainPage(_driver);
            _executor = (IJavaScriptExecutor) _driver;
        }

        [Test]
        public void Test()
        {
            _mainPage.Search.SendKeys("Тостер"); 
            _mainPage.SwitchToIframe();
            var nameOfFirstProduct = _mainPage.IframeProductTitle.Text;
            _mainPage.IframeSearch.Clear();
            _mainPage.IframeSearch.SendKeys(nameOfFirstProduct);
            _executor.ExecuteScript("arguments[0].click();", _mainPage.IframeSearchCloseButton);
            _driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void TearDawn()
        { 
            _driver.Quit();
        }
    }
}