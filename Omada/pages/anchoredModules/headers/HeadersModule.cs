using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Omada.Pages
{
    class HeadersModule
    {
        public string URL = TestContext.Parameters.Get("baseUrl");
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-727")]
        public IWebElement Products { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-731")]
        public IWebElement Company { get; set; }

        
        public HeadersModule(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void Load()
        {
            Driver.Navigate().GoToUrl(URL);
            System.Threading.Thread.Sleep(1000);

        }
    }
}
