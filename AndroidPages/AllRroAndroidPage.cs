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
    public class AllRroAndroidPage : BaseAllRroPage
    {
        public AllRroAndroidPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By PrroN1 => By.XPath("//android.widget.TextView[@text=\"ПРРО 1\"]");

        protected override By PrroN2 => By.XPath("//android.widget.TextView[@text=\"ПРРО 2\"]");

        protected override By PrroN3 => By.XPath("//android.widget.TextView[@text=\"ПРРО 3\"]");

        protected override By OpenRro => By.XPath("//android.widget.Button[@text=\"ВІДКРИТИ ЗМІНУ\"]");

        protected override By UpdateDfs => By.XPath("//android.widget.Button");

        protected override By ChangeGo => By.XPath("//androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup/android.view.View");

        protected override By TexSupport => throw new NotImplementedException();
    }
}
