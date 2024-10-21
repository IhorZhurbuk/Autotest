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
    public class AndroidDictionaryPage : BaseDictionaryPage
    {
        public AndroidDictionaryPage(AppiumDriver driver) : base(driver)
        {
        }
        protected override By SynchronizationButton => By.XPath("//androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.View");

        protected override By ModalText => By.XPath("//android.widget.TextView[@text=\"Синхронізація успішна\"]");
        protected override By OkBtn => By.XPath("//android.widget.Button[@text=\"ОК\"]");
    }
}
