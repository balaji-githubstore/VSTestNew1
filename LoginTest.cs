using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using UnitedLex.OpenEmrAutomation.Base;
using UnitedLex.OpenEmrAutomation.Pages;
using UnitedLex.OpenEmrAutomation.Utilities;

namespace UnitedLex.OpenEmrAutomation
{
    public class LoginTest : WebDriverWrapper
    {
        

        //admin,pass,English (Indian),OpenEMR
        //physician,physician,English (Indian),OpenEMR

        public static object[] ValidCredentialTestData()
        {
            object[] temp1 = new object[4]; //number of paramter
            temp1[0] = "admin";
            temp1[1] = "pass";
            temp1[2] = "English (Indian)";
            temp1[3] = "OpenEMR";

            //object[] temp2 = new object[4]; //number of parameter
            //temp2[0] = "physician";
            //temp2[1] = "physician";
            //temp2[2] = "English (Indian)";
            //temp2[3] = "OpenEMR";

            //object[] temp3 = new object[4]; //number of parameter
            //temp3[0] = "clinician";
            //temp3[1] = "clinician";
            //temp3[2] = "English (Indian)";
            //temp3[3] = "OpenEMR";

            object[] main = new object[1]; //number of test case
            main[0] = temp1;
            //main[1] = temp2;
            //main[2] = temp3;

            return main;
        }

        [Test,TestCaseSource("ValidCredentialTestData")]
        public void ValidCredentialTest(string username,string password,string language,string expectedValue)
        {
            LoginPage.EnterUsername(driver,username);
            LoginPage.EnterPassword(driver, password);
            LoginPage.SelectLangaugeByText(driver, language);
            LoginPage.ClickOnLogin(driver);
            DashboardPage.WaitForFlowBoardElementPresent(driver);
            string actualValue = DashboardPage.GetTitle(driver);
            Assert.AreEqual(expectedValue, actualValue);
            test.Log(AventStack.ExtentReports.Status.Info, "done with valid credential " + username);
        }

        public static object[] InvalidCredentialTestData()
        {
            object[] main = ExcelUtils.GetSheetIntoObjectArray(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\OpenEmrData.xlsx", "InvalidCredentialTestData");
            return main;
        }

        [Test,TestCaseSource("InvalidCredentialTestData")]
        public void InvalidCredentialTest(string username, string password, string language, string expectedValue)
        {
            LoginPage.EnterUsername(driver, username);
            LoginPage.EnterPassword(driver, password);
            LoginPage.SelectLangaugeByText(driver, language);
            LoginPage.ClickOnLogin(driver);
            string actualValue = LoginPage.GetErrorMessage(driver);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AcknowledgmentsLicensingandCertificationLinkTest()
        {
            LoginPage.ClickOnAcknowledgmentsLink(driver);

            LoginPage.SwitchToDashboardPage(driver);
            //check for true==true
            Assert.True(driver.PageSource.Contains("List of Contributors"), "Assertion on the text - List of Contributors");

        }
    }
}