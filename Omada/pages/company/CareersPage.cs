using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Omada.Pages
{
    class CareersPage
    {
        public string URL = TestContext.Parameters.Get("baseUrl") + Urls.careerPage;
        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.LinkText, Using = "Job positions")]
        public IWebElement JobPositionsButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Search our job openings")]
        public IWebElement SearchJobOpeningsButton { get; set; }

        public CareersPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Load()
        {
            Driver.Navigate().GoToUrl(URL);
        }
        //workaround with thread.sleep usage; couldn't find a way to get it working in any other way within 1h.
        public void OpenEmployeeModule(IWebElement employee_picture)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(employee_picture);
            actions.Perform();
            employee_picture.Click();
            System.Threading.Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].click();", employee_picture);
            System.Threading.Thread.Sleep(1000);

        }
    }
}
