using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitedLex.OpenEmrAutomation.Pages
{
    class LoginPage
    {
        //locators
        private static By usernameLocator = By.Id("authUser");
        private static By passwordLocator = By.Id("clearPass");
        private static By languageLocator = By.Name("languageChoice");
        private static By loginLocator = By.XPath("//button[@type='submit']");
        private static By errorLocator = By.XPath("//*[contains(text(),'Invalid')]");
        private static By ackLinkLocator = By.PartialLinkText("Acknowledgments");

        public static void EnterUsername(IWebDriver driver,string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
        }

        public static void EnterPassword(IWebDriver driver,string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }

        public static void SelectLangaugeByText(IWebDriver driver,string languageText)
        {
            SelectElement select = new SelectElement(driver.FindElement(languageLocator));
            select.SelectByText(languageText);
        }

        public static void ClickOnLogin(IWebDriver driver)
        {
            driver.FindElement(loginLocator).Click();
        }

        public static string GetErrorMessage(IWebDriver driver)
        {
            return driver.FindElement(errorLocator).Text;
        }

        public static void ClickOnAcknowledgmentsLink(IWebDriver driver)
        {
            driver.FindElement(ackLinkLocator).Click();
        }

        public static void SwitchToDashboardPage(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
    }
}




