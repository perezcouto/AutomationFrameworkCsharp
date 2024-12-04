using SeleniumTest.DJX.Pages;
using SeleniumTest.Utils.Base;

namespace SeleniumTest

{
    [TestFixture]
    [Author("Nestor Rodriguez", "nestor.rodriguez@mitratech.com")]
    public class SaveJobsTest : BaseTest
    {
        SaveJobsPage sjb = new SaveJobsPage();

        
        [Test, Category("RegressionDJX"), Order(20)]
        public void tcC1771266_validateSaveJobsTitle()
        {
            sjb.tcC1771266_validateSaveJobsTitle(TestContext.Parameters["specialUser"], TestContext.Parameters["PwdSpecialUser"]);
        }


    }
}