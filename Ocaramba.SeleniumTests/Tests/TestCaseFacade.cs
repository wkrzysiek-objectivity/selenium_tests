using NUnit.Framework;
using Ocaramba.SeleniumTests.DataDriven;
using Ocaramba.SeleniumTests.Facade;
using Ocaramba.SeleniumTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.Tests
{
    class TestCaseFacade : ProjectTestBase
    {
        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsCSV")]
        public void LogInAndLogout(IDictionary<string, string> parameters)
        {
            LoginFacade loginFacade = new LoginFacade(this.DriverContext);
            loginFacade.logInAndLogout(parameters["Email"], parameters["Password"]);

            Assert.IsTrue(new SignInPageFacade(this.DriverContext).isSignInPageDisplayed(), "User is not log out succesfully.");
        }
    }
}
