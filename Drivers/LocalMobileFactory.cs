using OpenQA.Selenium.Appium;
using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using Autotest.Utils;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using Autotest.Pages;

namespace Autotest.Drivers
{
    public class LocalMobileDriverFactory : MobileDriverFactory
    {
        private readonly MobilePlatform _platform;
        PlatformCapabilities platformCapabilities = new PlatformCapabilities();
        AppiumOptions appiumOptions = new AppiumOptions();
        private readonly string url = Startup.ReadFromAppSettings("AppUrl");

        public LocalMobileDriverFactory(MobilePlatform platform)
        {
            _platform = platform;
        }

        public override AppiumDriver GetDriver()
        {
            return driverInstance = CreateDriver(_platform);
        }

        public override AppiumDriver GetDriverIfExist()
        {
            return driverInstance;
        }

        private AppiumDriver CreateDriver(MobilePlatform platform)
        {
            AppiumDriver driver;

            Uri uri = new Uri(url);

            switch (platform)
            {
                case MobilePlatform.Android:
                    appiumOptions = platformCapabilities.InitNativeAndroidCapabilities();
                    driver = new AndroidDriver(uri, appiumOptions);
                   
                    break;
                case MobilePlatform.IOS:
                    appiumOptions = platformCapabilities.InitNativeIOSCapabilities();
                    driver = new IOSDriver(uri, appiumOptions);

                    break;

                default:
                    throw new NotSupportedException($"Платформа {platform} поки не реалізована для мобільного запуску");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }
    }
}
