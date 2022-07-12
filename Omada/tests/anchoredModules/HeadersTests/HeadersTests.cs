using NUnit.Framework;
using Omada.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SoftAssert;
using System;

namespace Omada.AnchoredModules
{
    [TestFixture]
    public class HeadersTests : TestBase
    {

        [Test]
        public void NavigateToOmadaIdentityCloud()
        {
            var headers = new HeadersModule(driver);
            var products = new Products(driver);
            var omadaIC = new OmadaIdentityCloudPage(driver);

            headers.Load();
            headers.Products.Click();
            products.OmadaIdentityCloudLink.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(omadaIC.DownloadGuideButton));

            var verifyScreenshots = TakeAndCompareScreenshots();

            AssertAll.Succeed(
                () => Assert.IsTrue(driver.Url.Contains(Urls.omadaIdentityCloud), ($"Actual url: {driver.Url}, differs from expected: {Urls.omadaIdentityCloud}")),
                () => Assert.IsTrue(verifyScreenshots, screenshotNotMatchingMsg));                
            Assert.Pass();
        }

    }
}

