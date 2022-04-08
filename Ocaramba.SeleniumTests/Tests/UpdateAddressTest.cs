using NUnit.Framework;
using Ocaramba.SeleniumTests.DataDriven;
using Ocaramba.SeleniumTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocaramba.SeleniumTests.Tests
{
    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class UpdateAddressTest : ProjectTestBase
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
        public void AddNewUser(IDictionary<string, string> parameters)
        {
            var homePage = new HomePage(this.DriverContext);
            homePage.OpenHomePage();

            var authenticationPage = homePage.GoToAuthenticationPage();
            authenticationPage.signInPage(parameters["Email"], parameters["Password"]);

            var myAddressPage = homePage.OpenMyAdressesPage();

            var modifyAddressPage = myAddressPage.UpdateAddressPage();

            Assert.IsTrue(modifyAddressPage.GetCityAddress().Equals("Poznan") , "City before change is incorrect.");

            modifyAddressPage.SetCityAddress("Objectivity");
            modifyAddressPage.ClickSubmitAddressButton();
            myAddressPage.UpdateAddressPage();

            Assert.IsTrue(modifyAddressPage.GetCityAddress().Equals("Objectivity"), "City after change is incorrect.");
        }
    }
}
