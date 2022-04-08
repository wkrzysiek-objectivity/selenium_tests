using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium.Support.UI;
using Ocaramba.SeleniumTests.Common;
using System;
using OpenQA.Selenium;

namespace Ocaramba.SeleniumTests.PageObjects
{
    public class CreateAccountPage : AuthenticationPage
    {
        private readonly ElementLocator mrTitleRadio = new ElementLocator(Locator.XPath, "//*[@id='id_gender1']");
        private readonly ElementLocator mrsTitleRadio = new ElementLocator(Locator.XPath, "//*[@id='id_gender2']");

        private readonly ElementLocator firstNameField = new ElementLocator(Locator.Id, "customer_firstname");
        private readonly ElementLocator lastNameField = new ElementLocator(Locator.Id, "customer_lastname");
        private readonly ElementLocator emailField = new ElementLocator(Locator.Id, "email");
        private readonly ElementLocator passwordField = new ElementLocator(Locator.Id, "passwd");
        private readonly ElementLocator firstNameAddressField = new ElementLocator(Locator.Id, "firstname");
        private readonly ElementLocator lastNameAddressField = new ElementLocator(Locator.Id, "lastname");
        private readonly ElementLocator companyAddressField = new ElementLocator(Locator.Id, "company");
        private readonly ElementLocator addressFirstLineAddressField = new ElementLocator(Locator.Id, "address1");
        private readonly ElementLocator addressSecondLineAddressField = new ElementLocator(Locator.Id, "address2");
        private readonly ElementLocator cityAddressField = new ElementLocator(Locator.Id, "city");
        private readonly ElementLocator zipAddressField = new ElementLocator(Locator.Id, "postcode");
        private readonly ElementLocator additionalInformationAddressField = new ElementLocator(Locator.Id, "other");
        private readonly ElementLocator homePhoneAddressField = new ElementLocator(Locator.Id, "phone");
        private readonly ElementLocator mobilePhoneAddressField = new ElementLocator(Locator.Id, "phone_mobile");
        private readonly ElementLocator addressAliasAddressField = new ElementLocator(Locator.Id, "alias");

        private readonly ElementLocator registerButton = new ElementLocator(Locator.Id, "submitAccount");
        private readonly ElementLocator submitAddressButton = new ElementLocator(Locator.Id, "submitAddress");


        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountPage"/> class.
        /// </summary>
        /// <param name="driverContext">
        /// The driver context.
        /// </param>
        public CreateAccountPage(DriverContext driverContext) : base(driverContext)
        {
        }
        public CreateAccountPage SetMrCheckbox()
        {
            this.Driver.GetElement(mrTitleRadio,10).Click();
            return this;
        }
        public CreateAccountPage SetMrsCheckbox()
        {
            this.Driver.GetElement(mrsTitleRadio,10).Click();
            return this;
        }
        public CreateAccountPage SetFirstName(string text)
        {
            this.Driver.GetElement(firstNameField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetLastName(string text)
        {
            this.Driver.GetElement(lastNameField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetEmail(string text)
        {
            this.Driver.GetElement(emailField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetPassword(string text)
        {
            this.Driver.GetElement(passwordField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetDayOfBirth(string text)
        {
            IWebElement DropDownElement = this.Driver.FindElement(By.XPath("//*[@id='days']"));
            SelectElement selectElement = new SelectElement(DropDownElement);
            selectElement.SelectByValue(text);
            return this;
        }

        public CreateAccountPage SetMonthOfBirth(string text)
        {
            IWebElement DropDownElement = this.Driver.FindElement(By.XPath("//*[@id='months']"));
            SelectElement selectElement = new SelectElement(DropDownElement);
            selectElement.SelectByValue(text);
            return this;
        }

        public CreateAccountPage SetYearOfBirthField(string text)
        {
            IWebElement DropDownElement = this.Driver.FindElement(By.XPath("//*[@id='years']"));
            SelectElement selectElement = new SelectElement(DropDownElement);
            selectElement.SelectByValue(text);
            return this;
        }

        public CreateAccountPage ClickNewsletterCheckbox()
        {
            this.Driver.FindElement(By.Id("newsletter")).Click();
            return this;
        }

        public CreateAccountPage ClickSpecialOffersCheckbox()
        {
            this.Driver.FindElement(By.XPath("//*[@name='optin']")).Click();
            return this;
        }

        public CreateAccountPage SetFirstNameAddress(string text)
        {
            this.Driver.GetElement(firstNameAddressField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetLastNameAddress(string text)
        {
            this.Driver.GetElement(lastNameAddressField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetCompanyAddress(string text)
        {
            this.Driver.GetElement(companyAddressField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetFirstLineAddress(string text)
        {
            this.Driver.GetElement(addressFirstLineAddressField).SendKeys(text);
            return this;
        }

        public CreateAccountPage SetSecondLineAddress(string text)
        {
            this.Driver.GetElement(addressSecondLineAddressField).SendKeys(text);
            return this;
        }
        public CreateAccountPage SetCityAddress(string text)
        {
            this.Driver.GetElement(cityAddressField).Clear();
            this.Driver.GetElement(cityAddressField).SendKeys(text);
            return this;
        }
        public string GetCityAddress() 
        {
            string attribute = this.Driver.GetElement(cityAddressField).GetAttribute("value");
            return attribute;
        }
        public CreateAccountPage SetStateAddress(string text)
        {
            IWebElement DropDownElement = this.Driver.FindElement(By.XPath("//*[@id='id_state']"));
            SelectElement selectElement = new SelectElement(DropDownElement);
            selectElement.SelectByValue(text);
            return this;
        }
        public CreateAccountPage SetZipAddress(string text)
        {
            this.Driver.GetElement(zipAddressField).SendKeys(text);
            return this;
        }
        public CreateAccountPage SetCountryAddress(string text)
        {
            IWebElement DropDownElement = this.Driver.FindElement(By.XPath("//*[@id='id_country']"));
            SelectElement selectElement = new SelectElement(DropDownElement);
            selectElement.SelectByValue(text);
            return this;
        }
        public CreateAccountPage SetAdditionalInformationAddress(string text)
        {
            this.Driver.GetElement(additionalInformationAddressField).SendKeys(text);
            return this;
        }
        public CreateAccountPage SetHomePhone(string text)
        {
            this.Driver.GetElement(homePhoneAddressField).SendKeys(text);
            return this;
        }
        public CreateAccountPage SetMobilePhone(string text)
        {
            this.Driver.GetElement(mobilePhoneAddressField).SendKeys(text);
            return this;
        }
        public CreateAccountPage SetAlias(string text)
        {
            this.Driver.GetElement(addressAliasAddressField).SendKeys(text);
            return this;
        }
        public MyAccountPage ClickSaveButton()
        {
            this.Driver.GetElement(registerButton).Click();
            return new MyAccountPage(this.DriverContext);
        }
        public MyAccountPage ClickSubmitAddressButton()
        {
            this.Driver.GetElement(submitAddressButton).Click();
            return new MyAccountPage(this.DriverContext);
        }
        public void PageTitleIsVisible() 
        {
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            wait.Until(x => x.FindElement(By.XPath("//*[contains(text(),'Create an account')]")));
        }
    }
}