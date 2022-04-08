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
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
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
            blousesCategoryPage.MoveMouseToByAction(blousesCategoryPage.BlouseElement);
            blousesCategoryPage.AddToCartProduct(blousesCategoryPage.AddToCartProductId2);
            blousesCategoryPage.ContinueShoppingPopupCart();

            var cartPage = homePage.OpenCartPage();

            var authenticationPage = cartPage.ProceedToCheckout();
            authenticationPage.signInPage(parameters["Email"], parameters["Password"]);

            cartPage.ProcessAddress();
            cartPage.ClickCheckboxTerms();
            cartPage.ProcessCarrier();
            cartPage.PayByBankWire();
            cartPage.ConfirmOrder();

            Assert.IsTrue(cartPage.OrderConfirmationMessageIsVisible(), "Registration fail.");
        }
    }
}
