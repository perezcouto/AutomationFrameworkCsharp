using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.Utils
{
    public class DriverUtil
    {
        //Initialize the correct browser driver and return the driver instance.
        private IWebDriver driver;
        
        public IWebDriver GetDriver(string browser) {
            try
            {
                driver = SetDriver(browser);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return driver; 
        }

        public IWebDriver SetDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    
                    ChromeOptions optionsC = new ChromeOptions();
                    optionsC.AddArguments("--no-proxy-server");
                    optionsC.AddArguments("--disable-web-security");
                    driver = new ChromeDriver();
                    ReportLog.Info("Initialized Chrome browser");
                    break;
                case "firefox":
                    FirefoxOptions optionsF = new FirefoxOptions();
                    optionsF.AddArguments("--no-proxy-server");
                    optionsF.AddArguments("--disable-web-security");
                    driver = new FirefoxDriver();
                    ReportLog.Info("Initialized Firefox browser");
                    break;
                case "edge":
                    EdgeOptions optionsE = new EdgeOptions();
                    optionsE.AddArguments("--no-proxy-server");
                    optionsE.AddArguments("--disable-web-security");
                    driver = new EdgeDriver();
                    
                    ReportLog.Info("Initialized Edge browser");
                    break;
                default: 
                    Assert.Fail("Browser not recognized");
                    break;
            }
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
