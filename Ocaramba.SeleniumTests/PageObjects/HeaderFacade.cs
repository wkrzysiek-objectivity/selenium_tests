using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    class HeaderFacade : FacadeBasePage
    {
        protected readonly ElementLocator signOutButton = new ElementLocator(Locator.XPath, "//a[@title='Log me out']");
        public HeaderFacade(DriverContext driverContext) : base(driverContext)
        {
        }
        public void clickSignOut()
        {
            this.Driver.GetElement(signOutButton).Click();
        }
    }
}
