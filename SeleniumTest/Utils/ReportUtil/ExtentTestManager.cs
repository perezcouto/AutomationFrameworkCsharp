using System;
using System.Runtime.CompilerServices;
using AventStack.ExtentReports;

namespace SeleniumTest.Utils.ReportUtil
{
    public class ExtentTestManager
    {
        //Create a parent test and child test which gives a hierarchy of tests in the extent report.
        [ThreadStatic]
        private static ExtentTest parentTest;
        [ThreadStatic]
        private static ExtentTest childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]

        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            parentTest = ExtentService.GetExtent().CreateTest(testName, description);
            return parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]

        public static ExtentTest CreateTest(string testName, string description = null, string[] categories=null, string[] authors = null)
        {
            childTest = parentTest.CreateNode(testName, description).AssignCategory(categories).AssignAuthor(authors);
            return childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        { 
            return childTest;
        }
    }
}
