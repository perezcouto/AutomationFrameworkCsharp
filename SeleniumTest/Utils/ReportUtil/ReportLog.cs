using AventStack.ExtentReports.Model;

namespace SeleniumTest.Utils.ReportUtil
{
    public class ReportLog
    {
        public static void Pass(string message)
        {
            ExtentTestManager.GetTest().Pass(message);
        }

        public static void Fail(string message, Media media=null)
        {
            ExtentTestManager.GetTest().Fail(message, media);
        }

        public static void Skip(string message)
        {
            ExtentTestManager.GetTest().Skip(message);
        }

        public static void Warning(string message)
        {
            ExtentTestManager.GetTest().Warning(message);
        }

        public static void Info(string message)
        {
            ExtentTestManager.GetTest().Info(message);
        }
    }
}
