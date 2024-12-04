using OpenQA.Selenium;

namespace SeleniumTest.OMSA.Elements
{
    public class HomeElement
    {
        public By ProfileButton() { return By.CssSelector("button[aria-label='profile menu']"); }
        //---------Left menu elements
        public By HomeMenuItem() { return By.CssSelector(".v-list > a:nth-child(1)"); }
        public By AccountSettingsMenuItem() { return By.CssSelector("div.v-list-group:nth-child(2)"); }
        public By JobManagementMenuItem() { return By.CssSelector("div.v-list-group:nth-child(3)"); }
        public By OFCCPMenuItem() { return By.CssSelector("div.v-list-group:nth-child(4)"); }
        public By ResumeSearchMenuItem() { return By.CssSelector("div.v-list-group:nth-child(5)"); }
        public By ApplicantTrackingMenuItem() { return By.CssSelector("div.v-list-group:nth-child(6)"); }
        public By ABIMenuItem() { return By.CssSelector("div.v-list-group:nth-child(7)"); }
        public By LaborIQMenuItem() { return By.CssSelector(".v-list > a:nth-child(8)"); }
        public By ReportsMenuItem() { return By.CssSelector("div.v-list-group:nth-child(9)"); }
        public By ResourcesMenuItem() { return By.CssSelector("div.v-list-group:nth-child(10)"); }
        //--------Outreach elements
        public By OutreachMenuItem() { return By.CssSelector("div.v-list-group:nth-child(11)"); }
        public By SearchSubmenuItem() { return By.CssSelector("div.v-list-group:nth-child(11) > div:nth-child(2) > a:nth-child(1)"); }
        public By ListsSubmenuItem() { return By.CssSelector("div.v-list-group:nth-child(11) > div:nth-child(2) > a:nth-child(2)"); }

        public By HelpMenuItem() { return By.CssSelector(".v-list > a:nth-child(12)"); }

        //Frame
        public By OMSFrame() { return By.XPath("//*[@id='app-container']/section/iframe"); }

    }
}
