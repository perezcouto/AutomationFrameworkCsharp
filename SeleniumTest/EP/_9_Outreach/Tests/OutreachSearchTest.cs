using SeleniumTest.EP._0_Home.Pages;
using SeleniumTest.EP._9_Outreach.Pages;
using SeleniumTest.Utils.Base;

namespace SeleniumTest.EP._9_Outreach.Tests
{
    [TestFixture]
    [Author("Fabian Ramos", "fabian.ramos@mitratech.com")]
    public class OutreachSearchTest : BaseTest
    {
        LoginPage lp = new LoginPage();
        HomePage hp = new HomePage();
        OutreachSearchPage osp = new OutreachSearchPage();

        //Search by Location=Nationwide
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10797")]
        public void OutreachSearchNationwide_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearchByLocation("NationWide");
            osp.AssertLocationResult("NationWide");
        }

        //Search by Location=State
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10797")]
        public void OutreachSearchState_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearchByLocation("State", "ID");
            osp.AssertLocationResult("State", "ID");
        }

        //Search by Location=County
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10797")]
        public void OutreachSearchCounty_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearchByLocation("County", "CA", "Orange");
            osp.AssertLocationResult("County", "CA", "Orange");
        }

        //Search by Location=City
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10797")]
        public void OutreachSearchCity_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearchByLocation("City", "TX", "Houston");
            osp.AssertLocationResult("City", "TX", "Houston");
        }

        //Search by Location=ZipCode
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10797")]
        [Ignore("BUG")]
        public void OutreachSearchZipCode_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearchByLocation("ZipCode", null, "53703");
            osp.AssertLocationResult("ZipCode", null, "53703");
        }

        //Search Organization profiles
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10659")]

        public void OutreachSearchOrganizations_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(".com", "ORGANIZATION");
            osp.OpenNewTabAndAssertURL("ORGANIZATION");
        }

        //Search Contact profiles
        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("US 10659")]

        public void OutreachSearchContacts_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachSearchSubmenu();
            osp.PerformSearch(".net", "CONTACT");
            osp.OpenNewTabAndAssertURL("CONTACT");
        }
    }
}