using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Pages
{
    public class LoginAndroidPage : BaseLoginPage
    {
        public LoginAndroidPage(AppiumDriver driver) : base(driver)
        {
        }
        protected override By FileButtonLocator => By.XPath("//android.widget.TextView[@text=\"Файловий ключ\"]");
        protected override By CloudKeyButtonLocator => By.XPath("//android.widget.TextView[@text=\"CloudKey\"]");
        protected override By PumbButtonLocator => By.XPath("//android.widget.TextView[@text=\"ПУМБ SmartSign\"]");

        protected override By FilePathLocator => By.XPath("//android.widget.TextView[@text=\"Особистий ключ\"]");

        protected override By DocumentsLocator => By.XPath("//android.widget.TextView[@resource-id=\"android:id/title\" and @text=\"Documents\"]");

        protected override By KeysLocator => By.XPath("//androidx.cardview.widget.CardView[@resource-id=\"com.google.android.documentsui:id/item_root\"]/androidx.cardview.widget.CardView/android.widget.LinearLayout");

        protected override By ChooseFolderLocator => By.Id("android:id/button1");

        protected override By AllowPermissionLocator => By.XPath("//android.widget.Button[@resource-id=\"android:id/button1\"]");

        protected override By DenyPermissionLocator => By.XPath("//android.widget.Button[@resource-id=\"android:id/button2\"]");

        protected override By PasswordFeildLocator => By.XPath("//android.widget.EditText[@text=\"Введіть пароль\"]");

        protected override By EnterLocator => By.XPath("//android.widget.Button[@text=\"УВІЙТИ\"]");

        protected override By LogoLocaLocator => By.XPath("//androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.View");
    }
}

