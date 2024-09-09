using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Pages
{
    public abstract class BaseLoginPage<TDriver> : BasePage<TDriver> where TDriver : AppiumDriver
    {
        public BaseLoginPage(TDriver driver) : base(driver) { }

        protected abstract By FileButtonLocator { get; }
        protected abstract By CloudKeyButtonLocator { get; }
        protected abstract By FilePathLocator { get; }

        public void ClickFileButton()
        {
            ClickElement(FileButtonLocator);
        }

        public void ClickCloudKeyButton()
        {
            ClickElement(CloudKeyButtonLocator);
        }

        public string GetFilePathText()
        {
            return WaitForElement(FilePathLocator).Text;
        }

        public override bool IsPageLoaded()
        {
            return WaitForElement(FileButtonLocator).Displayed;
        }
    }
}
