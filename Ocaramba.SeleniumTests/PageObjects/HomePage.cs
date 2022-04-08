// <copyright file="InternetPage.cs" company="Ocaramba">
// Copyright (c) Ocaramba. All rights reserved.
// </copyright>
// <license>
//     The MIT License (MIT)
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </license>

using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using System;
using System.Globalization;

namespace Ocaramba.SeleniumTests.PageObjects
{
    /// <summary>
    /// Page object class.
    /// </summary>
    public class HomePage : Header
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements.
        /// </summary>
        private readonly ElementLocator signInButtonLocator = new ElementLocator(Locator.XPath, "//a[@class='login']");
        private readonly ElementLocator tshirtSubCategory = new ElementLocator(Locator.XPath, "//a[@title='Blouses']");

        public readonly String womenCategory = "//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[1]/ul";

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        /// <param name="driverContext">Base driverContext.</param>
        public HomePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage.
        /// </summary>
        public void OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            this.Driver.NavigateTo(new Uri(url));
        }

        /// <summary>
        /// Go to SignIn page.
        /// </summary>
        public void GoToAuthenticationPage()
        {
            this.Driver.GetElement(this.signInButtonLocator).Click();
        }

        public BlousesCategoryPage goToBlousesSubCategory() {
            this.Driver.GetElement(this.tshirtSubCategory).Click();
            return new BlousesCategoryPage(this.DriverContext);
        }
    }
}
