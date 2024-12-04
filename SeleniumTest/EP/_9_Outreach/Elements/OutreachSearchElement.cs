using OpenQA.Selenium;

namespace SeleniumTest.EP._9_Outreach.Elements
{
    public class OutreachSearchElement
    {
        public By SearchLabel() { return By.CssSelector("h1.mb-2"); }
        public By SearchTextbox() { return By.XPath("//input[starts-with(@id, 'input-')][@type='text']"); }
        public By SearchButton() { return By.CssSelector("button.v-btn--flat"); }
        public By ResetButton() { return By.CssSelector("a.v-btn"); }
        public By FiltersButton() { return By.CssSelector(".mb-8 > div:nth-child(1) > button:nth-child(1)"); }
        //------------------Filters - Profile type
        public By ProfileTypeMenu() { return By.CssSelector("div.v-expansion-panel:nth-child(1)"); }
        public By OrganizationCheckbox() { return By.CssSelector("div.v-list-item:nth-child(1) > div:nth-child(3)"); }
        public By ContactCheckbox() { return By.CssSelector("div.v-list-item:nth-child(2) > div:nth-child(3)"); }
        //------------------Filters - Location Served
        public By LocationServedMenu() { return By.CssSelector("div.v-expansion-panel:nth-child(7)"); }
        public By LocationTypeCombobox() { return By.XPath("//input[starts-with(@id, 'input-')][@inputmode='none']"); }
        public By LocationTypeAddButton() { return By.CssSelector("button.v-btn--elevated:nth-child(1)"); }
        public By LocationStateCombobox() { return By.CssSelector(".v-autocomplete > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > div:nth-child(2) > input"); }
        public By LocationInput() { return By.CssSelector("div.v-row:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > input"); }

        //------------------Filters - BUTTONS
        public By ApplyButton() { return By.CssSelector("button.v-btn:nth-child(2)"); }
        
        //------------------Displaying search results
        public By SelectAllChechbox() { return By.XPath("//label[starts-with(@for, 'checkbox-')]"); }
        public By ResultIcon() { return By.Id("typeSquare"); }
        public By ResultsLink() { return By.CssSelector("a.router-link"); }
        public By firstResultAddress() { return By.XPath("//div[1]/div/main/section/div[2]/div[2]/table/tr/td[2]/div/div[2]/div[3]/div/div[1]/div[2]"); }
        public By firstResultLocation() { return By.XPath("//div[1]/div/main/section/div[2]/div[2]/table/tr/td[2]/div/div[2]/div[4]/div"); }

    }
}
