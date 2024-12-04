using SeleniumTest.Utils.Base;
using SeleniumTest.DomCon.Page;

namespace SeleniumTest.DomCon.Test
{
    public class DomainTest : BaseTest
    {
        DomainPage dp = new DomainPage();

        [Test, Author("Fabian Ramos"), Category("Domain Consolidation"), Order(1)]
        public void Domain_Test()
        {
            dp.OpenAllSites("2023 LJN Traffic (SEO).xlsx", "Domains to PERM Direct");
        }
    }
}