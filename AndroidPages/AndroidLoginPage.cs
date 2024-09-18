using Autotest.AndroidPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Pages
{
    public class AndroidLoginPage : BaseLoginPage
    {
        public AndroidLoginPage(AppiumDriver driver) : base(driver)
        {
        }
        protected override By FileButtonLocator => By.XPath("//android.widget.TextView[@text=\"Файловий ключ\"]");
        protected override By CloudKeyButtonLocator => By.XPath("//android.widget.TextView[@text=\"CloudKey\"]");
        protected override By PumbButtonLocator => By.XPath("//android.widget.TextView[@text=\"ПУМБ SmartSign\"]");

        protected override By FilePathLocator => By.XPath("//android.widget.TextView[@text=\"Особистий ключ\"]");

        protected override By PasswordFeildLocator => By.XPath("//android.widget.EditText[@text=\"Введіть пароль\"]");

        protected override By EnterLocator => By.XPath("//android.widget.Button[@text=\"УВІЙТИ\"]");

        protected override By LogoLocaLocator => By.XPath("//androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.View");

        public override BaseStoragePage ClickFilePathKeyButton()
        {
            ClickElement(FilePathLocator);
            return new AndroidStoragePage(driver);
        }
    }
}

