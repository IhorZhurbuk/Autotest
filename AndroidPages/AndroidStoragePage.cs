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
    public class AndroidStoragePage : BaseStoragePage
    {
        public AndroidStoragePage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By DocumentsLocator => By.XPath("//android.widget.TextView[@resource-id=\"android:id/title\" and @text=\"Download\"]");

        protected override By KeysLocator => By.XPath("//androidx.cardview.widget.CardView[@resource-id=\"com.google.android.documentsui:id/item_root\"]/androidx.cardview.widget.CardView/android.widget.LinearLayout");

        protected override By ChooseFolderLocator => By.Id("android:id/button1");

        protected override By AllowPermissionLocator => By.XPath("//android.widget.Button[@resource-id=\"android:id/button1\"]");

        protected override By DenyPermissionLocator => By.XPath("//android.widget.Button[@resource-id=\"android:id/button2\"]");

        protected override By CloudkeyLocator => By.XPath("//android.widget.TextView[@resource-id=\"android:id/title\" and @text=\"CloudKey\"]");

        protected override By FilekeyLocator => By.XPath("//android.widget.TextView[@resource-id=\"android:id/title\" and @text=\"FileKeyFirst\"]");

        protected override By SecondkeyLocator => By.XPath("//android.widget.TextView[@resource-id=\"android:id/title\" and @text=\"FileKeySecond\"]");
    }
}
