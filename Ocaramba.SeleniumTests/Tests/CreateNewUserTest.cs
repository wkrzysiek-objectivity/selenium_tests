// <copyright file="HerokuappTestsNUnit.cs" company="Ocaramba">
// Copyright (c) Ocaramba. All rights reserved.
// </copyright>
// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba

using NUnit.Framework;
using Ocaramba.SeleniumTests.DataDriven;
using Ocaramba.SeleniumTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Ocaramba.SeleniumTests
{
    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CreateNewUserTest : ProjectTestBase
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
            WebDriverWait wait = new WebDriverWait(this.DriverContext.Driver, TimeSpan.FromSeconds(10));

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

            var myAccountPage = createAccountPage.ClickSaveButton();

            wait.Until(d => this.DriverContext.Driver.FindElement(By.XPath(myAccountPage.myAccountPageTitleXpath)).Displayed);
            Assert.IsTrue(myAccountPage.PageTitleIsVisible(), "Registration fail.");
        }
    }
}
