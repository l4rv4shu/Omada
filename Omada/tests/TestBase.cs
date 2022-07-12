using ImageMagick;
using NUnit.Framework;
using Omada.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Diagnostics;
using System.Reflection;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
//using WDSE;
//using WDSE.Decorators;
//using WDSE.ScreenshotMaker;

namespace Omada
{
    [SetUpFixture]
    public abstract class TestBase
    {
        public static IWebDriver driver;
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string referencePath;
        public static string screenshotNotMatchingMsg = "Screenshot not matching the reference. Check difference screenshot";

        [OneTimeSetUp]
        public virtual void Set()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var cookies = new CookiesWindow(driver);
            cookies.AllowCookies();

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
        //This method will take and compare screenshot with pre-defined reference. 
        //Note: Accuary rate of comparison is lowered down due to dynamic elements being present on app. 
        public bool TakeAndCompareScreenshots(double accuary_rate = 0.85, string name = null)
        {
            StackFrame frame = new StackFrame(1);
            string callingMethodName = frame.GetMethod().Name;
            string callingClassName = frame.GetMethod().DeclaringType.FullName.Replace("Omada.", "").Replace(".", "-");
            string _callingClassName = frame.GetMethod().DeclaringType.FullName.Replace("Omada.", "").Replace(".", "/");
            string screenshot_path = null;
            string reference_path = null;

            if (name == null)
            {
                referencePath = ($"{path}/tests/{_callingClassName}/{callingMethodName}.jpg");
                screenshot_path = ($"{path}/{callingClassName}-{callingMethodName}.jpg");
            }

            else
            {
                referencePath = ($"{path}/tests/{_callingClassName}/{callingMethodName}-{name}.jpg");
                screenshot_path = ($"{path}/{callingClassName}-{callingMethodName}-{name}.jpg");

            }
            System.Threading.Thread.Sleep(300);            
            var vcs = new VerticalCombineDecorator(new ScreenshotMaker());
            driver.TakeScreenshot(vcs).ToMagickImage().Write(screenshot_path);
            System.Threading.Thread.Sleep(300);

            return ProcessScreenshots(referencePath, screenshot_path, accuary_rate);
        }

        public bool ProcessScreenshots(string reference, string actual, double accuary_rate)
        {
            using (var actual_image = new MagickImage(actual))
            {
                using (var ref_image = new MagickImage(reference))
                {
                    using (var imgDiff = new MagickImage())
                    {
                        var output_file = actual.Substring(0, actual.Length - 4) + "_diff.png";
                        double diff = ref_image.Compare(actual_image, new ErrorMetric(), imgDiff);
                        imgDiff.Write(output_file);
                        TestContext.AddTestAttachment(output_file, "difference_screenshot");
                        return (diff > accuary_rate);
                    }
                }
            }
        }

    }

}

