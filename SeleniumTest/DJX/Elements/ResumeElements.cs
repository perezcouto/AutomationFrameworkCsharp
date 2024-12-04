using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class ResumeElements
    {
        public By ExperienceField() { return By.XPath("//*[@id='resumefield724']"); }
        public By SelectedExperienceValue() { return By.CssSelector(".selected-value.text-size-14"); }


       


    }
}