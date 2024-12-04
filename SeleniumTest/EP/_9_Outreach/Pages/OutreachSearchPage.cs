using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTest.EP._9_Outreach.Elements;
using SeleniumTest.Utils.Base;
using SeleniumTest.Utils.ReportUtil;

namespace SeleniumTest.EP._9_Outreach.Pages
{
    internal class OutreachSearchPage : BaseElement
    {
        private OutreachSearchElement ose = new OutreachSearchElement();

        public void PerformSearch(string searchText, string profileType=null)
        {
           
            while(profileType != null)
            {
                base.Click(ose.FiltersButton());
                base.Click(ose.ProfileTypeMenu());
                base.WaitElementVisible(ose.OrganizationCheckbox());
                if (profileType.ToLower() == "contact") base.Click(ose.ContactCheckbox());
                else base.Click(ose.OrganizationCheckbox());
                base.Click(ose.ApplyButton());
                
                break;
            }
            Thread.Sleep(5000);
            base.TabAndSendKeys(ose.SearchLabel(), searchText);
            base.Click(ose.SearchButton());
            Thread.Sleep(5000);
            base.WaitElementClickable(base.ReturnElementFromList(ose.ResultsLink(), 0));
            
            ReportLog.Info("Search Results displayed");

        }

        public void PerformSearchByLocation(string locationType, string stateValue = null, string locationValue = null)
        {
            ReportLog.Info("Apply Location filter by: " + locationType);
            base.Click(ose.FiltersButton());
            base.Click(ose.LocationServedMenu());
            base.WaitElementVisible(ose.LocationTypeCombobox());
            
            switch(locationType.ToLower())
            {
                case "state":
                    OSP_selectItemCombobox(ose.LocationTypeCombobox(), 2);
                    if (stateValue != null)
                    {
                        new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
                        OSP_selectStateLocationFilter(stateValue);
                    }
                    else Assert.Fail("Missing value for state");
                    break;
                case "county":
                    OSP_selectItemCombobox(ose.LocationTypeCombobox(), 3);
                    if (locationValue != null)
                    {
                        new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
                        base.SendKeysJS(locationValue);
                        if (stateValue != null)
                        {
                            new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
                            OSP_selectStateLocationFilter(stateValue);
                        }
                        else Assert.Fail("Missing value for state");
                    }
                    else Assert.Fail("Missing value for county");
                    break;
                case "city":
                    OSP_selectItemCombobox(ose.LocationTypeCombobox(), 4);
                    if (locationValue != null)
                    {
                        new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
                        base.SendKeysJS(locationValue);
                        if (stateValue != null)
                        {
                            new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
                            OSP_selectStateLocationFilter(stateValue);
                        }
                        else Assert.Fail("Missing value for state");
                    }
                    else Assert.Fail("Missing value for city");
                    break;
                case "zipcode":
                    OSP_selectItemCombobox(ose.LocationTypeCombobox(), 5);
                    if (locationValue != null)
                    {
                        new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
                        base.SendKeysJS(locationValue);
                    }
                    else Assert.Fail("Missing value for Zip codes");
                    break;
                default: OSP_selectItemCombobox(ose.LocationTypeCombobox(), 1);
                    break;
            }
            base.Click(ose.LocationTypeAddButton());
            base.Click(ose.ApplyButton());
            Thread.Sleep(1500);
        }

        public void AssertLocationResult(string locationType, string stateValue = null, string locationValue = null)
        {
            ReportLog.Info("Assert results are corresponding to Search by: " + locationType);
            base.WaitElementClickable(base.ReturnElementFromList(ose.ResultsLink(), 0));
            string locationText = ""; //Variable to store text base on location (could be 'address' or 'location' colum of firts result)

            switch (locationType.ToLower())
            {
                case "state":
                    if (stateValue != null)
                    {
                        locationText = base.GetText(ose.firstResultLocation()).ToUpper();
                        Assert.That(locationText.Contains(stateValue.ToUpper()));
                    }
                    else Assert.Fail("Missing value for state");
                    break;
                case "county":
                    if (locationValue != null)
                    {
                        if (stateValue != null)
                        {
                            locationText = base.GetText(ose.firstResultLocation()).ToUpper();
                            bool textIsThere = false;
                            if (locationText.Contains(stateValue.ToUpper()) || locationText.Contains(locationValue.ToUpper())) textIsThere = true;
                            Assert.That(textIsThere);
                        }
                        else Assert.Fail("Missing value for state");
                    }
                    else Assert.Fail("Missing value for county");
                    break;
                case "city":
                    if (locationValue != null)
                    {
                        new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
                        base.SendKeysJS(locationValue);
                        if (stateValue != null)
                        {
                            locationText = base.GetText(ose.firstResultLocation()).ToUpper();
                            bool textIsThere = false;
                            if (locationText.Contains(stateValue.ToUpper()) || locationText.Contains(locationValue.ToUpper())) textIsThere = true;
                            Assert.That(textIsThere);
                        }
                        else Assert.Fail("Missing value for state");
                    }
                    else Assert.Fail("Missing value for city");
                    break;
                case "zipcode":
                    if (locationValue != null)
                    {
                        locationText = base.GetText(ose.firstResultAddress()).ToUpper();
                        Assert.That(locationText.Contains(stateValue.ToUpper()));
                    }
                    else Assert.Fail("Missing value for Zip codes");
                    break;
                default:
                    locationText = base.GetText(ose.firstResultLocation()).ToUpper();
                    Assert.That(locationText.Contains("NATIONWIDE"));
                    break;
            }
            
        }

        public void OpenFirstResult()
        {
            ReportLog.Info("Clicking on first result's name");
            base.WaitElementClickable(base.ReturnElementFromList(ose.ResultsLink()));
            IWebElement firstResult = base.ReturnElementFromList(ose.ResultsLink(), 0);
            base.ClickJS(firstResult);
            Thread.Sleep(7500);
        }

        public void OpenNewTabAndAssertURL(string profileType)
        {
            base.Click(ose.ResultIcon());
            base.WaitElementClickable(base.ReturnElementFromList(ose.ResultsLink()));

            IWebElement firstlink = base.ReturnElementFromList(ose.ResultsLink());
            base.OpenLinkNewTabJS(firstlink);
            base.SwitchToNextTab();
            Thread.Sleep(2500);

            if (profileType.ToLower() == "contact") Assert.That(base.GetURL().Contains("/outreach/contact-profiles/"), "Current URL: "+ base.GetURL());
            else Assert.That(base.GetURL().Contains("/outreach/community-partners/"), "Current URL: " + base.GetURL());
        }

        //-----------------------Private methods to allow interactions with web elements in this page/form.
        private void OSP_selectItemCombobox(By locator, int itemIndex = 0)
        {
            base.ClickJS(locator);
            for (int i = 0; i < itemIndex+1; i++)
            {
                new Actions(driver).SendKeys(Keys.ArrowDown).Build().Perform();
                Thread.Sleep(250);
            }
            new Actions(driver).SendKeys(Keys.Space).Build().Perform();
            Thread.Sleep(750);
        }

        private void OSP_selectStateLocationFilter(string stateCode)
        {
            int stateIndex = 0;
            string caps = stateCode.ToUpper();

            if (stateCode.Length != 2)
            {
                Assert.Fail("State code must be only 2 letters. Error:" + stateCode);
            }
            else
            {
                if (caps == "AL") stateIndex = 0;
                else if (caps == "AK") stateIndex = 1;
                else if (caps == "AZ") stateIndex = 2;
                else if (caps == "AR") stateIndex = 3;
                else if (caps == "CA") stateIndex = 4;
                else if (caps == "CO") stateIndex = 5;
                else if (caps == "CT") stateIndex = 6;
                else if (caps == "DE") stateIndex = 7;
                else if (caps == "DC") stateIndex = 8;
                else if (caps == "FL") stateIndex = 9;
                else if (caps == "GA") stateIndex = 10;
                else if (caps == "HI") stateIndex = 11;
                else if (caps == "ID") stateIndex = 12;
                else if (caps == "IL") stateIndex = 13;
                else if (caps == "IN") stateIndex = 14;
                else if (caps == "IA") stateIndex = 15;
                else if (caps == "KS") stateIndex = 16;
                else if (caps == "KY") stateIndex = 17;
                else if (caps == "LA") stateIndex = 18;
                else if (caps == "ME") stateIndex = 19;
                else if (caps == "MD") stateIndex = 20;
                else if (caps == "MA") stateIndex = 21;
                else if (caps == "MI") stateIndex = 22;
                else if (caps == "MN") stateIndex = 23;
                else if (caps == "MS") stateIndex = 24;
                else if (caps == "MO") stateIndex = 25;
                else if (caps == "MT") stateIndex = 26;
                else if (caps == "NE") stateIndex = 27;
                else if (caps == "NV") stateIndex = 28;
                else if (caps == "NH") stateIndex = 29;
                else if (caps == "NJ") stateIndex = 30;
                else if (caps == "NM") stateIndex = 31;
                else if (caps == "NY") stateIndex = 32;
                else if (caps == "NC") stateIndex = 33;
                else if (caps == "ND") stateIndex = 34;
                else if (caps == "OH") stateIndex = 35;
                else if (caps == "OK") stateIndex = 36;
                else if (caps == "OR") stateIndex = 37;
                else if (caps == "PA") stateIndex = 38;
                else if (caps == "RI") stateIndex = 39;
                else if (caps == "SC") stateIndex = 40;
                else if (caps == "SD") stateIndex = 41;
                else if (caps == "TN") stateIndex = 42;
                else if (caps == "TX") stateIndex = 43;
                else if (caps == "UT") stateIndex = 44;
                else if (caps == "VT") stateIndex = 45;
                else if (caps == "VA") stateIndex = 46;
                else if (caps == "WA") stateIndex = 47;
                else if (caps == "WV") stateIndex = 48;
                else if (caps == "WI") stateIndex = 49;
                else stateIndex = 50;
            }
            for (int i = 0; i < stateIndex+1; i++)
            {
                new Actions(driver).SendKeys(Keys.ArrowDown).Build().Perform();
                Thread.Sleep(125);
            }
            new Actions(driver).SendKeys(Keys.Space).Build().Perform();
        }
    }
}

