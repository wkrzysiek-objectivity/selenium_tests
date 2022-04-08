using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    public class MyAddresses : Header
    {
        protected readonly ElementLocator updateAddressButton = new ElementLocator(Locator.XPath, "//a[@title='Update']");
        protected readonly ElementLocator deleteAddressButton = new ElementLocator(Locator.XPath, "//a[@title='Delete']");

        public MyAddresses(DriverContext driverContext) : base(driverContext)
        {
        }
        public CreateAccountPage UpdateAddressPage()
        {
            this.Driver.GetElement(updateAddressButton, 10).Click();
            return new CreateAccountPage(this.DriverContext);
        }
    }
}
