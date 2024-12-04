using OpenQA.Selenium;

namespace SeleniumTest.DJX.Elements
{
    public class JobPostElements
    {
        public By UserTextbox() { return By.Id("email"); }
        public By LoginButton() { return By.Name("submit.login"); }
        public By PasswordTextbox() { return By.Id("password"); }
        public By DomainField() { return By.Id("vacancyfield719");}
        public By buttonCookies() { return By.XPath("//a[@id='cookies_alert_btn']"); }
        public By ListOfDropDowns() { return By.XPath("//button[@class='multiselect dropdown-toggle btn btn-default']"); }
        public By DomainOption() { return By.XPath("//label[@title='bloomingtonjobs.com']"); }
        public By FiltersTitle() { return By.XPath("//div[@class='refine-group']"); }
        public By FindJobsButton() { return By.XPath("//input[@title='Search']"); }
        public By LocationColumn() { return By.XPath("//*[@id='jobmanager-table']/thead/tr/th[6]/a"); }
        //Job Posting Form
        public By jobPostingHeader() { return By.CssSelector("h2.sub-head"); }
        //General Information
        public By jobTitleInput() { return By.XPath("(//label[contains(.,'Job Title:')]//following::input)[1]"); }
        public By employerDropdown() { return By.XPath("(//label[contains(.,'Employer:')]//following::select)[1]"); }
        public By jobTypeDropdown() { return By.XPath("(//label[contains(.,'Job Type:')]//following::select)[1]"); }
        public By blindAdCheckbox() { return By.XPath("(//label[contains(.,'Blind Ad: ')]//following::input)[1]"); }
        public By companyDescriptionInput() { return By.XPath("(//label[contains(.,'Company Description:')]//following::input)[1]"); }
        public By remoteCheckbox() { return By.XPath("(//label[contains(.,'Remote:')]//following::input)[1]"); }
        public By categoriesField() { return By.XPath("(//label[contains(.,'Categories:')]//following::li)[1]"); }
        public By categoriesInput() { return By.XPath("(//label[contains(.,'Categories:')]//following::input)[1]"); }
        public By categoriesResultList(String cat) { return By.XPath("//li[contains(.,'" + cat+"')]"); }
        public By categoriesEnteredByValue(String cat) { return By.XPath("//li[@class='search-choice']//span[contains(.,'"+cat+"')]"); }
        //Location
        public By countryDropdown() { return By.XPath("(//label[contains(.,'Country:')]//following::select)[1]"); }
        public By stateDropdown() { return By.XPath("(//label[contains(.,'State:')]//following::select)[1]"); }
        public By cityInput() { return By.XPath("(//label[contains(.,'City:')]//following::input)[1]"); }
        public By streetAddressInput() { return By.XPath("(//label[contains(.,'Street Address:')]//following::input)[1]"); }
        public By postCodeInput() { return By.XPath("(//label[contains(.,'Post Code:')]//following::input)[1]"); }
        //Contact Info
        public By contactNameInput() { return By.XPath("(//label[contains(.,'Contact Name: ')]//following::input)[1]"); }
        public By contactPhoneInput() { return By.XPath("(//label[contains(.,'Contact Phone:')]//following::input)[1]"); }
        public By faxInput() { return By.XPath("(//label[contains(.,'Fax:')]//following::input)[1]"); }
        public By applyDefaulAccEmailRadio() { return By.XPath("(//label[contains(.,'Send application:')]//following::input)[1]"); }
        public By sendApplicationToAlternativeEmailRadio() { return By.XPath("(//label[contains(.,'Send application:')]//following::input)[2]"); }
        public By sendCandidateATS() { return By.XPath("(//label[contains(.,'Send application:')]//following::input)[3]"); }
        public By linkJobApplicationInput() { return By.XPath("(//label[contains(.,'Link to job application:')]//following::input)[1]"); }
        //Description
        public By jobDescriptionTextAreaiFrame() { return By.XPath("//label[contains(.,'Job Description:')]//following::iframe[@title='Rich Text AreaPress ALT-F10 for toolbar. Press ALT-0 for help']"); }
        public By jobDescriptionTextAreaBody() { return By.XPath("//body[@contenteditable='true']"); }
        //Promotion Settings
        public By featureJobCheckbox() { return By.XPath("(//label[contains(.,'Feature Job?:')]//following::input)[1]"); }
        //Buttons Section
        public By cancelButton() { return By.XPath("//input[@value='Cancel']"); }
        public By saveAsDraftButton() { return By.XPath("//input[@value='Save as draft']"); }
        public By previewButton() { return By.XPath("//input[@value='Preview']"); }
        public By publishButton() { return By.XPath("//input[@id='normal_post_job']"); }

  	    public By ExpiredDate() { return By.XPath("//*[@id='jobmanager-table']/tbody/tr/td[5]"); }
  	    public By ListofJobs() { return By.XPath("//table[@id='jobmanager-table']/tbody/tr/td[2]/a"); }
  	    public By EmployerField() {return By.XPath("//*[@class='multiselect dropdown-toggle btn btn-default']"); }
        public By clearButton() { return By.XPath("//*[@class='btn-action btn-sm btn-rounded btn_filters' and @onclick='clearFilter();']"); }

        public By purchseOnLineText() { return By.XPath("//h3[contains(text(),'Purchase online')]"); }
        public By jobsAppliedForTitle() { return By.XPath("//H2[contains(text(),'Jobs Applied For')]"); }

        public By jobsAlertsForTitle() { return By.XPath("//H2[contains(text(),'Job Alerts')]"); }

        public By jobsCopyRightSection() { return By.XPath("//*[@class='copyright_section']"); }


        public By logoOnFooter() { return By.XPath("//img[@src='/download_files/agency-assets/images/footer-logo.png']"); }



    }
}