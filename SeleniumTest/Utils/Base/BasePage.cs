using OpenQA.Selenium;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.ReportUtil;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace SeleniumTest.Utils.Base
{
    public class BasePage : BaseTest
    {
        public void NavigateBack()
        {
            driver.Navigate().Back();
        }

        public void NavigateForward()
        {
            driver.Navigate().Forward();
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public void GoToUrl(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        public void SwitchFrame(string frameName)
        {
            driver.SwitchTo().Frame(frameName);
            ReportLog.Info("Switch to Frame: " + frameName);
        }

        public void SwitchFrame(By locator)
        {
            driver.SwitchTo().Frame(driver.FindElement(locator));
            ReportLog.Info("Switch to Frame: " + locator.ToString());
        }

        public void SwitchFrame(int frameIndex)
        {
            driver.SwitchTo().Frame(frameIndex);
            ReportLog.Info("Switch to Frame: " + frameIndex.ToString());
        }

        public void SwitchParentFrame()
        {
            driver.SwitchTo().ParentFrame();
            ReportLog.Info("Switch to Parent Frame");
        }

        public void SwitchToNextTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public string GetURL()
        {
            return driver.Url;
        }

        public IWorkbook ReadWorkbook(string path)
        {
            IWorkbook book;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // Try to read workbook as XLSX:
            try
            {
                book = new XSSFWorkbook(fs);
            }
            catch // If reading fails, try to read workbook as XLS:
            {
                book = new HSSFWorkbook(fs);
            }
            return book;
        }

    }
}
