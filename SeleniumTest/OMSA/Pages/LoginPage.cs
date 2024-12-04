using AventStack.ExtentReports.Model;
using SeleniumTest.OMSA.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.OMSA.Pages
{
    internal class LoginPage : BaseElement
    {
        private LoginElement le = new LoginElement();
        private HomeElement he = new HomeElement();

        public void loginValidCredentials(string emailAddress, string password)
        {
            base.Click(le.MenuProfilesLink());
            
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.Click(le.SubmitButton());
            
            base.SendKeys(le.PasswordTextbox(), password);
            base.Click(le.SubmitButton());
            //------------START Authentication controls
            base.WaitElementVisible(le.MoreInfoLink());
            base.Click(le.SubmitButton());

            base.WaitElementVisible(le.SecurityInfoRegister());
            base.Click(le.SkipSettingsLink());

            base.Click(le.SaveSessionNOButton());
            //-------------END
            base.WaitElementVisible(le.MenuProfilesLink());
            ReportLog.Info("User signed in to access the account.");
            string labelText = base.GetText(le.AccountSessionLabel()).ToLower();
            string nameLowerCase = TestContext.Parameters["name"].ToLower();
            Assert.That(labelText.Contains(nameLowerCase), labelText + " is NOT " + nameLowerCase);
        }
    }
}
