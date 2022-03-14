using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;

namespace Ocaramba.SeleniumTests.PageObjects
{
    public class MyAccountPage : CreateAccountPage
    {
        private readonly ElementLocator myAccountPageTitle = new ElementLocator(Locator.XPath, "//h1[contains(text(),'My account')]");

        public MyAccountPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public bool PageTitleIsVisible() 
        {
            try 
            {
                this.Driver.GetElement(myAccountPageTitle);
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