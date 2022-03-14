using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    public class AuthenticationPage : ProjectPageBase
    {
        private readonly ElementLocator createAccountEmailAddressLocator = new ElementLocator(Locator.Id, "email_create");
        private readonly ElementLocator createAccountButtonLocator = new ElementLocator(Locator.Id, "SubmitCreate");

        private readonly ElementLocator signInEmailAddressLocator = new ElementLocator(Locator.Id, "email");
        private readonly ElementLocator signInPasswordLocator = new ElementLocator(Locator.Id, "isPasswd");
        private readonly ElementLocator signInButtonLocator = new ElementLocator(Locator.Id, "SubmitLogin");

        private readonly ElementLocator forgotPasswordButtonLocator = new ElementLocator(Locator.XPath, "//a[@title='Recover your forgotten password']");

        public AuthenticationPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public CreateAccountPage createAccount(string email)
        {
            this.Driver.GetElement(createAccountEmailAddressLocator).SendKeys(email);
            this.Driver.GetElement(createAccountButtonLocator).Click();
            return new CreateAccountPage(this.DriverContext);
        }

        public MyAccountPage signInPage(string email, string password)
        {
            this.Driver.GetElement(signInEmailAddressLocator).SendKeys(email);
            this.Driver.GetElement(signInPasswordLocator).SendKeys(password);
            this.Driver.GetElement(signInButtonLocator).Click();
            return new MyAccountPage(this.DriverContext);
        }

        public void WaitUntilAuthenticationPageLoad(double timeoutInSeconds)
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => this.Driver.GetElement(createAccountEmailAddressLocator).Displayed);
        }
    }
}
