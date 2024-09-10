using Autotest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace Autotest.IOSPages
{
    public class LoginIOSPage : BaseLoginPage
    {
        public LoginIOSPage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By FileButtonLocator => throw new System.NotImplementedException();

        protected override By CloudKeyButtonLocator => throw new System.NotImplementedException();

        protected override By PumbButtonLocator => throw new System.NotImplementedException();

        protected override By FilePathLocator => throw new System.NotImplementedException();

        protected override By DocumentsLocator => throw new System.NotImplementedException();

        protected override By KeysLocator => throw new System.NotImplementedException();

        protected override By ChooseFolderLocator => throw new System.NotImplementedException();

        protected override By AllowPermissionLocator => throw new System.NotImplementedException();

        protected override By DenyPermissionLocator => throw new System.NotImplementedException();

        protected override By PasswordFeildLocator => throw new System.NotImplementedException();

        protected override By EnterLocator => throw new System.NotImplementedException();
    }
}
