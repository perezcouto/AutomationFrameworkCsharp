using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class LoginElements
    {
        public By UserTextbox() { return By.Id("email"); }
        public By LoginButton() { return By.Name("submit.login"); }
        public By PasswordTextbox() { return By.Id("password"); }
        public By WrongCredentialErrorLabel() { return By.Id("loginForm15.errors"); }
        public By buttonCookies() { return By.XPath("//a[@id='cookies_alert_btn']"); }

        public By logoMitratech() { return By.XPath("//a[@rel='home']//img[contains(@src,'/diversityjobs/logo.png')]"); }
    }
}