// <copyright file="ProjectPageBase.cs" company="Ocaramba">
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

using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Ocaramba.SeleniumTests
{
    /// <summary>
    /// Partial class of ProjectPageBase.
    /// </summary>
    public partial class ProjectPageBase
    {
        
        protected readonly ElementLocator cartPopupContinueShoppingButton = new ElementLocator(Locator.XPath, "//i[@class='icon-chevron-left left']");
        protected readonly ElementLocator cartPopupProceedToCheckoutButton = new ElementLocator(Locator.XPath, "//i[@class='icon-chevron-right right']");
        private readonly ElementLocator error406 = new ElementLocator(Locator.XPath, "//h1[contains(text(),'Error 406 - Not Acceptable')]");


        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPageBase"/> class.
        /// </summary>
        /// <param name="driverContext">Base driverContext.</param>
        public ProjectPageBase(DriverContext driverContext)
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

        public void DisplayUnvisibleBlockByJS(string xpath) {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            IWebElement webElement = this.Driver.FindElement(By.XPath(xpath));
            js.ExecuteScript("arguments[0].setAttribute('style', 'display: block')", webElement);
        }

        public void MoveMouseToByAction(string xpath) {
            IWebElement webElement = Driver.FindElement(By.XPath(xpath));
            Actions action = new Actions(Driver);
            action.MoveToElement(webElement);
            action.Perform();
        }

        public void AddToCartProduct(ElementLocator elementLocator)
        {
            this.Driver.GetElement(elementLocator).Click();
        }

        public void ContinueShoppingPopupCart() {
            this.Driver.GetElement(cartPopupContinueShoppingButton).Click();
        }

        public void ProceedToCheckoutPopupCart()
        {
            this.Driver.GetElement(cartPopupProceedToCheckoutButton).Click();
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
