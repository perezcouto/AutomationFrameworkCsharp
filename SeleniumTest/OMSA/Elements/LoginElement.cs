using OpenQA.Selenium;

namespace SeleniumTest.OMSA.Elements
{
    public class LoginElement
    {
        public By MenuProfilesLink() { return By.XPath("//div[@role='listbox']/a[1]"); }
        public By MenuActivitiesLink() { return By.XPath("//div[@role='listbox']/a[2]"); }
        public By UserTextbox() { return By.Name("loginfmt"); }
        public By SubmitButton() { return By.XPath("//input[@type='submit']"); }
        public By PasswordTextbox() { return By.Name("passwd"); }
        public By MoreInfoLink() { return By.Id("moreInfoLink"); }
        public By SecurityInfoRegister() { return By.XPath("//main[@data-automation-id='SecurityInfoRegister']"); }
        public By SkipSettingsLink() { return By.XPath("//main/div/section[2]/div/div[2]/a"); }
        public By SaveSessionNOButton() { return By.Id("idBtn_Back"); }
        public By AccountSessionLabel() { return By.CssSelector("div.v-list-item__content:nth-child(3)"); }
        
    }
}
