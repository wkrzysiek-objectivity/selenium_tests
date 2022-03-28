using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.PageObjects
{
    public class BlousesCategoryPage : ProjectPageBase
    {
        private readonly string blouseElement = "//*[@class='ajax_block_product col-xs-12 col-sm-6 col-md-4 first-in-line last-line first-item-of-tablet-line first-item-of-mobile-line last-mobile-line']";

        private readonly ElementLocator addToCartProductId2 = new ElementLocator(Locator.XPath, "//a[@data-id-product='2']");

        public BlousesCategoryPage(DriverContext driverContext) : base(driverContext)
        {
        }

    /*    public ElementLocator getAddToCartProductId2() {
            return addToCartProductId2;
        }*/

        public ElementLocator AddToCartProductId2 { get => addToCartProductId2;}
        public string BlouseElement { get => blouseElement; }
    }
}
