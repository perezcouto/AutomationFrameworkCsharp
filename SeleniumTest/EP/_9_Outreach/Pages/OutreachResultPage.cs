using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTest.EP._9_Outreach.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.EP._9_Outreach.Pages
{
    internal class OutreachResultPage : BaseElement
    {
        private OutreachResultElement ore = new OutreachResultElement();

        public void GoBacktoSearch()
        {
            Thread.Sleep(5000);
            ReportLog.Info("Clicking '< Back' button");
            base.ClickJS(ore.BackButton());
        }

        public void AddActivity(string activityType)
        {
            ReportLog.Info("Adding " + activityType + " activity.");
            base.Click(ore.ActionsButton());
            base.Click(ore.AddActivityButton());
            //Open form
            base.WaitElementVisible(ore.ActivityTypeCombobox());
            base.ClickJS(ore.ActivityTypeCombobox());
            switch (activityType.ToLower())
            {
                case "note":
                    ORP_selectItemCombobox(ore.ActivityTypeCombobox(), 1);
                    FillActivity(activityType);
                    break;
                case "call":
                    ORP_selectItemCombobox(ore.ActivityTypeCombobox(), 2);
                    FillActivity(activityType);
                    break;
                case "event":
                    ORP_selectItemCombobox(ore.ActivityTypeCombobox(), 3);
                    FillActivity(activityType);
                    break;
                case "e-mail":
                    ORP_selectItemCombobox(ore.ActivityTypeCombobox(), 4);
                    FillActivity(activityType);
                    break;
                case "meeting":
                    ORP_selectItemCombobox(ore.ActivityTypeCombobox(), 5);
                    FillActivity(activityType);
                    break;
                case "message":
                    ORP_selectItemCombobox(ore.ActivityTypeCombobox(), 6);
                    FillActivity(activityType);
                    break;
                default:
                    ORP_selectItemCombobox(ore.ActivityTypeCombobox(), 7);
                    base.SendKeys(ore.ActivityReferralFirstInput(), "John");
                    base.SendKeys(ore.ActivityReferralLastInput(), "Smith");
                    break;
            }
            base.Click(ore.ActivitySaveButton());
            Thread.Sleep(1500);
        }

        private void FillActivity(string activityType)
        {
            base.SendKeys(ore.ActivitySubjectInput(), "Sub Test " + activityType);
            base.SendKeys(ore.ActivityBodyTextarea(), "Area: Test " + activityType);
        }

        public void AssertActivityExist()
        {
            IWebElement firstDeleteIcon = base.ReturnElementFromList(ore.ActivityDeleteIcon(), 0); //Get delete icon from Activity list
            Assert.That(firstDeleteIcon.Displayed);
        }

        public void AssertReferralNameInOrganization(string contactName)
        {
            base.Click(ore.BelongingOrganizationLink());
            base.WaitElementVisible(ore.FirstContactLink());
            Thread.Sleep(2500);
            string textFromFirstActivity = base.GetText(ore.ActivityText()).ToLower();
            string referredText = "referred by " + contactName.ToLower();
            Assert.That(textFromFirstActivity.Contains(referredText));
        }

        public void OpenContactLink()
        {
            base.Click(ore.FirstContactLink());
            base.WaitElementVisible(ore.BelongingOrganizationLink());
        }

        public void DeleteActivity()
        {
            IWebElement firstDeleteIcon = base.ReturnElementFromList(ore.ActivityDeleteIcon(), 0); //Get delete icon from Activity list
            base.WaitElementClickable(firstDeleteIcon);
            base.Click(firstDeleteIcon);
            ReportLog.Info("Deleting activities.");
            base.Click(ore.ActivityDeleteConfirmButton());
            Thread.Sleep(4000);
        }

        public void AssertActivityDoesNotExist(bool itIsFinalAssert = true)
        {
            base.WaitUntilInvisible(ore.ActivityDeleteIcon()); //Get delete icon from Activity list
            if(itIsFinalAssert) Assert.Pass("No activity in list");
            else Assert.That(itIsFinalAssert, Is.False);
        }

        //-----------------------Private methods to allow interactions with web elements in this page/form.
        private void ORP_selectItemCombobox(By locator, int itemIndex = 0)
        {
            base.ClickJS(locator);
            for (int i = 0; i < itemIndex + 1; i++)
            {
                new Actions(driver).SendKeys(Keys.ArrowDown).Build().Perform();
                Thread.Sleep(250);
            }
            new Actions(driver).SendKeys(Keys.Space).Build().Perform();
            Thread.Sleep(750);
        }
    }
}
