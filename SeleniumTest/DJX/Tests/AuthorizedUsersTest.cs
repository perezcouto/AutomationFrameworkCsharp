using SeleniumTest.DJX.Pages;
using SeleniumTest.Utils.Base;


namespace SeleniumTest

{
    [TestFixture]
    [Author("Nestor Rodriguez", "nestor.rodriguez@mitratech.com")]
    public class AuthorizedUsersTest : BaseTest
    {
        AuthorizedUsersPage ausersp = new AuthorizedUsersPage();

        [Test, Category("RegressionDJX"), Order(1)]
        public void tcC1767205_validateFirstandLastNameColumn()
        {
            ausersp.tcC1767205_validateFirstandLastNameColumn(TestContext.Parameters["regularUser"], TestContext.Parameters["PwdUser"]);
        }

        [Test, Category("RegressionDJX"), Order(2)]
        public void tcC1766602_validateNavigateBackAuthorizedUsersByCancel()
        {
            ausersp.tc1766602_validateNavigateBackAuthorizedUsersByCancel(TestContext.Parameters["regularUser"], TestContext.Parameters["PwdUser"]);
        }

        [Test, Category("RegressionDJX"), Order(3)]
        public void tcC1766601_validateNavigateBackAuthorizedUsersByAdd()
        {
            ausersp.tcC1766601_validateNavigateBackAuthorizedUsersByAdd(TestContext.Parameters["regularUser"], TestContext.Parameters["PwdUser"]);
        }


        [Test, Category("RegressionDJX"), Order(4)]
        public void tcC1761984_verifyObligatoryFields()
        {
            ausersp.tcC1761984_verifyObligatoryFields(TestContext.Parameters["regularUser"], TestContext.Parameters["PwdUser"]);
        }
    }
}