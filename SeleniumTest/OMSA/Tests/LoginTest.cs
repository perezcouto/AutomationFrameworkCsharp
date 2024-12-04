using SeleniumTest.OMSA.Pages;
using SeleniumTest.Utils.Base;

namespace SeleniumTest.OMSA.Tests
{
    [TestFixture]
    [Author("Fabian Ramos", "fabian.ramos@mitratech.com")]
    public class LoginTests : BaseTest
    {
        LoginPage lp = new LoginPage();

        //Login using valid User-role credentials
        [Test, Author("Fabian Ramos"), Category("Positive"), Order(1)]
        public void ValidUser_Test()
        {
            lp.loginValidCredentials(TestContext.Parameters["username"], TestContext.Parameters["password"]);
        }
    }
}