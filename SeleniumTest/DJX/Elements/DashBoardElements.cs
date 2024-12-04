using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class DashBoardElements
    {
        public By JobManagerButtonsList() { return By.ClassName("dashboard-link"); }
        public By DashboardManageAccountTab() { return By.Id("tab-nav-2"); }
        public By DashboardJobManagerTab() { return By.Id("tab-nav-1"); }
        public By DashboarManageAccountContent() { return By.Id("tab-content-2"); }
        public By DashboardJobManagementContent() { return By.Id("tab-content-1"); }

        public By FindJobsButton() { return By.XPath("//div[@class='flineQbox']//input[@name='submit.quickJobSearch']"); }
    }
}