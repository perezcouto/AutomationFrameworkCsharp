using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class SubAccountElements
    {
        public By TableUsers() { return By.XPath("//*[@id='subaccounts-list-table']/tbody/tr[1]/td[1]");}
     	public By DeleteIcons() { return By.XPath("//*[@class='icon--delete icon-gray-out']"); }
	    public By CompanyFilter() { return By.Id("text-search-keyword"); }
	    public By LocationFilter() { return By.Id("text-search-location"); }
    }
}