using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTest.EP._9_Outreach.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.EP._9_Outreach.Pages
{
    public class OutreachListsPage : BaseElement
    {
        private OutreachListsElement ole = new OutreachListsElement();

        public void AssertListsExist()
        {
            base.WaitElementVisible(ole.listTitle());
            ReportLog.Info("Lists Results displayed");
            base.Click(base.ReturnElementFromList(ole.listEditIcon(), 0));
            ReportLog.Info("Clicking first list");
            base.WaitElementVisible(ole.ResultIcon());
            Assert.That(base.CountElementsFromList(ole.ResultIcon()) > 0);
        }
        public void AssertListCanBeDeleted()
        {
            base.WaitElementVisible(ole.listTitle());
            ReportLog.Info("Lists Results displayed");
            base.Click(base.ReturnElementFromList(ole.listEditIcon(), 0));
            ReportLog.Info("Clicking first list");
            base.WaitElementVisible(ole.ResultIcon());
            Assert.That(base.CountElementsFromList(ole.ResultIcon()) > 0);
        }
    }
}
