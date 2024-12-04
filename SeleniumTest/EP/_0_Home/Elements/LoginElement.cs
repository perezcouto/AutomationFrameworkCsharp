using OpenQA.Selenium;

namespace SeleniumTest.EP._0_Home.Elements
{
    public class LoginElement
    {
        public By UserTextbox() { return By.Id("Username"); }
        public By LoginButton() { return By.CssSelector(".btn"); }
        public By PasswordTextbox() { return By.Id("Password"); }
        public By WrongCredentialErrorLabel() { return By.CssSelector("div.danger.validation-summary-errors"); }
    }
}
