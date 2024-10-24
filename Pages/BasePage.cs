using Autotest.Pages;
using Autotest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Autotest
{
    public  class BasePage
    {
        protected AppiumDriver driver;
        protected WebDriverWait wait;

        public BasePage(AppiumDriver driver)
        {         
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        protected IWebElement WaitForElement(By locator)
        {            
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected void ClickElement(By locator)
        {
            Startup.GetLogger("Global").LogInfo("Натискання на елемент " + locator);
            WaitForElement(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            Startup.GetLogger("Global").LogInfo("Натискання на елемент " + locator);
            var element = WaitForElement(locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}