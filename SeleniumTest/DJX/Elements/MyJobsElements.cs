using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class MyJobsElements
    {
        public By myJobsPostingHeader() { return By.CssSelector("h2.sub-head"); }
        public By youJobHasBeenPostedMsg() { return By.CssSelector("div[class='navigation-tabs__content purchase-announcement'] li"); }
        public By jobTitleRecordParameterized(String jobTitle) { return By.XPath("//table[@id='jobmanager-table']//a[contains(.,'" + jobTitle + "')]"); }
        public By jobPremiumIconParameterized(String jobTitle) { return By.XPath("//table[@id='jobmanager-table']//a[contains(.,'" + jobTitle + "')]//following-sibling::span"); }
        public By jobTitleViewRecordParameterized(String jobTitle) { return By.XPath("//a[contains(.,'" + jobTitle + "')]//ancestor::tr//td[@class='actions']//button[@title='View']"); }
        public By jobResultHeader() { return By.XPath("//h1[@class='job-title']"); }
        public By remotePill() { return By.XPath("//span[@class='remote-pill']"); }
        public By newJobPill() { return By.XPath("//span[@class='new-job-pill']"); }
        public By firstEyeLink() { return By.XPath("//*[@id='jobmanager-table']/tbody/tr[1]/td[9]/button[1]/img"); }
        public By backToLink() { return By.XPath("//div[@class='col-left']/a[contains(text(),'Back to')]"); }
        public By featureTag() { return By.XPath("//div[@class='premiumBlock']/h3[contains(text(),'Featured Jobs')]"); }
    }
}