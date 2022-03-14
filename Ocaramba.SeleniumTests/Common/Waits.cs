using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using System.Globalization;
using NLog;
using OpenQA.Selenium.Support.UI;
using System;

namespace Ocaramba.SeleniumTests.Common
{
    public static class Waits
    {

        public static bool IsElementVisible(IWebDriver webDriver, ElementLocator locator)
        {

            //WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //IWebElement SearchResult = wait.Until(x => x.FindElement(locator,5));
            webDriver.GetElement(locator, 10, e => e.Displayed);
            return true;
        }
    }
}
