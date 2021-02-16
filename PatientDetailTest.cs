using NUnit.Framework;
using OpenEmrAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnitedLex.OpenEmrAutomation.Base;
using UnitedLex.OpenEmrAutomation.Pages;
using UnitedLex.OpenEmrAutomation.Utilities;

namespace OpenEmrAutomation
{
    class PatientDetailTest : WebDriverWrapper
    {
        public static object[] AddPatientTestData()
        {
            object[] main = ExcelUtils.GetSheetIntoObjectArray(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\OpenEmrData.xlsx", "AddPatientTestData");
            return main;
        }
        [Test,TestCaseSource("AddPatientTestData")]
        public void AddPatientTest(string username,string password,string language,string fname,string lname,string dob,string gender,string expectedValue)
        {
            LoginPage.EnterUsername(driver, "admin");
            LoginPage.EnterPassword(driver, "pass");

            DataTable dt = DBUtils.GetSelectStatementIntoDataTable("select * from persons");
            Assert.True(dt.Columns.Contains("bala"));
        }
    }
}
