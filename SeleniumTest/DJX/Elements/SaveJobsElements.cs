using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class SaveJobsElements
    {
        public By SaveJosTitle() { return By.XPath("//h2[contains(text(),'Saved Jobs')]"); }
       
    }
}