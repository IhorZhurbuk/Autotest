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
    public class IOSMainPage : BaseMainPage
    {
        public IOSMainPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By AllRooButton => throw new NotImplementedException();

        protected override By HistoryButton => throw new NotImplementedException();

        protected override By DictionaryButton => throw new NotImplementedException();

        protected override By MenuButton => throw new NotImplementedException();

        protected override BaseDictionaryPage BaseDictionaryPage(AppiumDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
