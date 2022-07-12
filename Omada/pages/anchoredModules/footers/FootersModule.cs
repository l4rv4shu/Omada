using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Omada.Pages
{
    class FootersModule
    {
        public string URL = TestContext.Parameters.Get("baseUrl");
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-2263")]
        public IWebElement OmadaIdentityCloudLink { get; set; }

        public FootersModule(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void Load()
        {
            Driver.Navigate().GoToUrl(URL);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(OmadaIdentityCloudLink);
            actions.Perform();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
