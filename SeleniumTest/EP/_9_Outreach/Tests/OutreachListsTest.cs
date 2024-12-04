using SeleniumTest.EP._0_Home.Pages;
using SeleniumTest.EP._9_Outreach.Pages;
using SeleniumTest.Utils.Base;

namespace SeleniumTest.EP._9_Outreach.Tests
{
    public class OutreachListsTest : BaseTest
    {
        LoginPage lp = new LoginPage();
        HomePage hp = new HomePage();
        OutreachListsPage olp = new OutreachListsPage();

        //Assert list and its content is displayed
        //TR case ID = 1773474

        [Test, Author("Fabian Ramos"), Category("Outreach"), Category("Regression"), Category("Lists")]
        public void OutreachListsDisplayed_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
            hp.OpenOutreachMenu();
            hp.OpenOutreachListsSubmenu();
            olp.AssertListsExist();
            hp.OpenOutreachListsSubmenu();
            olp.AssertListCanBeDeleted();
        }
    }
}
