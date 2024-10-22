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
    public class IOSPaymentPage : BasePaymentPage
    {
        public IOSPaymentPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By Sale => throw new NotImplementedException();

        protected override By SaleParts => throw new NotImplementedException();

        protected override By InternetSale => throw new NotImplementedException();

        protected override By Prepayment => throw new NotImplementedException();

        protected override By Postpaid => throw new NotImplementedException();

        protected override By PostpaidFull => throw new NotImplementedException();

        protected override By SearchGoods => throw new NotImplementedException();

        protected override By PaymentButton => throw new NotImplementedException();

        protected override By PaymentCard => throw new NotImplementedException();

        protected override By PaymentCash => throw new NotImplementedException();

        protected override By PaymentCombine => throw new NotImplementedException();

        protected override By PaymentNoRest => throw new NotImplementedException();

        protected override By Comment => throw new NotImplementedException();

        protected override By RegistrToDps => throw new NotImplementedException();

        protected override By GetGoodsLocator(string goodsName)
        {
            throw new NotImplementedException();
        }
    }
}
