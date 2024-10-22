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
    public class IOShiftPage : BaseShiftPage
    {
        public IOShiftPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By ChoosePayment => throw new NotImplementedException();

        public override BasePaymentPage MethodofPayment()
        {
            throw new NotImplementedException();
        }
    }
}
