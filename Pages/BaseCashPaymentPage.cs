using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Pages
{
    public abstract class BaseCashPaymentPage : BasePage
    {
        protected BaseCashPaymentPage(AppiumDriver driver) : base(driver)
        {
        }
        protected abstract By AmountToPayText { get; }
        protected abstract By ReceivedCashField { get; }
        protected abstract By CommentField { get; }
        public void CompleteCashPayment()
        {
            var amountToPayElement = driver.FindElement(AmountToPayText);
            string amountToPay = amountToPayElement.Text.Replace("₴", "").Trim(); 
            EnterText(ReceivedCashField, amountToPay);
            EnterText(CommentField, "Коментар до оплати готівкою");
        }
    }
}
