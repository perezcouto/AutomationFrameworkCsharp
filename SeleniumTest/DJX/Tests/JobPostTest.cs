using SeleniumTest.DJX.Pages;
using SeleniumTest.Utils.Base;


namespace SeleniumTest

{
    [TestFixture]
    [Author("Nestor Rodriguez", "nestor.rodriguez@mitratech.com")]
    public class JobPostTest : BaseTest
    {
        LoginPage lp = new LoginPage();
        JobPostPage jp = new JobPostPage();
        MyJobsPage mjp = new MyJobsPage();

        //Precondition for checking Feature checked
        //TR case ID = Preconditions
        [Test, Category("NonRegressionDJX"), Order(5)]
         public void preconditionForFeatured()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPurchaseProducts();
             jp.addOnPurchaseOnline(TestContext.Parameters["AddOnFeaturedQty"], TestContext.Parameters["CardHolder"], TestContext.Parameters["CreditCardNumber"], TestContext.Parameters["CVV"], TestContext.Parameters["Zip"], TestContext.Parameters["Month"], TestContext.Parameters["Year"]);
             jp.validateFeateredPurchasedItemsPage();
         }

         //Validate Add 47 options and filter to 'Domain' dropdown
         //TR case ID = C1767474
         [Test, Category("RegressionDJX"), Order(6)]
         public void tcC1767474_validateDomainField()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();

             jp.tcC1767474_validateDomainField();
         }

         //Validate Turn off employer filter in job search results list
         //TR case ID = C1768885
         [Test, Category("RegressionDJX"), Order(7)]
         public void tcC1768885_validateFilters()
         {
             jp.tcC1768885_validateFilters();
         }

         //Validate Add location to 'My Jobs' list
         //TR case ID = C1774432
         [Test, Category("RegressionDJX"), Order(8)]
         public void tcC1774432_validateLocationColumn()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToJobsManager();
             jp.tcC1774432_validateLocationColumn();
         }

         //Verify access to posting jobs
         //TR case ID = C1772757
         [Test, Category("RegressionDJX"), Order(9)]
         public void tcC1772757_validateAcessJobPost()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
         }

         // Verify Post Job - Blind Ad
         //TR case ID = C1772766
         [Test, Author("Angel Avila"), Category("RegressionDJX"), Order(10)]
         public void tcC1772766_validateBlindAdCheckbox()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
             jp.validateBlindAdCheckbox();
         }

         // Verify Post Job - Blind Ad, Remote
         //TR case ID = C1772767
         [Test, Author("Angel Avila"), Category("RegressionDJX"), Order(11)]
         public void tcC1772767_validateBlindAdRemote()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
             jp.validateBlindAdCheckbox();
             List<String> categories = new List<string>();
             categories.Add(TestContext.Parameters["cat1"]);
             categories.Add(TestContext.Parameters["cat2"]);
             jp.enterJPGralInfoSectionDatawithBlindAdAndRemote(TestContext.Parameters["jobTitle"], TestContext.Parameters["employer"], TestContext.Parameters["jobType"], categories, TestContext.Parameters["compDesc"]);
             jp.enterLocationSectionData(TestContext.Parameters["state"], TestContext.Parameters["city"], TestContext.Parameters["streetAddr"], TestContext.Parameters["postalCode"]);
             jp.enterContactInformationDefaulEmailSectionData(TestContext.Parameters["contactName"], TestContext.Parameters["linkJobApplication"]);
             jp.enterDescriptionSectionData(TestContext.Parameters["jobDescription"]);
             jp.clickPublishButton();
             Thread.Sleep(10000);
             mjp.validateMyJobsPage(TestContext.Parameters["jobTitle"]);
             mjp.viewJobTitleName(TestContext.Parameters["jobTitle"]);
             mjp.validateJobResultWithRemotePill(TestContext.Parameters["jobTitle"]);
         }

         // Verify Post Job - ATS
         //TR case ID = C1772768
         [Test, Author("Angel Avila"), Category("RegressionDJX"), Order(12)]
         public void tcC1772768_validateATSRadiobutton()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
             jp.validateBlindAdCheckbox();
         }

         // Verify Post Job - Featured
         //TR case ID = C1772769
         [Test, Author("Angel Avila"), Category("RegressionDJX"), Order(13)]
         public void tcC1772769_validateFeatured()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
             List<String> categories = new List<string>();
             categories.Add(TestContext.Parameters["cat1"]);
             categories.Add(TestContext.Parameters["cat2"]);
             jp.enterJPGralInfoSectionData(TestContext.Parameters["jobTitle"], TestContext.Parameters["employer"], TestContext.Parameters["jobType"], categories);
             jp.enterLocationSectionData(TestContext.Parameters["state"], TestContext.Parameters["city"], TestContext.Parameters["streetAddr"], TestContext.Parameters["postalCode"]);
             jp.enterContactInformationDefaulEmailSectionData(TestContext.Parameters["contactName"], TestContext.Parameters["linkJobApplication"]);
             jp.enterDescriptionSectionData(TestContext.Parameters["jobDescription"]);
             jp.checkFeatureJobCheckbox();
             jp.clickPublishButton();
             Thread.Sleep(10000);
             mjp.validateMyJobsPage(TestContext.Parameters["jobTitle"]);
             mjp.validateFeaturedPremiumJob(TestContext.Parameters["jobTitle"]);
         }

         // Verify Post Job - Remote, Featured 
         //TR case ID = C1772770
         [Test, Author("Angel Avila"), Category("RegressionDJX"), Order(14)]
         public void tcC1772770_validateRemoteFeatured()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
             List<String> categories = new List<string>();
             categories.Add(TestContext.Parameters["cat1"]);
             categories.Add(TestContext.Parameters["cat2"]);
             jp.enterJPGralInfoSectionDatawithRemote(TestContext.Parameters["jobTitle"], TestContext.Parameters["employer"], TestContext.Parameters["jobType"], categories);
             jp.enterLocationSectionData(TestContext.Parameters["state"], TestContext.Parameters["city"], TestContext.Parameters["streetAddr"], TestContext.Parameters["postalCode"]);
             jp.enterContactInformationDefaulEmailSectionData(TestContext.Parameters["contactName"], TestContext.Parameters["linkJobApplication"]);
             jp.enterDescriptionSectionData(TestContext.Parameters["jobDescription"]);
             jp.checkFeatureJobCheckbox();
             jp.clickPublishButton();
             Thread.Sleep(10000);
             mjp.validateMyJobsPage(TestContext.Parameters["jobTitle"]);
             mjp.validateFeaturedPremiumJob(TestContext.Parameters["jobTitle"]);
             mjp.viewJobTitleName(TestContext.Parameters["jobTitle"]);
             mjp.validateJobResultWithRemotePill(TestContext.Parameters["jobTitle"]);
         }

         // Verify Post Job - Blind Ad, Featured
         //TR case ID = C1772771
         [Test, Author("Angel Avila"), Category("RegressionDJX"), Order(15)]
         public void tcC1772771_validateBlindAdFeatured()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
             jp.validateBlindAdCheckbox();
             List<String> categories = new List<string>();
             categories.Add(TestContext.Parameters["cat1"]);
             categories.Add(TestContext.Parameters["cat2"]);
             jp.enterJPGralInfoSectionDataBlindAdOnly(TestContext.Parameters["jobTitle"], TestContext.Parameters["employer"], TestContext.Parameters["jobType"], categories, TestContext.Parameters["compDesc"]);
             jp.enterLocationSectionData(TestContext.Parameters["state"], TestContext.Parameters["city"], TestContext.Parameters["streetAddr"], TestContext.Parameters["postalCode"]);
             jp.enterContactInformationDefaulEmailSectionData(TestContext.Parameters["contactName"], TestContext.Parameters["linkJobApplication"]);
             jp.enterDescriptionSectionData(TestContext.Parameters["jobDescription"]);
             jp.checkFeatureJobCheckbox();
             jp.clickPublishButton();
             Thread.Sleep(10000);
             mjp.validateMyJobsPage(TestContext.Parameters["jobTitle"]);
             mjp.validateFeaturedPremiumJob(TestContext.Parameters["jobTitle"]);
         }

         // Verify Post Job - Blin Ad, Remote, Featured
         //TR case ID = C1772772
         [Test, Author("Angel Avila"), Category("RegressionDJX"), Order(16)]
         public void tcC1772772_validateBlindAdRemoteFeatured()
         {
             lp.loginDiversityCatalyst(TestContext.Parameters["ownerUser"], TestContext.Parameters["PwdUser"]);
             jp.navigateToPostAJob();
             jp.validateBlindAdCheckbox();
             List<String> categories = new List<string>();
             categories.Add(TestContext.Parameters["cat1"]);
             categories.Add(TestContext.Parameters["cat2"]);
             jp.enterJPGralInfoSectionDatawithBlindAdAndRemote(TestContext.Parameters["jobTitle"], TestContext.Parameters["employer"], TestContext.Parameters["jobType"], categories, TestContext.Parameters["compDesc"]);
             jp.enterLocationSectionData(TestContext.Parameters["state"], TestContext.Parameters["city"], TestContext.Parameters["streetAddr"], TestContext.Parameters["postalCode"]);
             jp.enterContactInformationDefaulEmailSectionData(TestContext.Parameters["contactName"], TestContext.Parameters["linkJobApplication"]);
             jp.enterDescriptionSectionData(TestContext.Parameters["jobDescription"]);
             jp.checkFeatureJobCheckbox();
             jp.clickPublishButton();
             Thread.Sleep(10000);
             mjp.validateMyJobsPage(TestContext.Parameters["jobTitle"]);
             mjp.validateFeaturedPremiumJob(TestContext.Parameters["jobTitle"]);
             mjp.viewJobTitleName(TestContext.Parameters["jobTitle"]);
             mjp.validateJobResultWithRemotePill(TestContext.Parameters["jobTitle"]);
         }
           [Test, Category("RegressionDJX"), Order(17)]
           public void tcC1775421_validatePostDate()
           {
               jp.tcC1775421_validatePostDate(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
           }


           [Test, Category("RegressionDJX"), Order(18)]
           public void tcC1768762_validateClearButton()
           {
               jp.tcC1768762_validateClearButton(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
           }
       

        [Test, Category("RegressionDJX"), Order(18)]
        public void tcC1776162_validateMyJobPostingUpdate()
        {
            jp.tcC1776162_validateMyJobPostingUpdate(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
        } 


        [Test, Category("RegressionDJX"), Order(18)]
        public void tcC1759970_validateFeaturedTag()
        {
            jp.tcC1759970_validateFeaturedTag(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
        }

        [Test, Category("RegressionDJX"), Order(18)]
        public void tcC1772757_validatePostJob()
        {
            jp.tcC1772757_validatePostJob(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
        }

        [Test, Category("RegressionDJX"), Order(18)]
        public void tcC1771212_validateJobsAppliedForTitle()
        {
            jp.tcC1771212_validateJobsAppliedForTitle(TestContext.Parameters["specialUser"], TestContext.Parameters["PwdSpecialUser"]);
        }

        [Test, Category("RegressionDJX"), Order(19)]
        public void tcC1771267_validateJobsAlertsTitle()
        {
            jp.tcC1771212_validateJobsAlertsTitle(TestContext.Parameters["specialUser"], TestContext.Parameters["PwdSpecialUser"]);
        }

        [Test, Category("RegressionDJX"), Order(20)]
        public void tcC1771211_validateCopyRightUptoDate()
        {
            jp.tcC1771211_validateCopyRightUptoDate(TestContext.Parameters["specialUser"], TestContext.Parameters["PwdSpecialUser"]);
        }

        [Test, Category("RegressionDJX"), Order(21)]
        public void tcC1772509_validateLogoOnFooter()
        {
            jp.tcC1772509_validateLogoOnFooter(TestContext.Parameters["specialUser"], TestContext.Parameters["PwdSpecialUser"]);
        }

    }
}