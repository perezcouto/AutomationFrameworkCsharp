using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTest.Utils.Base
{
    public class BaseElement : BasePage
    {
        public IWebElement FindBy(By locator)
        {
            //Set wait until element is visible (element is present on the HTML DOM)
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));

            //Scroll page to control location
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(locator));

            return driver.FindElement(locator);
        }

        public IWebElement ReturnElementFromList(By locator, int index = 0)
        {
            WaitElementVisible(locator);
            IReadOnlyCollection<IWebElement> allElements = driver.FindElements(locator);
            return allElements.ElementAt(index);
        }

        public int CountElementsFromList(By locator)
        {
            WaitElementVisible(locator);
            IReadOnlyCollection<IWebElement> allElements = driver.FindElements(locator);
            return allElements.Count;
        }

        public void WaitUntilInvisible(By locator)
        {
            //Set wait until element is not visible (element is present on the HTML DOM)
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitElementVisible(By locator)
        {
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitElementClickable(IWebElement element)
        {
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));

            Actions action = new Actions(driver);
            action.MoveToElement(element);
        }

        public void WaitElementClickable(By locator)
        {
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true)", driver.FindElement(locator));
        }

        public void SendKeys(By locator, string value)
        {
            FindBy(locator).SendKeys(value);
        }

        public void SendKeysJS(string value)
        {
            new Actions(driver).SendKeys(value).Build().Perform();
        }

        //Use this method when Inputbox is not FOUND. This one clicks on previous web element, tab to next one and send text.
        public void TabAndSendKeys(By locator, string value)
        {
            Click(locator);
            new Actions(driver).SendKeys(Keys.Tab).SendKeys(value).Perform();
        }
        public void TabAndSendKeys(string value)
        {
            new Actions(driver).SendKeys(Keys.Tab).SendKeys(value).Perform();
        }

        public void ContextMenuOnElement(IWebElement link)
        {
            Actions actBuilder = new Actions(driver);
            actBuilder.ContextClick(link).Build().Perform();
        }

        public void MoveMouseByOffsetAndClick(int x, int y)
        {
            Actions actBuilder = new Actions(driver);
            actBuilder.MoveByOffset(x, y).Click().Build().Perform();
        }

        public void OpenLinkNewTab(IWebElement link)
        {
            Actions actBuilder = new Actions(driver);
            actBuilder.MoveToElement(link).KeyDown(Keys.Control).Click().KeyUp(Keys.Control).Build().Perform();
        }

        public void OpenLinkNewTab(By locator)
        {
            Actions actBuilder = new Actions(driver);
            actBuilder.MoveToElement(driver.FindElement(locator)).KeyDown(Keys.Control).Click().KeyUp(Keys.Control).Build().Perform();
        }

        public void Click(By locator)
        {
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            FindBy(locator).Click();
        }

        public void Click(IWebElement element)
        {
            WaitElementClickable(element);
            element.Click();
        }

        public void ClickJS(By locator)
        {
            WaitElementVisible(locator);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(locator));
        }

        public void ClickJS(IWebElement element)
        {
            WaitElementClickable(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public void OpenLinkNewTabJS(By locator)
        {
            string getHREF = driver.FindElement(locator).GetAttribute("href");
            Actions actBuilder = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.open('"+ getHREF + "','_blank');");
        }

        public void OpenLinkNewTabJS(IWebElement element)
        {
            string getHREF = element.GetAttribute("href");
            Actions actBuilder = new Actions(driver);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.open('" + getHREF + "','_blank');");
        }

        public string GetText(By locator)
        {
            return FindBy(locator).Text;
        }

        public string GetAttributeValueByName(By locator, String attrName)
        {
            IWebElement element = FindBy(locator);
            String getAttr = element.GetAttribute(attrName);
            return getAttr;
        }

        public SelectElement AsSelect(By locator)
        {
            SelectElement selectElement = new SelectElement(FindBy(locator));
            return selectElement;
        }

        //Nestor
        public void ClickOnListElements(By locator, int index)
        {

            ClickJSScrollToView(ReturnElementFromListWithOutWait(locator, index));
        }

        //Nestor
        public void ClickJSScrollToView(IWebElement element)
        {
            WaitElementClickable(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView();", element);
            Click(element);
        }

        //Nestor
        public IWebElement ReturnElementFromListWithOutWait(By locator, int index = 0)
        {
            IReadOnlyCollection<IWebElement> allElements = driver.FindElements(locator);
            return allElements.ElementAt(index);
        }

        public Boolean existsElement(String xPath)
        {
            try
            {
                driver.FindElement(By.XPath(xPath));
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return true;
        }

        public virtual void clearWebField(IWebElement element)
        {
            while (!element.GetAttribute("value").Equals(""))
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Backspace);
            }
        }

        public bool IsElementAvailable(By locator)
        {
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            return true;
        }

        public bool IsElementAvailable(IWebElement element)
        {
            double seconds = double.Parse(TestContext.Parameters["secondsTimeOut"]);
            TimeSpan ExplicitWaitTime = TimeSpan.FromSeconds(seconds);
            WebDriverWait Wait = new WebDriverWait(driver, ExplicitWaitTime);
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return true;
        }
    }
}
