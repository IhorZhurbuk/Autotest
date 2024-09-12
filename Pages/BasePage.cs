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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected void ClickElement(By locator)
        {
            WaitForElement(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            var element = WaitForElement(locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}