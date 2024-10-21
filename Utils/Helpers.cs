using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Utils
{
    public class Helpers
    {
        public static bool CheckAndCloseModal(AppiumDriver driver, By modalLocator, string expectedText, By buttonLocator)
        {
            try
            {
                var modalElement = driver.FindElement(modalLocator);
                if (modalElement != null && modalElement.Text.Equals(expectedText))
                {
                    driver.FindElement(buttonLocator).Click();
                    return true;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return false;
        }
    }
}
