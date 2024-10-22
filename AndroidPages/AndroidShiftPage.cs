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
    public class AndroidShiftPage : BaseShiftPage
    {
        public AndroidShiftPage(AppiumDriver driver) : base(driver)
        {
        }
        protected override By ChoosePayment => By.XPath("//androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup");

        public override BasePaymentPage MethodofPayment()
        {
            ClickElement(ChoosePayment);
            return new AndroidPaymentPages(driver);
        }
    }
}
