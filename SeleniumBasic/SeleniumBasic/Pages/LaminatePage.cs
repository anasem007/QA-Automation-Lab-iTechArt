using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasic.Pages
{
    public class LaminatePage
    {
        private readonly IWebDriver _driver;

        private const string LaminatePageUrl = "https://calc.by/building-calculators/laminate.html";

        public LaminatePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private SelectElement LaminateDropDown => new SelectElement(_driver.FindElement(By.Id("laying_method_laminate")));

        private IWebElement RoomLengthField => _driver.FindElement(By.Id("ln_room_id"));

        private IWebElement RoomWidthField => _driver.FindElement(By.Id("wd_room_id"));

        private IWebElement LaminatePanelLengthField => _driver.FindElement(By.Id("ln_lam_id"));

        private IWebElement LaminatePanelWidthField => _driver.FindElement(By.Id("wd_lam_id"));

        private IWebElement LayingDirectionButton => _driver.FindElement(By.CssSelector("#direction-laminate-id1"));

        private IWebElement CalculationButton => _driver.FindElement(By.XPath("//*[text() = 'Рассчитать']"));

        private IWebElement BoardNumberMessage => 
            _driver.FindElement(By.CssSelector("div.calc-result > div:nth-child(1)"));

        private IWebElement PackagesNumberMessage =>
            _driver.FindElement(By.CssSelector("div.calc-result > div:nth-child(2)"));
        
        public LaminatePage GoToLaminatePage()
        {
            _driver.Navigate().GoToUrl(LaminatePageUrl);

            return this;
        }

        public LaminatePage SelectLayingMethod()
        {
            LaminateDropDown.SelectByIndex(0);
            LaminateDropDown.SelectByValue("1");
            LaminateDropDown.SelectByText("с использованием отрезанного элемента");
            
            return this;
        }
        
        public LaminatePage TypeRoomLength()
        {
            RoomLengthField.Clear();
            RoomLengthField.SendKeys("500");

            return this;
        }
        
        public LaminatePage TypeRoomWidth()
        {
            RoomWidthField.Clear();
            RoomWidthField.SendKeys("400");

            return this;
        }

        public LaminatePage TypeLaminatePanelLength()
        {
            LaminatePanelLengthField.Clear();
            LaminatePanelLengthField.SendKeys("2000");

            return this;
        }

        public LaminatePage TypeLaminatePanelWidth()
        {
            LaminatePanelWidthField.Clear();
            LaminatePanelWidthField.SendKeys("200");

            return this;
        }

        public LaminatePage SelectLayingDirection()
        {
            LayingDirectionButton.Click();

            return this;
        }

        public LaminatePage ClickCalculationButton()
        {
            CalculationButton.Click();

            Thread.Sleep(3000);
            
            return this;
        }

        public string GetBoardsNumberMessage()
        {
            return BoardNumberMessage.Text;
        }
        
        public string GetPackagesNumberMessage()
        {
            return PackagesNumberMessage.Text;
        }
    }
}