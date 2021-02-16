using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitedLex.OpenEmrAutomation.Pages
{
    class DashboardPage
    {
        private static By flowBoardLocator = By.XPath("//*[text()='Flow Board']");

        public static void WaitForFlowBoardElementPresent(IWebDriver driver)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.Message = "Wait for flow board text!";
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(x => x.FindElement(flowBoardLocator));
        }

        public static string GetTitle(IWebDriver driver)
        {
            return driver.Title;
        }
    }
}
