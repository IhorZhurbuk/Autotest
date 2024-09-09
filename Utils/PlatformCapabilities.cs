using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace Autotest.Utils

{
    public class PlatformCapabilities
    {
        AppiumOptions appiumOptions = new AppiumOptions();

        public AppiumOptions InitNativeAndroidCapabilities()
        {
            lock (appiumOptions)
            {
                appiumOptions.PlatformName = Startup.ReadFromAppSettings("PlatformName");
                appiumOptions.AutomationName = Startup.ReadFromAppSettings("AutomationName");
                appiumOptions.DeviceName = Startup.ReadFromAppSettings("DeviceName");
                appiumOptions.PlatformVersion = Startup.ReadFromAppSettings("OSVersion");
                appiumOptions.App = Startup.ReadFromAppSettings("App");
            }
            return appiumOptions;
        }

        public AppiumOptions InitNativeIOSCapabilities()
        {
            lock (appiumOptions)
            {
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, Startup.ReadFromAppSettings("PlatformName"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.AutomationName, Startup.ReadFromAppSettings("AutomationName"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformVersion, Startup.ReadFromAppSettings("PlatformVersion"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.DeviceName, Startup.ReadFromAppSettings("DeviceName"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.App, Startup.ReadFromAppSettings("App"));
            }
            return appiumOptions;
        }
    }
}

