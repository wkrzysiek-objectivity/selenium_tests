using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    public class Header : Footer
    {
        protected readonly ElementLocator cartButton = new ElementLocator(Locator.XPath, "//a[@title='View my shopping cart']");
        public Header(DriverContext driverContext) : base(driverContext)
        {
        }
        public CartPage OpenCartPage()
        {
            this.Driver.GetElement(cartButton).Click();
            return new CartPage(this.DriverContext);
        }
    }
}
