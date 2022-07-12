using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Omada.Pages
{
    class OmadaIdentityCloudPage
    {
        public string URL = TestContext.Parameters.Get("baseUrl");
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href *= 'https://omadaidentity.com/resources/product-brief/omada-identity-cloud-guide/']")]
        public IWebElement DownloadGuideButton { get; set; }        


        public OmadaIdentityCloudPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
