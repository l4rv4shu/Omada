using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Omada.Pages
{
    class CompanyPage
    {
        public IWebDriver Driver { get; set; }


        [FindsBy(How = How.CssSelector, Using = "a[href *= 'https://omadaidentity.com/company/careers/']")]
        public IWebElement CareersLink { get; set; }


        public CompanyPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
