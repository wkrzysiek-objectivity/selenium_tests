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
using OpenQA.Selenium.Interactions;
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

        protected readonly ElementLocator cartPopupContinueShoppingButton = new ElementLocator(Locator.XPath, "//i[@class='icon-chevron-left left']");
        protected readonly ElementLocator cartPopupProceedToCheckoutButton = new ElementLocator(Locator.XPath, "//i[@class='icon-chevron-right right']");
        private readonly ElementLocator error406 = new ElementLocator(Locator.XPath, "//h1[contains(text(),'Error 406 - Not Acceptable')]");

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
        public HomePage OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            this.Driver.NavigateTo(new Uri(url));
            return new HomePage(this.DriverContext);
        }

        /// <summary>
        /// Go to SignIn page.
        /// </summary>
        public AuthenticationPage GoToAuthenticationPage()
        {
            this.Driver.GetElement(this.signInButtonLocator).Click();
            return new AuthenticationPage(this.DriverContext);
        }

        public BlousesCategoryPage goToBlousesSubCategory() {
            this.Driver.GetElement(this.tshirtSubCategory).Click();
            return new BlousesCategoryPage(this.DriverContext);
        }
        public HomePage DisplayUnvisibleBlockByJS(string xpath)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            IWebElement webElement = this.Driver.FindElement(By.XPath(xpath));
            js.ExecuteScript("arguments[0].setAttribute('style', 'display: block')", webElement);
            return new HomePage(this.DriverContext);
        }

        public HomePage MoveMouseToByAction(string xpath)
        {
            IWebElement webElement = Driver.FindElement(By.XPath(xpath));
            Actions action = new Actions(Driver);
            action.MoveToElement(webElement);
            action.Perform();
            return new HomePage(this.DriverContext);
        }

        public HomePage AddToCartProduct(ElementLocator elementLocator)
        {
            this.Driver.GetElement(elementLocator).Click();
            return new HomePage(this.DriverContext);
        }

        public HomePage ContinueShoppingPopupCart()
        {
            this.Driver.GetElement(cartPopupContinueShoppingButton).Click();
            return new HomePage(this.DriverContext);
        }

        public HomePage ProceedToCheckoutPopupCart()
        {
            this.Driver.GetElement(cartPopupProceedToCheckoutButton).Click();
            return new HomePage(this.DriverContext);
        }

        public bool Error406IsVisible()
        {
            try
            {
                this.Driver.GetElement(error406);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
