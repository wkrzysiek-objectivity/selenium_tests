// <copyright file="HerokuappTestsNUnit.cs" company="Ocaramba">
// Copyright (c) Ocaramba. All rights reserved.
// </copyright>
// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.SeleniumTests.PageObjects;
using System.Collections.Generic;
using Ocaramba.SeleniumTests.DataDriven;

namespace Ocaramba.SeleniumTests
{
    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CreateNewUserTest : ProjectTestBase
    {

        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsCSV")]
        public void AddNewUser(IDictionary<string, string> parameters)
        {
            var homePage = new HomePage(this.DriverContext);
            homePage.OpenHomePage();
            homePage.GoToAuthenticationPage();

            var authenticationPage = new AuthenticationPage(this.DriverContext);

            var createAccountPage = authenticationPage.createAccount(parameters["Email"]);
            createAccountPage.PageTitleIsVisible();
            createAccountPage.SetMrCheckbox();
            createAccountPage.SetFirstName(parameters["FirstName"]);
            createAccountPage.SetLastName(parameters["LastName"]);
            createAccountPage.SetPassword(parameters["Password"]);
            createAccountPage.SetDayOfBirth(parameters["DayOfBirth"]);
            createAccountPage.SetMonthOfBirth(parameters["MonthOfBirth"]);
            createAccountPage.SetYearOfBirthField(parameters["YearOfBirth"]);
            createAccountPage.ClickNewsletterCheckbox();
            createAccountPage.ClickSpecialOffersCheckbox();
            createAccountPage.SetFirstNameAddress(parameters["FirstNameAddress"]);
            createAccountPage.SetLastNameAddress(parameters["LastNameAddress"]);
            createAccountPage.SetFirstLineAddress(parameters["AddressFirstLine"]);
            createAccountPage.SetCityAddress(parameters["City"]);
            createAccountPage.SetStateAddress(parameters["State"]);
            createAccountPage.SetZipAddress(parameters["Zip"]);
            createAccountPage.SetCountryAddress(parameters["Country"]);
            createAccountPage.SetMobilePhone(parameters["MobilePhone"]);
            createAccountPage.SetAlias(parameters["Alias"]);
            
            var myAccountPage = createAccountPage.ClickRegisterButton();

            Assert.IsTrue(myAccountPage.PageTitleIsVisible(), "Registration fail.");
        }
    }
}
