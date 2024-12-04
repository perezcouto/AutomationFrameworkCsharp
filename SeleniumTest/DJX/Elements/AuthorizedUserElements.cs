using OpenQA.Selenium;

namespace SeleniumTest.CX.Elements
{
    public class AuthorizedUserElements
    {
        public By FirstName() { return By.Id("field254"); }
        public By LastName() { return By.Id("field255"); }
        public By Email() { return By.Id("field120"); }
        public By ConFirmEmail() { return By.Id("field13.confirm"); }
        public By SubAccountma() { return By.Id("field120"); }
        public By AddButton() { return By.Id("btnsubaccountProfile"); }
        public By NewButton() { return By.XPath("//input[@value='Add Authorized User']"); }
        public By TableUsers() { return By.XPath("//*[@id='subaccounts-list-table']/tbody/tr[1]/td[1]");}
        public By CancelButton() { return By.XPath("//input[@value='Cancel']"); }
        public By AuthorizedPageTitle() { return By.XPath("//h2[@class='sub-head']"); }
        public By buttonCookies() { return By.XPath("//a[@id='cookies_alert_btn']"); }
	    public By deleteIconUnavailable() { return By.XPath("//*[@class='icon--delete icon-gray-out']"); }
	    public By editIconavailable() { return By.XPath("//button[@class='icon--edit']"); }
    }
}