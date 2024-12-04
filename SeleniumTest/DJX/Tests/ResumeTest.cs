using SeleniumTest.DJX.Pages;
using SeleniumTest.Utils.Base;

namespace SeleniumTest

{
    [TestFixture]
    [Author("Nestor Rodriguez", "nestor.rodriguez@mitratech.com")]
    public class ResumeTest : BaseTest
    {
        ResumePage rp = new ResumePage();

        
        [Test, Category("RegressionDJX"), Order(20)]
        public void tcC1767860_validateExperienceField()
        {
            rp.tcC1767860_validateExperienceField(TestContext.Parameters["specialUser"], TestContext.Parameters["PwdSpecialUser"], "20+ years");
        }
       

      

    }
}