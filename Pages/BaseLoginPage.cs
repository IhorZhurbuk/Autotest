using Autotest.AndroidPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autotest.Pages
{
    public abstract class BaseLoginPage:BasePage
    {
        protected BaseLoginPage(AppiumDriver driver) : base(driver)
        {
        }

        protected abstract By FileButtonLocator { get; }
        protected abstract By CloudKeyButtonLocator { get; }
        protected abstract By PumbButtonLocator { get; }
        protected abstract By FilePathLocator { get; }     

        protected abstract By PasswordFeildLocator { get; }
        protected abstract By EnterLocator { get; }
        protected abstract By LogoLocaLocator { get; }

        public void ClickFileButton()
        {
            ClickElement(FileButtonLocator);
        }
        public void ClickCloudKeyButton()
        {
            ClickElement(CloudKeyButtonLocator);
        }

        public void ClickPumbButton()
        {
            ClickElement(PumbButtonLocator);
        }
        public abstract BaseStoragePage ClickFilePathKeyButton();


        public void ClickPasswordFeildButton()
        {
            EnterText(PasswordFeildLocator, "777");
        }
        public void ClickEnterButton()
        {
            ClickElement(EnterLocator);
            WaitForElement(LogoLocaLocator);
        }
    }
}
