using NUnit.Framework;
using Ocaramba.SeleniumTests.DataDriven;
using Ocaramba.SeleniumTests.PageObjects;
using System;
using System.Collections.Generic;

namespace Ocaramba.SeleniumTests.Tests
{
    /// <summary>
    /// Test class.
    /// </summary>
    class ProductBuyWithoutLoginTest : ProjectTestBase
    {
        [TearDown]
        public void TearDown()
        {
            this.DriverContext.Driver.Close();
            this.DriverContext.Driver.Quit();
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsCSV")]
        public void buyProductWithoutLogin(IDictionary<string, string> parameters) {

            this.DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var homePage = new HomePage(this.DriverContext);
            homePage.OpenHomePage();
            homePage.DisplayUnvisibleBlockByJS(homePage.womenCategory);

            var blousesCategoryPage = homePage.goToBlousesSubCategory();
           
            homePage.MoveMouseToByAction(blousesCategoryPage.BlouseElement)
            .AddToCartProduct(blousesCategoryPage.AddToCartProductId2)
            .ContinueShoppingPopupCart();

            var cartPage = homePage.OpenCartPage();

            var authenticationPage = cartPage.ProceedToCheckout();
            authenticationPage.signInPage(parameters["Email"], parameters["Password"]);

            cartPage.ProcessAddress()
                .ClickCheckboxTerms()
                .ProcessCarrier()
                .PayByBankWire()
                .ConfirmOrder();

            Assert.IsTrue(cartPage.OrderConfirmationMessageIsVisible(), "Registration fail.");
        }
    }
}
