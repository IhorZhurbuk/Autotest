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
    public class LoginAndroidPage : BaseLoginPage<AndroidDriver>
    {
        public LoginAndroidPage(AndroidDriver driver) : base(driver) { }
  
        protected override By FileButtonLocator => By.XPath("//android.widget.Button[@text=\"ФАЙЛОВИЙ КЛЮЧ\"]");
        protected override By CloudKeyButtonLocator => By.XPath("//android.widget.Button[@text=\"CLOUDKEY\"]");
        protected override By FilePathLocator => By.XPath("//android.widget.TextView[@text=\"Особистий ключ\"]");
    }
}

