using Autotest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.IOSPages
{
    public class IOSCashPaymentPage : BaseCashPaymentPage
    {
        public IOSCashPaymentPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By AmountToPayText => throw new NotImplementedException();

        protected override By ReceivedCashField => throw new NotImplementedException();

        protected override By CommentField => throw new NotImplementedException();
    }
}
