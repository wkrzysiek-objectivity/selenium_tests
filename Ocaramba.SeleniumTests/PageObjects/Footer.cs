using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    public class Footer : ProjectPageBase
    {
        private readonly ElementLocator myAccount = new ElementLocator(Locator.XPath, "//a[@title='Manage my customer account']");
        private readonly ElementLocator myOrders = new ElementLocator(Locator.XPath, "//a[@title='My orders']");
        private readonly ElementLocator myCreditSlips = new ElementLocator(Locator.XPath, "//a[@title='My credit slips']");
        private readonly ElementLocator myAdresses = new ElementLocator(Locator.XPath, "//a[@title='My addresses']");
        private readonly ElementLocator myPersonalInfo = new ElementLocator(Locator.XPath, "//a[@title='Manage my personal information']");

        public Footer(DriverContext driverContext) : base(driverContext)
        {
        }
        public MyAccountPage OpenMyAccountPage()
        {
            this.Driver.GetElement(myAccount).Click();
            return new MyAccountPage(this.DriverContext);
        }
        public MyAccountPage OpenMyOrdersPage()
        {
            this.Driver.GetElement(myOrders).Click();
            return new MyAccountPage(this.DriverContext);
        }
        public MyAddresses OpenMyAdressesPage()
        {
            this.Driver.GetElement(myAdresses).Click();
            return new MyAddresses(this.DriverContext);
        }
    }
}
