using SeleniumTest.EP._0_Home.Pages;
using SeleniumTest.EP._9_Outreach.Pages;
using SeleniumTest.Utils.Base;

namespace SeleniumTest.EP._9_Outreach.Tests
{
    [TestFixture]
    [Author("Fabian Ramos", "fabian.ramos@mitratech.com")]
    public class OutreachResultTest : BaseTest
    {
        LoginPage lp = new LoginPage();
        HomePage hp = new HomePage();
        OutreachSearchPage osp = new OutreachSearchPage();
        OutreachResultPage orp = new OutreachResultPage();

        //Add Note activity
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10562")]
        public void OutreachAddActivityNote_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AddActivity("Note");
            orp.GoBacktoSearch(); //Go back and search again to see activity added (not automatic refreshing)
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AssertActivityExist();
            orp.DeleteActivity();
            orp.AssertActivityDoesNotExist();
        }

        //Add Call activity
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10562")]
        public void OutreachAddActivityCall_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AddActivity("Call");
            orp.GoBacktoSearch(); //Go back and search again to see activity added (not automatic refreshing)
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AssertActivityExist();
            orp.DeleteActivity();
            orp.AssertActivityDoesNotExist();
        }

        //Add E-mail activity
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10562")]
        public void OutreachAddActivityEmail_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AddActivity("E-mail");
            orp.GoBacktoSearch(); //Go back and search again to see activity added (not automatic refreshing)
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AssertActivityExist();
            orp.DeleteActivity();
            orp.AssertActivityDoesNotExist();
        }

        //Add Event activity
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10562")]
        public void OutreachAddActivityEvent_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AddActivity("Event");
            orp.GoBacktoSearch(); //Go back and search again to see activity added (not automatic refreshing)
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AssertActivityExist();
            orp.DeleteActivity();
            orp.AssertActivityDoesNotExist();
        }

        //Add Meeting activity
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10562")]
        public void OutreachAddActivityMeeting_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AddActivity("Meeting");
            orp.GoBacktoSearch(); //Go back and search again to see activity added (not automatic refreshing)
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AssertActivityExist();
            orp.DeleteActivity();
            orp.AssertActivityDoesNotExist();
        }

        //Add 'Candidate referral' activity in Organization profile
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 11000")]
        public void OutreachAddActivityReferralOrg_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(TestContext.Parameters["CX_searchOrganization"], "ORGANIZATION");
            osp.OpenFirstResult();
            orp.AddActivity("Candidate Referral");
            orp.OpenContactLink();
            orp.AssertActivityDoesNotExist(false);
            orp.GoBacktoSearch();
            orp.GoBacktoSearch();
            osp.PerformSearch(TestContext.Parameters["CX_searchOrganization"], "ORGANIZATION");
            osp.OpenFirstResult();
            orp.AssertActivityExist();
            orp.DeleteActivity();
            orp.AssertActivityDoesNotExist();
        }

        //Add 'Candidate referral' activity in Contact profile
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 11000")]
        public void OutreachAddActivityReferralCnt_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AddActivity("Candidate Referral");
            orp.AssertReferralNameInOrganization(TestContext.Parameters["CX_searchContact"]);
            orp.GoBacktoSearch();
            orp.GoBacktoSearch();
            osp.PerformSearch(TestContext.Parameters["CX_searchContact"], "CONTACT");
            osp.OpenFirstResult();
            orp.AssertActivityExist();
            orp.DeleteActivity();
            orp.AssertActivityDoesNotExist();
        }

    }
}
