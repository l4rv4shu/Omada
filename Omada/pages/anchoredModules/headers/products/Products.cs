using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Omada.Pages
{
    class Products
    {
        public IWebDriver Driver { get; set; }


        [FindsBy(How = How.CssSelector, Using = "a[href *= 'https://omadaidentity.com/products/omada-identity-cloud/']")]
        public IWebElement OmadaIdentityCloudLink { get; set; }


        public Products(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
