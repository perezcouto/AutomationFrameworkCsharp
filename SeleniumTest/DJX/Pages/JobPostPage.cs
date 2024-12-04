using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.DJX.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;
using System.Globalization;
using System.Xml.Linq;

namespace SeleniumTest.DJX.Pages
{
    internal class JobPostPage : BaseElement
    {
        private JobPostElements jpostElements = new JobPostElements();
        private LoginElements le = new LoginElements();
        private DashBoardElements dBoard = new DashBoardElements();
        private PurchaseOnlineElements poe = new PurchaseOnlineElements();
        private MyJobsElements myJobsElements = new MyJobsElements();

        public void tcC1767474_validateDomainField()
        {
            base.AsSelect(jpostElements.DomainField());
            base.Click(base.ReturnElementFromList(jpostElements.ListOfDropDowns(), 0));
            base.Click(base.FindBy(jpostElements.DomainOption()));
            string title = base.ReturnElementFromList(jpostElements.ListOfDropDowns(), 0).Text;
            //Validating length of Name Column
            Assert.That(title.Length > 0);
        }

        public void tcC1768885_validateFilters()
        {
            string title = "";
            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.Click(jpostElements.FindJobsButton());
            for (int i = 0; i < 5; i++) {
                title = base.ReturnElementFromList(jpostElements.FiltersTitle(), i).Text;
               
                Assert.That(!title.Equals("Employeer"));
            } 
        }

        public void tcC1774432_validateLocationColumn()
        {
            string columnaName = base.FindBy(jpostElements.LocationColumn()).Text;
            Console.WriteLine("columnNameLocation:" + columnaName);
            //Validating length of Name Column
            Assert.That(columnaName.Equals("Location"));
        }

        public void navigateToPurchaseProducts()
        {
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 0);
            base.WaitElementClickable(poe.purchaseOnlineHeader());
            Assert.That(base.GetText(poe.purchaseOnlineHeader()).Equals("Purchase online"));
            ReportLog.Info("Navigated to Purchase online correctly!");
        }

        public void navigateToPostAJob()
        {
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 1);
            base.WaitElementClickable(jpostElements.jobPostingHeader());
            Assert.That(base.GetText(jpostElements.jobPostingHeader()).Equals("Job Posting"));
            ReportLog.Info("Navigated to Job Posting correctly!");
        }

        public void navigateToJobsManager()
        {
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 2);
        }

        public void addOnPurchaseOnline(String qty, String cardHolder, String cardnum, String cvv, String zip, String month, String year)
        {
            base.WaitElementVisible(poe.quantityFieldAddOnFeatJob7days());
            base.SendKeys(poe.quantityFieldAddOnFeatJob7days(), qty);
            base.SwitchFrame(poe.paymentFrame());
            base.WaitElementClickable(poe.accountHolderInput());
            base.SendKeys(poe.accountHolderInput(), cardHolder);
            base.SendKeys(poe.cardNumberInput(), cardnum);
            base.SendKeys(poe.cvvInput(), cvv);
            base.SendKeys(poe.zipInput(), zip);
            base.AsSelect(poe.monthDropdown()).SelectByText(month);
            base.AsSelect(poe.yearDropdown()).SelectByText(year);
            base.SwitchParentFrame();
            base.WaitElementClickable(poe.proceedButton());
            base.ClickJS(poe.proceedButton());
            Thread.Sleep(10000);
        }

        public void validateFeateredPurchasedItemsPage()
        {
            base.WaitElementVisible(poe.paidItemsTable());
            int numRows = base.CountElementsFromList(poe.tableServicesTitleRowsList());
            ReportLog.Info("The number of items visibles in Services active table is: "+ numRows);
            Assert.That(base.ReturnElementFromList(poe.tableServicesTitleRowsList(), numRows - 1).Text.Contains("Featured job credit"));
            base.WaitElementClickable(poe.paymentsTable());
            int numRowsPaymt = base.CountElementsFromList(poe.tablePayHistoryDescRowsList());
            ReportLog.Info("The number of items visibles in Payment History table is: " + numRowsPaymt);
            Assert.That(base.ReturnElementFromList(poe.tablePayHistoryDescRowsList(), 0).Text.Contains("Add-On: Featured Job (7 Days)"));

        }

        public void validateBlindAdCheckbox()
        {
            base.WaitElementClickable(jpostElements.blindAdCheckbox());
            base.ClickJS(jpostElements.blindAdCheckbox());
            base.WaitElementVisible(jpostElements.companyDescriptionInput());
            base.ClickJS(jpostElements.blindAdCheckbox());
            base.WaitUntilInvisible(jpostElements.companyDescriptionInput());
            ReportLog.Info("Blind Ad checkbox is working correctly!");
        }

        public void validateATSRadiobutton()
        {
            base.WaitElementClickable(jpostElements.sendCandidateATS());
            String sendCandAttr = base.GetAttributeValueByName(jpostElements.sendCandidateATS(), "checked");
            if (sendCandAttr.Equals("checked"))
            {
                base.Click(jpostElements.sendApplicationToAlternativeEmailRadio());
            }
            
            base.WaitElementClickable(jpostElements.linkJobApplicationInput());

            ReportLog.Info("ATS Radiobutton is working correctly!");
        }

        public void enterJPGralInfoSectionData(String jobTitle, String employer, String jobType, List<String> categories)
        {
            base.SendKeys(jpostElements.jobTitleInput(), jobTitle);
            base.AsSelect(jpostElements.employerDropdown()).SelectByValue(employer);
            base.WaitElementClickable(jpostElements.jobTypeDropdown());
            base.AsSelect(jpostElements.jobTypeDropdown()).SelectByText(jobType);
            foreach (String category in categories)
            {
                base.ClickJS(jpostElements.categoriesInput());
                Thread.Sleep(3);
                IWebElement categoriesField = FindBy(jpostElements.categoriesInput());
                base.clearWebField(categoriesField);
                base.SendKeys(jpostElements.categoriesInput(), category);
                Thread.Sleep(1000);
                base.SendKeysJS(Keys.Enter);
                Thread.Sleep(10000);
                base.WaitElementClickable(jpostElements.categoriesEnteredByValue(category));
                ReportLog.Info("Category: " + category + " added");

            }
            ReportLog.Info("General Information section data entered correctly!");
        }

        public void enterJPGralInfoSectionDataBlindAdOnly(String jobTitle, String employer, String jobType, List<String> categories, String compDesc)
        {
            base.SendKeys(jpostElements.jobTitleInput(), jobTitle);
            base.AsSelect(jpostElements.employerDropdown()).SelectByValue(employer);
            base.WaitElementClickable(jpostElements.jobTypeDropdown());
            base.AsSelect(jpostElements.jobTypeDropdown()).SelectByText(jobType);
            base.ClickJS(jpostElements.blindAdCheckbox());
            base.WaitElementVisible(jpostElements.companyDescriptionInput());
            base.SendKeys(jpostElements.companyDescriptionInput(), compDesc);
            foreach (String category in categories)
            {
                base.ClickJS(jpostElements.categoriesInput());
                Thread.Sleep(3);
                IWebElement categoriesField = FindBy(jpostElements.categoriesInput());
                base.clearWebField(categoriesField);
                base.SendKeys(jpostElements.categoriesInput(), category);
                Thread.Sleep(1000);
                base.SendKeysJS(Keys.Enter);
                Thread.Sleep(10000);
                base.WaitElementClickable(jpostElements.categoriesEnteredByValue(category));
                ReportLog.Info("Category: " + category + " added");

            }
            ReportLog.Info("General Information section data entered correctly!");
        }

        public void enterJPGralInfoSectionDatawithBlindAdAndRemote(String jobTitle, String employer, String jobType, List<String> categories, String compDesc)
        {
            base.SendKeys(jpostElements.jobTitleInput(), jobTitle);
            base.AsSelect(jpostElements.employerDropdown()).SelectByValue(employer);
            base.WaitElementClickable(jpostElements.jobTypeDropdown());
            base.AsSelect(jpostElements.jobTypeDropdown()).SelectByText(jobType);
            base.ClickJS(jpostElements.blindAdCheckbox());
            base.WaitElementVisible(jpostElements.companyDescriptionInput());
            base.SendKeys(jpostElements.companyDescriptionInput(), compDesc);
            base.WaitElementClickable(jpostElements.remoteCheckbox());
            base.ClickJS(jpostElements.remoteCheckbox());
            foreach (String category in categories)
            {
                base.ClickJS(jpostElements.categoriesInput());
                Thread.Sleep(3); 
                IWebElement categoriesField = FindBy(jpostElements.categoriesInput());
                base.clearWebField(categoriesField);
                base.SendKeys(jpostElements.categoriesInput(), category);
                Thread.Sleep(1000);
                base.SendKeysJS(Keys.Enter);
                Thread.Sleep(10000);
                base.WaitElementClickable(jpostElements.categoriesEnteredByValue(category));
                ReportLog.Info("Category: "+category+" added");

            }
            ReportLog.Info("General Information section data entered correctly!");
        }

        public void enterJPGralInfoSectionDatawithRemote(String jobTitle, String employer, String jobType, List<String> categories)
        {
            base.SendKeys(jpostElements.jobTitleInput(), jobTitle);
            base.WaitElementVisible(jpostElements.employerDropdown());
            base.ClickJS(jpostElements.employerDropdown());
            base.AsSelect(jpostElements.employerDropdown()).SelectByValue(employer);
            base.WaitElementClickable(jpostElements.jobTypeDropdown());
            base.AsSelect(jpostElements.jobTypeDropdown()).SelectByText(jobType);
            base.WaitElementClickable(jpostElements.remoteCheckbox());
            base.ClickJS(jpostElements.remoteCheckbox());
            foreach (String category in categories)
            {
                base.ClickJS(jpostElements.categoriesInput());
                Thread.Sleep(3);
                IWebElement categoriesField = FindBy(jpostElements.categoriesInput());
                base.clearWebField(categoriesField);
                base.SendKeys(jpostElements.categoriesInput(), category);
                Thread.Sleep(1000);
                base.SendKeysJS(Keys.Enter);
                Thread.Sleep(10000);
                base.WaitElementClickable(jpostElements.categoriesEnteredByValue(category));
                ReportLog.Info("Category: " + category + " added");

            }
            ReportLog.Info("General Information section data entered correctly!");
        }

        public void enterLocationSectionData(String state, String city, String stAddr, String postCode)
        {
            base.AsSelect(jpostElements.stateDropdown()).SelectByText(state);
            base.SendKeys(jpostElements.cityInput(), city);
            base.SendKeys(jpostElements.streetAddressInput(), stAddr);
            base.SendKeys(jpostElements.postCodeInput(), postCode);
            ReportLog.Info("Location section data entered correctly!");
        }

        public void enterContactInformationDefaulEmailSectionData(String contactName, String linkJobApplication)
        {
            base.SendKeys(jpostElements.contactNameInput(), contactName);
            base.Click(jpostElements.applyDefaulAccEmailRadio());
            ReportLog.Info("Contact Information section data entered correctly!");
        }

        public void enterDescriptionSectionData(String jobDesc)
        {
            base.WaitElementClickable(jpostElements.jobDescriptionTextAreaiFrame());
            base.ClickJS(jpostElements.jobDescriptionTextAreaiFrame());
            base.SwitchFrame(jpostElements.jobDescriptionTextAreaiFrame());
            base.ClickJS(jpostElements.jobDescriptionTextAreaBody());
            base.SendKeys(jpostElements.jobDescriptionTextAreaBody(), jobDesc);
            ReportLog.Info("Description section data entered correctly!");
            base.SwitchParentFrame();
        }

        public void checkFeatureJobCheckbox()
        {
            base.WaitElementClickable(jpostElements.featureJobCheckbox());
            base.ClickJS(jpostElements.featureJobCheckbox());
            ReportLog.Info("Feature Job checkbox is checked!");
        }

        public void clickPublishButton()
        {
            base.WaitElementClickable(jpostElements.jobDescriptionTextAreaiFrame());
            base.Click(jpostElements.publishButton());
            ReportLog.Info("Publish button clicked!");
        }
	public void tcC1775421_validatePostDate(string emailAddress, string pwd)
	{
    DateTime dt;
    base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
    base.SendKeys(le.UserTextbox(), emailAddress);
    base.SendKeys(le.PasswordTextbox(), pwd);
    base.Click(le.LoginButton());
    base.Click(dBoard.DashboardJobManagerTab());
    base.WaitElementVisible(dBoard.DashboardJobManagementContent());
    base.ClickOnListElements(dBoard.JobManagerButtonsList(), 2);
    string expiredDate = base.FindBy(jpostElements.ExpiredDate()).Text;
    Console.WriteLine("expiredDate:" + expiredDate);
    //Validating Format Date
    Assert.That(DateTime.TryParseExact(expiredDate, "dd/MM/yyyy", null, DateTimeStyles.None, out dt));


	}

public void tcC1768762_validateClearButton(string emailAddress, string pwd)
	{
    
    base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
    base.SendKeys(le.UserTextbox(), emailAddress);
    base.SendKeys(le.PasswordTextbox(), pwd);
    base.Click(le.LoginButton());
    base.Click(dBoard.DashboardJobManagerTab());
    base.WaitElementVisible(dBoard.DashboardJobManagementContent());
    base.ClickOnListElements(dBoard.JobManagerButtonsList(), 2);
    Assert.That(base.FindBy(jpostElements.clearButton()) != null);    
    }


        public void tcC1776162_validateMyJobPostingUpdate(string emailAddress, string pwd)
        {
            
            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 2);
            base.Click(myJobsElements.firstEyeLink());
    
            Assert.That(base.FindBy(myJobsElements.backToLink()) != null);
        }

        public void tcC1759970_validateFeaturedTag(string emailAddress, string pwd)
        {
           
            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.Click(dBoard.FindJobsButton());

           
             Assert.That(base.FindBy(myJobsElements.featureTag()) != null);
        }

        public void tcC1772757_validatePostJob(string emailAddress, string pwd)
        {

            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 1);

            Assert.That(base.FindBy(jpostElements.purchseOnLineText()) != null);
        }
        public void tcC1771212_validateJobsAppliedForTitle(string emailAddress, string pwd)
        {

            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 1);

            Assert.That(base.FindBy(jpostElements.jobsAppliedForTitle()) != null);
        }

        public void tcC1771212_validateJobsAlertsTitle(string emailAddress, string pwd)
        {

            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 3);

            Assert.That(base.FindBy(jpostElements.jobsAlertsForTitle()) != null);
        }

        public void tcC1771211_validateCopyRightUptoDate(string emailAddress, string pwd)
        {
           
            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 3);

            Console.WriteLine("now year:" + DateTime.Now.Year.ToString());
            Assert.That(base.FindBy(jpostElements.jobsCopyRightSection()).Text.Contains(DateTime.Now.Year.ToString()));
        }


        public void tcC1772509_validateLogoOnFooter(string emailAddress, string pwd)
        {

            base.ClickJSScrollToView(base.FindBy(jpostElements.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 3);


            Assert.That(base.FindBy(jpostElements.logoOnFooter()) != null);
        }


    }
}
