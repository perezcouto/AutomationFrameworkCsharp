using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.DJX.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.DJX.Pages
{
    internal class MyJobsPage : BaseElement
    {
        private MyJobsElements mj = new MyJobsElements();
        
        public void validateMyJobsPage(String jobTitle)
        {
            base.WaitElementVisible(mj.myJobsPostingHeader());
            Assert.That(base.GetText(mj.myJobsPostingHeader()).Equals("My Job Postings"));
            base.WaitElementVisible(mj.youJobHasBeenPostedMsg());
            Assert.That(base.GetText(mj.youJobHasBeenPostedMsg()).Equals("Your job has been posted. It may take up to one hour for the job to appear in search results."));
            base.WaitElementVisible(mj.jobTitleRecordParameterized(jobTitle));
            ReportLog.Info("My Jobs Posting page is displayed correctly!");
        }

        public void validateFeaturedPremiumJob(String jobTitle)
        {
            base.WaitElementClickable(mj.jobTitleRecordParameterized(jobTitle));
            base.WaitElementClickable(mj.jobPremiumIconParameterized(jobTitle));
            Assert.That(base.GetAttributeValueByName(mj.jobPremiumIconParameterized(jobTitle), "title").Equals("Premium Job"));
            ReportLog.Info("Job Result is displayed with Featured Premium Job");
        }

        public void editJobTitleName(String jobTitle)
        {
            base.WaitElementClickable(mj.jobTitleRecordParameterized(jobTitle));
            base.ClickJS(mj.jobTitleRecordParameterized(jobTitle));
            ReportLog.Info("Job Title clicked to edit!");
        }

        public void viewJobTitleName(String jobTitle)
        {
            base.WaitElementClickable(mj.jobTitleViewRecordParameterized(jobTitle));
            base.ClickJS(mj.jobTitleViewRecordParameterized(jobTitle));
            ReportLog.Info("Job Title view icon clicked to edit!");
        }

        public void validateJobResultWithRemotePill(String jobTitle)
        {
            base.WaitElementClickable(mj.jobResultHeader());
            Assert.That(base.GetText(mj.jobResultHeader()).Equals(jobTitle));
            base.WaitElementVisible(mj.remotePill());
            ReportLog.Info("Job Result is displayed with Remote pill on it");
        }
    }
}