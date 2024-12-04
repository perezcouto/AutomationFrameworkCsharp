using SeleniumTest.EP._0_Home.Pages;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.Base;

namespace SeleniumTest.EP._0_Home.Tests
{
    [TestFixture]
    [Author("Fabian Ramos", "fabian.ramos@mitratech.com")]
    public class LoginTests : BaseTest
    {
        LoginPage lp = new LoginPage();

        //Negative: Login using random text for username
        [Test, Author("Fabian Ramos"), Category("Negative"), Order(5)]
        public void InvalidUser_NTest()
        {
            lp.loginWrongUser(new GenerateRandom().RandomEmail());
        }

        //Negative: Login using random text for password
        [Test, Author("Fabian Ramos"), Category("Negative"), Order(4)]
        public void InvalidPassword_NTest()
        {
            lp.loginWrongPassword(TestContext.Parameters["adminUser"]);
        }

        //Login using valid Owner-role credentials
        [Test, Author("Fabian Ramos"), Category("Positive"), Order(3)]
        
        public void ValidOwner_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["ownerUser"]);
        }

        //Login using valid Admin-role credentials
        [Test, Author("Fabian Ramos"), Category("Positive"), Order(2)]
        
        public void ValidAdmin_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["adminUser"]);
        }

        //Login using valid User-role credentials
        [Test, Author("Fabian Ramos"), Category("Positive"), Order(1)]
        public void ValidUser_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["regularUser"]);
        }
    }
}