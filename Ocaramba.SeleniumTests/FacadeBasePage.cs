using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace Ocaramba.SeleniumTests
{
    class FacadeBasePage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FacadeBasePage"/> class.
        /// </summary>
        /// <param name="driverContext">Base driverContext.</param>
        public FacadeBasePage(DriverContext driverContext)
        {
            this.DriverContext = driverContext;
            this.Driver = driverContext.Driver;
        }

        /// <summary>
        /// Gets or sets IWebDriver.
        /// </summary>
        protected IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets Driver context.
        /// </summary>
        protected DriverContext DriverContext { get; set; }
    }
}
