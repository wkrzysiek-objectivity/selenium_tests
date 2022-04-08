using Ocaramba.SeleniumTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.Facade
{
    class LoginFacade : FacadeBasePage
    {
        private HomePageFacade homePageFacade;
        private SignInPageFacade signInPageFacade;
        private HeaderFacade headerFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginFacade"/> class.
        /// </summary>
        /// <param name="driverContext">Base driverContext.</param>
        public LoginFacade(DriverContext driverContext) : base(driverContext)
        {
        }

        public HomePageFacade getHomePageFacade() 
        {
            if (homePageFacade == null)
            {
                homePageFacade = new HomePageFacade(this.DriverContext);
                return homePageFacade;
            }
            else
                return homePageFacade;
        }

        public SignInPageFacade getSignInPageFacade()
        {
            if (signInPageFacade == null)
            {
                signInPageFacade = new SignInPageFacade(this.DriverContext);
                return signInPageFacade;
            }
            else
                return signInPageFacade;
        }
        public HeaderFacade getHeaderFacade()
        {
            if (headerFacade == null)
            {
                headerFacade = new HeaderFacade(this.DriverContext);
                return headerFacade;
            }
            else
                return headerFacade;
        }

        public void logInAndLogout(String email, String password) 
        {
            getHomePageFacade().OpenHomePage();
            getHomePageFacade().GoToSignInPage();
            getSignInPageFacade().setEmail(email);
            getSignInPageFacade().setPasswordl(password);
            getSignInPageFacade().clickSignIn();
            getHeaderFacade().clickSignOut();
        }
    }
}
