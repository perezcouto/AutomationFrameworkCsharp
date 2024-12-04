using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using SeleniumTest.CX.Elements;
using SeleniumTest.DJX.Elements;
using SeleniumTest.Utils.Base;

namespace SeleniumTest.DJX.Pages
{
    internal class AuthorizedUsersPage : BaseElement
    {
        private AuthorizedUserElements aUsers = new AuthorizedUserElements();
        private LoginElements le = new LoginElements();
        private DashBoardElements dBoard = new DashBoardElements();

        public void tcC1767205_validateFirstandLastNameColumn(string emailAddress,string Pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), Pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(),7);
            string texto= base.GetText(aUsers.TableUsers());

            //Validating length of Name Column
            Assert.That(texto.Length>0);
        }


        public void tc1766602_validateNavigateBackAuthorizedUsersByCancel(string emailAddress,string Pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), Pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 7);
            base.Click(aUsers.NewButton());
            base.SendKeys(aUsers.FirstName(), "Nestor");
            base.SendKeys(aUsers.LastName(), "Perez");
            base.SendKeys(aUsers.FirstName(), "Rtrr");
            base.SendKeys(aUsers.Email(), "luisinovasiss@gmail.com");
            base.SendKeys(aUsers.ConFirmEmail(), "luisinovasiss@gmail.com");
            base.ClickJS(base.FindBy(aUsers.CancelButton()));
            string title = base.GetText(aUsers.AuthorizedPageTitle());

            Assert.That(title.Length > 0);

          
        }


        public void tcC1766601_validateNavigateBackAuthorizedUsersByAdd(string emailAddress, string Pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), Pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 7);
            base.Click(aUsers.NewButton());
            base.SendKeys(aUsers.FirstName(), "Nestor");
            base.SendKeys(aUsers.LastName(), "Perez");
            base.SendKeys(aUsers.FirstName(), "Rtrr");
            base.SendKeys(aUsers.Email(), "luisinovasiss@gmail.com");
            base.SendKeys(aUsers.ConFirmEmail(), "luisinovasiss@gmail.com");
            base.ClickJS(base.FindBy(aUsers.AddButton()));

            string title = base.GetText(aUsers.AuthorizedPageTitle());

            Assert.That(title.Length > 0);


        }
 
        public void tcC1761984_verifyObligatoryFields(string emailAddress, string Pwd)
 	    {
        base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
        base.SendKeys(le.UserTextbox(), emailAddress);
        base.SendKeys(le.PasswordTextbox(), Pwd);
        base.Click(le.LoginButton());
        base.Click(dBoard.DashboardManageAccountTab());
        base.WaitElementVisible(dBoard.DashboarManageAccountContent());
        base.ClickOnListElements(dBoard.JobManagerButtonsList(), 7);
        base.Click(aUsers.NewButton());
        base.SendKeys(aUsers.FirstName(), "Nestor");
        base.SendKeys(aUsers.LastName(), "Perez");
        base.SendKeys(aUsers.FirstName(), "Rtrr");
        base.SendKeys(aUsers.Email(), "luisinovasiss@gmail.com");
        base.SendKeys(aUsers.ConFirmEmail(), "luisinovasiss@gmail.com");
        base.ClickJS(base.FindBy(aUsers.AddButton()));

         string title = base.GetText(aUsers.AuthorizedPageTitle());

        Assert.That(title.Length > 0);

 	}

    }
}
