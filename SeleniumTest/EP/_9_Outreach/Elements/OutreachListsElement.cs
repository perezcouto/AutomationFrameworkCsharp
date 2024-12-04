using OpenQA.Selenium;

namespace SeleniumTest.EP._9_Outreach.Elements
{
    public class OutreachListsElement
    {
        public By listTitle() { return By.XPath("//h1"); }
        public By listCheckbox() { return By.XPath("//input[starts-with(@id, 'input-')]"); }
        public By listEditIcon() { return By.CssSelector("i.mdi-pencil.mdi.v-icon.notranslate.v-theme--light.v-icon--size-default"); }
        //-------Results
        public By ResultIcon() { return By.Id("typeSquare"); }
    }
}
