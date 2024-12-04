using OpenQA.Selenium;

namespace SeleniumTest.EP._9_Outreach.Elements
{
    public class OutreachResultElement
    {
        public By BackButton() { return By.CssSelector(".v-btn--variant-plain > span:nth-child(2)"); }
        public By ActionsButton() { return By.XPath("//button[starts-with(@class, 'v-btn v-theme')][@data-test-id='actions-menu']"); }
        public By AddActivityButton() { return By.XPath("//button[starts-with(@class, 'v-btn v-theme')][@data-test-id='add-to-activity-button']"); }
        public By ActivityDeleteIcon() { return By.CssSelector("i.mdi-trash-can-outline.mdi.v-icon.notranslate.v-theme--light.v-icon--size-default"); }
        public By ActivityDeleteConfirmButton() { return By.XPath("//div[2]/div[2]/div[2]/div/div[4]/button[2]"); }
        public By BelongingOrganizationLink() { return By.CssSelector(".mx-6 > div:nth-child(2) > p:nth-child(1) > a:nth-child(1)"); }
        public By ActivityText() { return By.CssSelector(".v-card-text > div:nth-child(1)"); }
        public By FirstContactLink() { return By.CssSelector("div.py-5:nth-child(3) > div:nth-child(1) > div:nth-child(2) > a:nth-child(1)"); }

        //----------------------Activity form
        public By ActivityTypeCombobox() { return By.XPath("//input[@aria-label='Open'][@title='Open']"); }
        public By ActivitySubjectInput() { return By.XPath("//input[@class='v-field__input'][@type='text']"); }
        public By ActivityBodyTextarea() { return By.XPath("//textarea[@class='v-field__input'][@rows='5']"); }
        public By ActivityReferralFirstInput() { return By.CssSelector("fieldset.mb-3:nth-child(4) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > input"); }
        public By ActivityReferralLastInput() { return By.CssSelector("fieldset.mb-3:nth-child(4) > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > input"); }
        public By ActivityCancelButton() { return By.CssSelector("button.v-btn--slim:nth-child(1) > span:nth-child(3)"); }
        public By ActivitySaveButton() { return By.CssSelector("button.v-btn:nth-child(2) > span:nth-child(3)"); }
        
    }
}
