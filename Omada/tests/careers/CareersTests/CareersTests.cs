using NUnit.Framework;
using Omada.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SoftAssert;
using System;

namespace Omada.Careers
{
    [TestFixture]
    public class CareersTests : TestBase
    {
        //I would split this test into 2: One would be headers test (Navigate from headers -> careers), 
        //then second (this one): Load careers site directly then navigate to open job positions.
        //Right now, this test does not excactly fit into 'CareersTest'. I would place it in some E2E tests instead.
        [Test]
        public void NavigateToOpenJobsPosition()
        {
            var headers = new HeadersModule(driver);
            var company = new CompanyPage(driver);
            var careers = new CareersPage(driver);

            headers.Load();
            headers.Company.Click();
            company.CareersLink.Click();
            careers.JobPositionsButton.Click();

            var verifyScreenshots = TakeAndCompareScreenshots();
            //normally, I would add landing/external page definition to pages, and define "ctl00_ctl00_zoomBtn" there, but I'll skip it
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_zoomBtn")));

            AssertAll.Succeed(
                () => Assert.IsTrue(driver.Url.Contains(Urls.jobPositionLandingPage), ($"Actual url: {driver.Url}, differs from expected: {Urls.jobPositionLandingPage}")),
                () => Assert.IsTrue(verifyScreenshots, screenshotNotMatchingMsg));
            Assert.Pass();
        }

        //Same situation:
        //I would split this test into 2: One would be headers test (Navigate from headers -> careers), 
        //then second (this one): Load careers site directly then navigate to open job positions.
        //Right now, this test does not excactly fit into 'CareersTest'. I would place it in some E2E tests instead.
        public void NavigateToSearchJobOpenings()
        {
            var headers = new HeadersModule(driver);
            var company = new CompanyPage(driver);
            var careers = new CareersPage(driver);

            headers.Load();
            headers.Company.Click();
            company.CareersLink.Click();
            careers.SearchJobOpeningsButton.Click();

            var verifyScreenshots = TakeAndCompareScreenshots();
            //normally, I would add landing/external page definition to pages, and define "ctl00_ctl00_zoomBtn" there, but I'll skip it
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_zoomBtn")));

            AssertAll.Succeed(
                () => Assert.IsTrue(driver.Url.Contains(Urls.jobPositionLandingPage), ($"Actual url: {driver.Url}, differs from expected: {Urls.jobPositionLandingPage}")),
                () => Assert.IsTrue(verifyScreenshots, screenshotNotMatchingMsg));
            Assert.Pass();
        }

        [TestCase("daria-czajkowska")]
        [TestCase("gry-collignon")]

        public void DisplayOmadians(String omada_empoyee)
        {
            //this part of app seems to have a little bug: Omadian's details should not be scrollable.
            //Thats why reference screenshots are odd.
            var careers = new CareersPage(driver);
            careers.Load();
            //define selector for each testcase
            var selector = ($"[data-id='{omada_empoyee}']");
            IWebElement employee_picture = driver.FindElement(By.CssSelector(selector));
            careers.OpenEmployeeModule(employee_picture);

            //this could be probably overloaded to avoid providing screenshot comparison accuary rate
            var verifyScreenshots = TakeAndCompareScreenshots(0.85, omada_empoyee);
            AssertAll.Succeed(
                () => Assert.IsTrue(verifyScreenshots, screenshotNotMatchingMsg));
            Assert.Pass();



        }
    }
}