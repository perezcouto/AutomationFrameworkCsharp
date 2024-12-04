using SeleniumTest.Utils.Base;

namespace SeleniumTest
{
    public class DemoTest : BaseTest
    {
        
        [Test, Author("Fabian Ramos"), Category("Demo"), Order(2)]
        public void Fail_Test()
        {
            Assert.Fail("I'm failing!");
        }

        [Test, Author("Fabian Ramos"), Category("Demo"), Order(1), Category("Another")]
        public void Warning_Test()
        {
            Assert.Warn("HELLO! I'm warning");
        }

        [Test, Author("Fabian Ramos"), Category("Demo"), Order(3)]
        public void Pass_Test()
        {
            Assert.Pass("Completed!");
        }
    }
}