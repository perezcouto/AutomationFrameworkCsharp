using NPOI.SS.UserModel;
using SeleniumTest.Utils;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.ReportUtil;


namespace SeleniumTest.DomCon.Page
{
    internal class DomainPage : BasePage
    {
        public void OpenAllSites(string fileName, string sheetName)
        {
            string projectDir = Path.Combine(Utility.GetProjectRootDirectory(), "DomCon");
            string dataFolderDir = Path.Combine(projectDir, "XLSX");
            string sheetDir = Path.Combine(dataFolderDir, fileName);

            IWorkbook wb = base.ReadWorkbook(sheetDir);
            int rowCount = wb.GetSheet(sheetName).LastRowNum;
            for (int i = 0; i < rowCount; i++)
            {
                string originalURL = wb.GetSheet(sheetName).GetRow(i+1).GetCell(0).ToString();
                string redirectURL = wb.GetSheet(sheetName).GetRow(i+1).GetCell(1).ToString();

                if (!originalURL.Contains("www.")) originalURL = "www." + originalURL;
                if (!originalURL.Contains(".com")) originalURL = originalURL + ".com";

                if (redirectURL.Contains("www.")) redirectURL = redirectURL.Replace("www.", "");

                base.GoToUrl("http://"+originalURL);
                Thread.Sleep(500);

                if(base.GetURL() != redirectURL) ReportLog.Warning("URL in browser("+ originalURL + ") is not equal to expected value:" + redirectURL);
                else ReportLog.Pass("URL matches with:" + redirectURL);
            }
            Assert.Pass("Opening all URLs failed");

        }
    }
}
