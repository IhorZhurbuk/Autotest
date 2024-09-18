using Autotest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Autotest.IOSPages
{
    public class IOSLoginPage : BaseLoginPage
    {
        public IOSLoginPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By FileButtonLocator => throw new System.NotImplementedException();

        protected override By CloudKeyButtonLocator => throw new System.NotImplementedException();

        protected override By PumbButtonLocator => throw new System.NotImplementedException();

        protected override By FilePathLocator => throw new System.NotImplementedException();

        protected override By PasswordFeildLocator => throw new System.NotImplementedException();

        protected override By EnterLocator => throw new System.NotImplementedException();

        protected override By LogoLocaLocator => throw new System.NotImplementedException();

        public override BaseStoragePage ClickFilePathKeyButton()
        {
            throw new System.NotImplementedException();
        }
    }
}
