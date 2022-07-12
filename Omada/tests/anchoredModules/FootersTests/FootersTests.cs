using NUnit.Framework;
using Omada.Pages;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SoftAssert;
using System;

namespace Omada.AnchoredModules
{
    [TestFixture]
    public class FootersTests : TestBase
    {

        [Test]
        public void NavigateToOmadaIdentityCloud()
        {
            var footers = new FootersModule(driver);
            var omadaIC = new OmadaIdentityCloudPage(driver);

            footers.Load();
            footers.OmadaIdentityCloudLink.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(omadaIC.DownloadGuideButton));

            var verifyScreenshots = TakeAndCompareScreenshots();

            AssertAll.Succeed(
                () => Assert.IsTrue(driver.Url.Contains(Urls.omadaIdentityCloud), ($"Actual url: {driver.Url}, differs from expected: {Urls.omadaIdentityCloud}")),
                () => Assert.IsTrue(verifyScreenshots, screenshotNotMatchingMsg));                
        }
    }
}