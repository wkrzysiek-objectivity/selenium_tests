using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    class SignInPageFacade : HeaderFacade
    {
        private readonly ElementLocator signInEmailAddress = new ElementLocator(Locator.Id, "email");
        private readonly ElementLocator signInPassword = new ElementLocator(Locator.XPath, "//input[@name='passwd']");
        private readonly ElementLocator signInButton = new ElementLocator(Locator.Id, "SubmitLogin");

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPageFacade"/> class.
        /// </summary>
        /// <param name="driverContext">Base driverContext.</param>
        public SignInPageFacade(DriverContext driverContext) : base(driverContext)
        {
        }

        public void setEmail(String email)
        {
            this.Driver.GetElement(signInEmailAddress).Clear();
            this.Driver.GetElement(signInEmailAddress).SendKeys(email);
        }
        public void setPasswordl(String password)
        {
            this.Driver.GetElement(signInPassword).Clear();
            this.Driver.GetElement(signInPassword).SendKeys(password);
        }
        public void clickSignIn()
        {
            this.Driver.GetElement(signInButton).Click();
        }
        public bool isSignInPageDisplayed()
        {
            return this.Driver.GetElement(signInEmailAddress).Displayed;
        }
    }
}
