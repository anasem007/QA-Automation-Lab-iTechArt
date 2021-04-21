using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace IframeJSExecutor.pages
{
    public class MainPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;
        
        private static readonly By IframeBy = By.CssSelector("iframe.modal-iframe");
        private static readonly By IframeSearchBy = By.ClassName("search__input");
        private static readonly By IframeProductTitleBy = By.ClassName("product__title-link");
        private static readonly By IframeSearchCloseButtonBy = By.ClassName("search__close");
        private static readonly By SearchBy = By.Name("query");

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            OpenPage();
        }
        
        public void SwitchToIframe()
        {
            _driver.SwitchTo().Frame(Iframe);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl("https://www.onliner.by/");
        }
        
        public IWebElement Search => _driver.FindElement(SearchBy);
        public IWebElement Iframe => _wait.Until(ElementIsVisible(IframeBy));
        public IWebElement IframeSearch => _driver.FindElement(IframeSearchBy);
        public IWebElement IframeProductTitle => _wait.Until(ElementIsVisible(IframeProductTitleBy));
        public IWebElement IframeSearchCloseButton => _driver.FindElement(IframeSearchCloseButtonBy);
    }
}