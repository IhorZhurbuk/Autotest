using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Pages
{
    public abstract class BaseShiftPage : BasePage
    {
        protected BaseShiftPage(AppiumDriver driver) : base(driver)
        {
        }
        protected abstract By ChoosePayment { get; }

        public abstract BasePaymentPage MethodofPayment();
    }
}
