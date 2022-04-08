using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    class HomePageFacade : HeaderFacade
    {
        private readonly ElementLocator signInButton = new ElementLocator(Locator.XPath, "//a[@class='login']");

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageFacade"/> class.
        /// </summary>
        /// <param name="driverContext">Base driverContext.</param>
        public HomePageFacade(DriverContext driverContext) : base(driverContext)
        {
        }
        public void OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            this.Driver.NavigateTo(new Uri(url));
        }
        public void GoToSignInPage() 
        {
            this.Driver.GetElement(signInButton).Click();
        }

        public bool isHomePageDisplayed()
        {
            return this.Driver.GetElement(signInButton).Displayed;
        }
    }
}
