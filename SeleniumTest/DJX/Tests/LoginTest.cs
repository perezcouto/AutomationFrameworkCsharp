using SeleniumTest.DJX.Pages;
using SeleniumTest.Utils.Base;



namespace SeleniumTest

{
    [TestFixture]
    [Author("Nestor Rodriguez", "nestor.rodriguez@mitratech.com")]
    public class LoginTest : BaseTest
    {
        LoginPage lp = new LoginPage();

        //Login using valid User-role credentials
        [Test, Category("RegressionDJX"), Order(19)]
         public void ValidUser_Test()
         {
             lp.loginValidCredentials(TestContext.Parameters["regularUser"], TestContext.Parameters["PwdUser"]);
         }

        [Test, Category("RegressionDJX"), Order(18)]
        public void tcC1772626_validMitratechLogo()
        {
            lp.tcC1772626_validMitratechLogo(TestContext.Parameters["difUser"], TestContext.Parameters["PwdUser"]);
        }


    }
}