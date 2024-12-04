using SeleniumTest.OMSA.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.DataUtil;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.OMSA.Pages
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
    }
}
