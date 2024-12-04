using AventStack.ExtentReports.Model;
using SeleniumTest.EP._0_Home.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.EP._0_Home.Pages
{
    internal class LoginPage : BaseElement
    {
        private LoginElement le = new LoginElement();
        private HomeElement he = new HomeElement();

        public void loginValidCredentials(string emailAddress)
        {
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.Click(le.LoginButton());
            
            base.SendKeys(le.PasswordTextbox(), "password");
            base.Click(le.LoginButton());
            base.WaitElementVisible(he.ProfileButton());
            ReportLog.Info("User signed in to access the account.");
            Assert.That("Home | Diversity Catalyst" == base.GetTitle());
        }

        public void loginWrongUser(string emailAddress)
        {
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.Click(le.LoginButton());

            base.SendKeys(le.PasswordTextbox(), "password");
            base.Click(le.LoginButton());

            Assert.That("Invalid username or password" == base.GetText(le.WrongCredentialErrorLabel()));
        }

        public void loginWrongPassword(string emailAddress)
        {
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.Click(le.LoginButton());

            base.SendKeys(le.PasswordTextbox(), new GenerateRandom().RandomString(9));
            base.Click(le.LoginButton());

            Assert.That("Invalid username or password" == base.GetText(le.WrongCredentialErrorLabel()));
        }
    }
}
