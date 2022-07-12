using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Omada.Pages
{
    class CookiesWindow
    {
        public string URL = TestContext.Parameters.Get("baseUrl");
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.Id, Using = "CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection")]
        public IWebElement AllowSelectedCookies { get; set; }

        public CookiesWindow(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void AllowCookies()
        {
            Driver.Navigate().GoToUrl(URL);
            new WebDriverWait(Driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(AllowSelectedCookies));
            AllowSelectedCookies.Click();
        }
    }
}
