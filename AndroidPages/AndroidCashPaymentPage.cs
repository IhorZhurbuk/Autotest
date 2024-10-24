using Autotest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.AndroidPages
{
    public class AndroidCashPaymentPage : BaseCashPaymentPage
    {
        public AndroidCashPaymentPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By AmountToPayText => By.XPath("(//android.widget.TextView[contains(@text, '₴')])[3]");

        protected override By ReceivedCashField => By.XPath("//android.widget.EditText[@text='0,00']");

        protected override By CommentField => By.XPath("//android.widget.EditText[@text='Коментар']");
    }
}
