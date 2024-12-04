using AventStack.ExtentReports.Model;
using SeleniumTest.CX.Elements;
using SeleniumTest.DJX.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.DJX.Pages
{
    internal class LoginPage : BaseElement
    {
        private LoginElements le = new LoginElements();

        public void loginValidCredentials(string emailAddress,string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            //base.Click(le.LoginButton());

            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());

            ReportLog.Info("User signed in to the account.");
            Assert.That("Sign In" == base.GetTitle());
        }

        public void loginWrongUser(string emailAddress)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.Click(le.LoginButton());

            base.SendKeys(le.PasswordTextbox(), "password");
            base.Click(le.LoginButton());

            Assert.That("Incorrect email or password. Please verify them and try again" == base.GetText(le.WrongCredentialErrorLabel()));
        }

        public void loginWrongPassword(string emailAddress)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.Click(le.LoginButton());

            base.SendKeys(le.PasswordTextbox(), new GenerateRandom().RandomString(9));
            base.Click(le.LoginButton());

            Assert.That("Incorrect email or password. Please verify them and try again" == base.GetText(le.WrongCredentialErrorLabel()));
        }

        public void loginDiversityCatalyst(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());

            ReportLog.Info("User signed in to the account.");
            Assert.That("Sign In" == base.GetTitle());
        }

        public void tcC1772626_validMitratechLogo(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
          
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());

           
            Assert.That(le.logoMitratech()!= null);
        }

    }
}
