using SeleniumTest.EP._0_Home.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.EP._0_Home.Pages
{
    internal class HomePage : BaseElement
    {
        private HomeElement he = new HomeElement();

        public void OpenOutreachMenu()
        {
            base.Click(he.OutreachMenuItem());
            ReportLog.Info("Menu 'Outreach' clicked");
        }
        public void OpenOutreachSearchSubmenu()
        {
            base.Click(he.SearchSubmenuItem());
            
            Assert.That(base.GetURL().Contains("/outreach/search"));
            ReportLog.Info("'/outreach/search' page displayed.");
            base.SwitchFrame(he.OMSFrame());
        }

        public void OpenOutreachListsSubmenu()
        {
            base.Click(he.ListsSubmenuItem());

            Assert.That(base.GetURL().Contains("/outreach/lists"));
            ReportLog.Info("'/outreach/lists' page displayed.");
            base.SwitchFrame(he.OMSFrame());
        }
    }
}
