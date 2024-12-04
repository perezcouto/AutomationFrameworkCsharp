using OpenQA.Selenium;
using SeleniumTest.CX.Elements;
using SeleniumTest.DJX.Elements;
using SeleniumTest.Utils.Base;


namespace SeleniumTest.DJX.Pages
{
    internal class SubAccountsPage : BaseElement
    {
        private SubAccountElements aUsers = new SubAccountElements();
        private LoginElements le = new LoginElements();
        private DashBoardElements dBoard = new DashBoardElements();
        private JobPostElements jpostElements = new JobPostElements();
        private AuthorizedUserElements authUsers = new AuthorizedUserElements();

        public void tcC1767206_validateCityAndStateColumn(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(),pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 6);
            string texto = base.GetText(aUsers.TableUsers());

            //Validating length of Name Column
            Assert.That(texto.Length > 0);
        }


        public void tcC1761664_validateDeleteButtonOnSubAccountsUsers(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 6);
            string columnName = base.GetText(aUsers.TableUsers());

            Assert.That(aUsers.DeleteIcons() != null);


        }

        public void tcC1776720_validateEmployerTextFieldOnSubAccountsUsers(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardJobManagerTab());
            base.WaitElementVisible(dBoard.DashboardJobManagementContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 1);
            base.WaitElementVisible(jpostElements.EmployerField());

            Assert.That(base.FindBy(jpostElements.EmployerField()) != null);

        }

        public void tcC1761396_validateSearchButtonsOnSubAccountsUsers(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 6);
            base.WaitElementVisible(aUsers.CompanyFilter());
            base.WaitElementVisible(aUsers.LocationFilter());
            Assert.That(base.FindBy(aUsers.CompanyFilter()) != null);
            Assert.That(base.FindBy(aUsers.LocationFilter()) != null);
        }

        public void tcC1761401_verifyHideDeleteButtonSubAccountPage(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 7);
            base.WaitElementVisible(authUsers.deleteIconUnavailable());
            Assert.That(base.FindBy(authUsers.deleteIconUnavailable()) != null);
        }

        public void tcC1760996_verifyEditButtonSubAccountPage(string emailAddress, string pwd)
        {
            base.ClickJSScrollToView(base.FindBy(le.buttonCookies()));
            base.SendKeys(le.UserTextbox(), emailAddress);
            base.SendKeys(le.PasswordTextbox(), pwd);
            base.Click(le.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 7);
            base.WaitElementVisible(authUsers.editIconavailable());
            Assert.That(base.FindBy(authUsers.editIconavailable()) != null);
        }

    }
}
