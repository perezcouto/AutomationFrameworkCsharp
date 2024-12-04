using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Config;
using SeleniumTest.Utils;

namespace SeleniumTest.Utils.ReportUtil
{
    public class ExtentService
    {
        public static ExtentReports extent;

        public static ExtentReports GetExtent()
        {
            //Create an instance of ExtentReports if the instance is not present, else it returns the instance.
            if (extent == null)
            {
                extent = new ExtentReports();
                string reportDir = Path.Combine(Utility.GetProjectRootDirectory(), "Report");

                if (!Directory.Exists(reportDir)) { Directory.CreateDirectory(reportDir); }

                string path = Path.Combine(reportDir, "exec.html");
                var reporter = new ExtentSparkReporter(path);
                reporter.Config.DocumentTitle = "Selenium Report";
                reporter.Config.ReportName = "Test Automation Results";
                reporter.Config.Theme = Theme.Standard;
                extent.AttachReporter(reporter);
            }
            return extent;
        }
    }
}
