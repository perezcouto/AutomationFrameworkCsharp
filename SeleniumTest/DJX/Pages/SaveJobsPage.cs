using OpenQA.Selenium;
using SeleniumTest.CX.Elements;
using SeleniumTest.DJX.Elements;
using SeleniumTest.Utils.Base;


namespace SeleniumTest.DJX.Pages
{
    internal class SaveJobsPage : BaseElement
    {
        
        private LoginElements le = new LoginElements();
        private DashBoardElements dBoard = new DashBoardElements();
        private SaveJobsElements svjobs = new SaveJobsElements();
       
        public void tcC1771266_validateSaveJobsTitle(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());

            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 3);
             
            Assert.That(svjobs.SaveJosTitle() != null);

        }

    }
}
