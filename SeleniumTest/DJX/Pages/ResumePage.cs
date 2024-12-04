using AventStack.ExtentReports.Model;
using SeleniumTest.CX.Elements;
using SeleniumTest.DJX.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest.DJX.Pages
{
    internal class ResumePage : BaseElement
    {
        private ResumeElements re = new ResumeElements();
        private LoginElements lo = new LoginElements();
        private DashBoardElements dBoard = new DashBoardElements();

        public void tcC1767860_validateExperienceField(string emailAddress,string pwd , string expectedOption)
        {
            base.ClickJSScrollToView(base.FindBy(lo.buttonCookies()));
            base.SendKeys(lo.UserTextbox(), emailAddress);
            base.SendKeys(lo.PasswordTextbox(), pwd);
            base.Click(lo.LoginButton());
            base.Click(dBoard.DashboardManageAccountTab());
            base.WaitElementVisible(dBoard.DashboarManageAccountContent());
            
            base.ClickOnListElements(dBoard.JobManagerButtonsList(), 4);
            SelectElement dropdownName = base.AsSelect(re.ExperienceField());
            dropdownName.SelectByText(expectedOption);
            string optionSelected = dropdownName.SelectedOption.Text;
            Assert.That(expectedOption==optionSelected);

        }



    }
}
