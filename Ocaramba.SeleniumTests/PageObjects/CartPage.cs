using Ocaramba.Extensions;
using Ocaramba.SeleniumTests.PageObjects;
using Ocaramba.Types;
using OpenQA.Selenium;

namespace Ocaramba.SeleniumTests
{
    public class CartPage : ProjectPageBase
    {
        private readonly ElementLocator continueShoppingButton = new ElementLocator(Locator.CssSelector, "a[title='Continue shopping']");
        private readonly ElementLocator proceedToCheckoutButton = new ElementLocator(Locator.CssSelector, "a[class='button btn btn-default standard-checkout button-medium']");
        private readonly ElementLocator processAddressButton = new ElementLocator(Locator.CssSelector, "button[name='processAddress']");
        private readonly ElementLocator processCarrierButton = new ElementLocator(Locator.CssSelector, "button[name='processCarrier']");
        private readonly ElementLocator payByBankWireButton = new ElementLocator(Locator.CssSelector, "a[title='Pay by bank wire']");
        private readonly ElementLocator confirmOrderButton = new ElementLocator(Locator.CssSelector, "button[class='button btn btn-default button-medium']");

        private readonly ElementLocator orderConfirmationMessage= new ElementLocator(Locator.XPath, "//strong[contains(text(),'Your order on My Store is complete.')]");

        public CartPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ContinueShopping()
        {
            this.Driver.GetElement(continueShoppingButton).Click();
        }

        public AuthenticationPage ProceedToCheckout()
        {
            this.Driver.GetElement(proceedToCheckoutButton).Click();
            return new AuthenticationPage(this.DriverContext);
        }
        public void ProcessAddress()
        {
            this.Driver.GetElement(processAddressButton).Click();
        }
        public void ProcessCarrier()
        {
            this.Driver.GetElement(processCarrierButton).Click();
        }
        public void PayByBankWire()
        {
            this.Driver.GetElement(payByBankWireButton).Click();
        }
        public void ClickCheckboxTerms()
        {
            IWebElement agreeTermsCheckbox = this.Driver.FindElement(By.CssSelector("input[name='cgv']"));
            agreeTermsCheckbox.Click();
        }
        public void ConfirmOrder()
        {
            this.Driver.GetElement(confirmOrderButton).Click();
        }
        public bool OrderConfirmationMessageIsVisible() 
        {
            try
            {
                this.Driver.GetElement(orderConfirmationMessage);
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