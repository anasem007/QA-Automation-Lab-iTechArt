using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBasic.Pages
{
    public class CaloriesPage
    {
        private readonly IWebDriver _driver;

        private const string CaloriesPageUrl = "https://www.calc.ru/kalkulyator-kalorii.html";

        public CaloriesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private SelectElement PhysicalActivityDropDown => new SelectElement(_driver.FindElement(By.Name("activity")));
        
        private IWebElement Age => _driver.FindElement(By.Name("age"));
        
        private IWebElement Weight => _driver.FindElement(By.Name("weight"));
        
        private IWebElement Height => _driver.FindElement(By.Name("sm"));
       
        private IWebElement CalculateCaloriesButton => _driver.FindElement(By.Id("submit"));
        
        private IWebElement CaloriesForWeightLossMessage 
            => _driver.FindElement(By.XPath("//table[@class='result']/tbody/tr[1]"));
        
        private IWebElement CaloriesToKeepWeightConstantMessage 
            => _driver.FindElement(By.XPath("//td[contains(text(), '3028 ккал/день')]"));

        public CaloriesPage SelectPhysicalActivity()
        {
            PhysicalActivityDropDown.SelectByValue("1.4625");

            return this;
        }
        
        public CaloriesPage GoToCaloriesPage()
        {
            _driver.Navigate().GoToUrl(CaloriesPageUrl);

            return this;
        }

        public CaloriesPage TypeAge()
        {
            Age.SendKeys("35");

            return this;
        }
        
        public CaloriesPage TypeWeight()
        {
            Weight.SendKeys("85");

            return this;
        }

        public CaloriesPage TypeHeight()
        {
            Height.SendKeys("185");

            return this;
        }

        public CaloriesPage ClickCalculateCaloriesButton()
        {
            CalculateCaloriesButton.Click();

            Thread.Sleep(3000);
            
            return this;
        }

        public string GetInfoMessage()
        {
            return $"{CaloriesForWeightLossMessage.Text} {CaloriesToKeepWeightConstantMessage.Text}";
        } 
    }
}