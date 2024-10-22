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
    public class AndroidPaymentPages:BasePaymentPage
    {
        public AndroidPaymentPages(AppiumDriver driver) : base(driver)
        {
        }

        protected override By Sale => By.XPath("//android.widget.TextView[@text=\"Продаж\"]");

        protected override By InternetSale => By.XPath("//android.widget.TextView[@text=\"Інтернет продаж\"]");

        protected override By Prepayment => By.XPath("//android.widget.TextView[@text=\"Передоплата\"]");

        protected override By Postpaid => By.XPath("//android.widget.TextView[@text=\"Післяплата\"]");

        protected override By PostpaidFull => By.XPath("//android.widget.TextView[@text=\"Післяплата повна\"]");

        protected override By SaleParts => By.XPath("//android.widget.TextView[@text=\"Оплата частинами\"]");

        protected override By SearchGoods => By.XPath("//android.widget.EditText[@text=\"Пошук товару...\"]");

        protected override By PaymentButton => By.XPath("//android.widget.Button[@text=\"Оплата\"]");

        protected override By PaymentCard => By.XPath("//android.widget.TextView[@text=\"Оплата карткою\"]");

        protected override By PaymentCash => By.XPath("//android.widget.TextView[@text=\"Оплата готівкою\"]");

        protected override By PaymentCombine => By.XPath("//android.widget.TextView[@text=\"Комбінована оплата\"]");

        protected override By PaymentNoRest => By.XPath("//android.widget.Button[@text=\"Оплата без решти\"]");

        protected override By Comment => By.XPath("//android.widget.EditText[@text=\"Коментар\"]");

        protected override By RegistrToDps => By.XPath("//android.widget.Button[@text=\"Зареєструвати в ДПС\"]");

        protected override By GetGoodsLocator(string goodsName)
        {
            return By.XPath($"//android.widget.TextView[@text='{goodsName}']");
        }
    }
}
