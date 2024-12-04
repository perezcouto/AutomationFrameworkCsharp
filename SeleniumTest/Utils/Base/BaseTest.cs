using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using SeleniumTest.Utils;
using SeleniumTest.Utils.ReportUtil;
using NUnit.Framework.Interfaces;

namespace SeleniumTest.Utils.Base
{
    public class BaseTest
    {
        public static IWebDriver driver { get; set; }
        private DriverUtil driverUtil;
        private string URL = TestContext.Parameters["URL"];
        private string BROWSER = TestContext.Parameters["browser"];


        [OneTimeSetUp]
        public void GlobalSetup()
        {
            driverUtil = new DriverUtil();
            ExtentTestManager.CreateParentTest(GetType().Name, "Selenium Webdriver + C#");
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentService.GetExtent().Flush();
        }

        [SetUp]
        public void Setup()
        {
            var cats = TestContext.CurrentContext.Test.Properties["Category"];
            string[] categoryList = cats.Cast<string>().ToArray();
            var aut = TestContext.CurrentContext.Test.Properties["Author"];
            string[] authorList = aut.Cast<string>().ToArray();
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name, "Desc", categoryList, authorList);
            driver = driverUtil.GetDriver(BROWSER);
            driver.Navigate().GoToUrl(URL);

        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
                var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);

                switch (status)
                {
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errorMessage);
                        ReportLog.Fail(stackTrace);
                        ReportLog.Fail("Screenshot:", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
                        break;
                    case TestStatus.Skipped:
                        ReportLog.Skip("Test Skipped");
                        break;
                    case TestStatus.Warning:
                        ReportLog.Warning("Warning!");
                        ReportLog.Warning(errorMessage);
                        ReportLog.Warning(stackTrace);
                        break;
                    case TestStatus.Passed:
                        ReportLog.Pass("Test Passed");
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
            finally
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        public Media CaptureScreenshot(string name)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string reportDirImage = Path.Combine(Utility.GetProjectRootDirectory(), "Report", name + ".png");
            screenshot.SaveAsFile(reportDirImage);
            return MediaEntityBuilder.CreateScreenCaptureFromPath(reportDirImage, name).Build();
        }

    }
}
