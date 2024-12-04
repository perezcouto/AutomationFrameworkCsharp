using SeleniumTest.DJX.Pages;
using SeleniumTest.Utils.Base;


namespace SeleniumTest

{
    [TestFixture]
    [Author("Nestor Rodriguez", "nestor.rodriguez@mitratech.com")]
    public class SubAccountsTest : BaseTest
    {
        SubAccountsPage ausersp = new SubAccountsPage();

  
  [Test, Category("RegressionDJX"), Order(21)]
  public void tcC1767206_validateCityAndStateColumn()
  {
      ausersp.tcC1767206_validateCityAndStateColumn(TestContext.Parameters["subAccountUser"], TestContext.Parameters["PwdUser"]);
  }

  [Test, Category("RegressionDJX"), Order(22)]
  public void tcC1761664_validateDeleteButtonOnSubAccountsUsers()
  {
      ausersp.tcC1761664_validateDeleteButtonOnSubAccountsUsers(TestContext.Parameters["subAccountUser"], TestContext.Parameters["PwdUser"]);
  }

  [Test, Category("RegressionDJX"), Order(23)]
  public void tcC1776720_validateEmployerTextFieldOnSubAccountsUsers()
  {
           ausersp.tcC1776720_validateEmployerTextFieldOnSubAccountsUsers(TestContext.Parameters["subAccountUser"], TestContext.Parameters["PwdUser"]);
            //ausersp.tcC1776720_validateEmployerTextFieldOnSubAccountsUsers("qa_test310@circaworks.com", "Iceman!123");
        
  }

        [Test, Category("RegressionDJX"), Order(24)]
  public void tcC1761396_validateSearchButtonsOnSubAccountsUsers()
  {
      ausersp.tcC1761396_validateSearchButtonsOnSubAccountsUsers(TestContext.Parameters["subAccountUser"], TestContext.Parameters["PwdUser"]);
  }

  [Test, Category("RegressionDJX"), Order(25)]
  public void tcC1761401_verifyHideDeleteButtonSubAccountPage()
  {
      ausersp.tcC1761401_verifyHideDeleteButtonSubAccountPage(TestContext.Parameters["subAccountUser"], TestContext.Parameters["PwdUser"]);
  }

  [Test, Category("RegressionDJX"), Order(26)]
  public void tcC1760996_verifyEditButtonSubAccountPage()
  {
      ausersp.tcC1760996_verifyEditButtonSubAccountPage("qa_test310@circaworks.com", "Iceman!123");
  }

        

    }
}