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
    public class AndroidMainPage : BaseMainPage
    {
        public AndroidMainPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By AllRooButton => By.XPath("//android.widget.TextView[@text=\"Всі каси\"]");

        protected override By HistoryButton => By.XPath("//android.widget.TextView[@text=\"Історія\"]");

        protected override By DictionaryButton => By.XPath("//android.widget.TextView[@text=\"Довідники\"]");

        protected override By MenuButton => By.XPath("//android.widget.TextView[@text=\"Меню\"]");
    }
}
