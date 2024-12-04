using OpenQA.Selenium;

namespace SeleniumTest.OMSA.Elements.Profiles
{
    public class ProfilesTableElement
    {
        public By Control() { return By.CssSelector("button[aria-label='profile menu']"); }
    }
}