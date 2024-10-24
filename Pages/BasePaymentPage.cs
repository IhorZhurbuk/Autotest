using Autotest.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Pages
{
    public abstract class BasePaymentPage : BasePage
    {
        protected PageFactory pageFactory;
        protected BasePaymentPage(AppiumDriver driver) : base(driver)
        {
        }
        protected abstract By Sale { get; }
        protected abstract By SaleParts { get; }
        protected abstract By InternetSale { get; }
        protected abstract By Prepayment { get; }
        protected abstract By Postpaid { get; }
        protected abstract By PostpaidFull { get; }
        protected abstract By SearchGoods { get; }
        protected abstract By PaymentButton { get; }
        protected abstract By PaymentCard { get; }
        protected abstract By PaymentCash { get; }
        protected abstract By PaymentCombine { get; }
        protected abstract By PaymentNoRest { get; }
        protected abstract By Comment { get; }
        protected abstract By RegistrToDps { get; }
        protected abstract By GetGoodsLocator(string goodsName);
        public void СhooseMethodofPayment(PaymentMethod paymentMethod)
        {
            By paymentLocator;
            switch (paymentMethod)
            {
                case PaymentMethod.Sale:
                    paymentLocator = Sale;
                    break;
                case PaymentMethod.SaleParts:
                    paymentLocator = SaleParts;
                    break;
                case PaymentMethod.InternetSale:
                    paymentLocator = InternetSale;
                    break;
                case PaymentMethod.Prepayment:
                    paymentLocator = Prepayment;
                    break;
                case PaymentMethod.Postpaid:
                    paymentLocator = Postpaid;
                    break;
                case PaymentMethod.PostpaidFull:
                    paymentLocator = PostpaidFull;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(paymentMethod), paymentMethod, null);
            }
            ClickElement(paymentLocator);
        }
        public void AddGoods(Goods selectedGoods)
        {
            ClickElement(SearchGoods);
            string goodsName;
            switch (selectedGoods)
            {
                case Goods.AutoTestItem1:
                    goodsName = "Товар автотест #1";
                    break;
                case Goods.AutoTestItem2:
                    goodsName = "Товар автотест #2";
                    break;
                case Goods.AutoTestItem3:
                    goodsName = "Товар автотест #3";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(selectedGoods), selectedGoods, null);
            }

            EnterText(SearchGoods, goodsName);
            By goodsLocator = GetGoodsLocator(goodsName);
            ClickElement(goodsLocator);
        }
        public void CreatePayment(PaymentTypes paymentTypes)
        {
            ClickElement(PaymentButton);
            By paymentLocator;

            switch (paymentTypes)
            {
                case PaymentTypes.Card:
                    paymentLocator = PaymentCard;
                    break;
                case PaymentTypes.Cash:
                    paymentLocator = PaymentCash;
                    break;
                case PaymentTypes.Combine:
                    paymentLocator = PaymentCombine;
                    break;
                case PaymentTypes.NoRest:
                    paymentLocator = PaymentNoRest;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(paymentTypes), paymentTypes, null);
            }

            ClickElement(paymentLocator);
        }
        public void CompletePayment(PaymentTypes paymentType)
        {
            CreatePayment(paymentType);
            switch (paymentType)
            {
                case PaymentTypes.Cash:

                    var cashPaymentPage = pageFactory.CreatePage<BaseCashPaymentPage>();
                    cashPaymentPage.CompleteCashPayment();
                    break;

                case PaymentTypes.Card:
                    break;

                case PaymentTypes.Combine:

                    break;

                case PaymentTypes.NoRest:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null);
            }
        }
        public void RegCheck()
        {
            ClickElement(RegistrToDps);
        }

    }
}
