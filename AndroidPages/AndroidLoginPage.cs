using Autotest.Pages;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.AndroidPages
{
    public class AndroidLoginPage : BaseLoginPage
    {
        public AndroidLoginPage(AppiumDriver driver, IConfiguration configuration) : base(driver, configuration)
        {
        }
        protected override By FileButtonLocator => By.XPath("//android.widget.TextView[@text=\"Файловий ключ\"]");
        protected override By CloudKeyButtonLocator => By.XPath("//android.widget.TextView[@text=\"CloudKey\"]");
        protected override By PumbButtonLocator => By.XPath("//android.widget.TextView[@text=\"ПУМБ SmartSign\"]");

        protected override By FilePathLocator => By.XPath("//android.widget.TextView[@text=\"Особистий ключ\"]");

        protected override By PasswordFeildLocator => By.ClassName("android.widget.EditText");

        protected override By EnterLocator => By.XPath("//android.widget.Button[@text=\"УВІЙТИ\"]");

        protected override By LogoLocaLocator => By.XPath("//androidx.viewpager.widget.ViewPager/androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/androidx.recyclerview.widget.RecyclerView/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup");

        protected override By IncoorectPass => By.XPath("//android.widget.TextView[@text=\"Некоректний пароль приватного ключа.\"]");

        protected override By OkBtn => By.XPath("//android.widget.Button[@text=\"ОК\"]");

        public override BaseStoragePage ClickFilePathKeyButton()
        {
            ClickElement(FilePathLocator);
            return new AndroidStoragePage(driver);
        }
    }
}

