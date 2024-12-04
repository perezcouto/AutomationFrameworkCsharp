using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class PurchaseOnlineElements
    {
        public By purchaseOnlineHeader() { return By.CssSelector("h3.sub-head"); }
        public By couponCodeInput() { return By.XPath("//input[@id='coupon-code']"); }
        public By applyCouponButton() { return By.XPath("//input[@value='Apply coupon']"); }
        public By quantityFieldSingleJob30days() { return By.XPath("//td[@class='package-name']//div[contains(.,'Single Job Posting (30 Days')]//ancestor::tr//child::input"); }
        public By quantityFieldJobPostingPackg3jobs30days() { return By.XPath("//td[@class='package-name']//div[contains(.,'Job Posting Package (3 Jobs - 30 Days)')]//ancestor::tr//child::input"); }
        public By quantityFieldJobPostingPackg5jobs30days() { return By.XPath("//td[@class='package-name']//div[contains(.,'Job Posting Package (5 Jobs - 30 Days)')]//ancestor::tr//child::input"); }
        public By quantityFieldJobPostingPackg10jobs30days() { return By.XPath("//td[@class='package-name']//div[contains(.,'Job Posting Package (10 Jobs - 30 Days)')]//ancestor::tr//child::input"); }
        public By quantityFieldAddOnFeatJob7days() { return By.XPath("//td[@class='package-name']//div[contains(.,'Add-On: Featured Job (7 Days)')]//ancestor::tr//child::input"); }
        public By paymentFrame() { return By.XPath("//iframe[@id='SECCpaymentFrame']"); }
        public By accountHolderInput() { return By.XPath("//input[@id='SECCAccountHolder']"); }
        public By cardNumberInput() { return By.Id("SECCCardNumber"); }
        public By cvvInput() { return By.Id("SECCCvv"); }
        public By zipInput() { return By.Id("SECCZip"); }
        public By monthDropdown() { return By.Id("SECCExpMonth"); }
        public By yearDropdown() { return By.Id("SECCExpYear"); }
        public By cancelButton() { return By.XPath("(//input[@value='Cancel'])[1]"); }
        public By proceedButton() { return By.XPath("//input[@value='Proceed']"); }
        //Purchased items elements
        public By paidItemsTable() { return By.CssSelector("table#paid-items-table"); }
        public By tableServicesTitleRowsList() { return By.XPath("//table[@id='paid-items-table']//tbody//tr//td[2]"); }
        public By paymentsTable() { return By.CssSelector("table#payments-table"); }
        public By tablePayHistoryDescRowsList() { return By.XPath("//table[@id='payments-table']//tbody//tr//td[2]"); }
    }
}