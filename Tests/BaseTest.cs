using Autotest.Pages;
using Autotest.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Autotest.Tests
{
    public class BaseTest
    {
        AppiumLocalService appiumLocalService;
        PlatformCapabilities platformCapabilities = new PlatformCapabilities();
        AppiumOptions appiumOptions = new AppiumOptions();
        AppiumServiceBuilder appiumServiceBuilder = new AppiumServiceBuilder();

        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        private readonly string url = Startup.ReadFromAppSettings("AppUrl");
        private AppiumDriver driver;
        private Process appiumProcess;
        private enum PlatformType
        {
            Android,
            iOS,
        }

        private AppiumDriver InitializeDriver(PlatformType platformType)
        {
            Uri uri = new Uri(url);  

            switch (platformType)
            {
                case PlatformType.Android:
                    appiumOptions = platformCapabilities.InitNativeAndroidCapabilities();
                    driver = new AndroidDriver(uri, appiumOptions);
                    break;
                case PlatformType.iOS:
                    appiumOptions = platformCapabilities.InitNativeIOSCapabilities();
                    driver = new IOSDriver(uri, appiumOptions);
                    break;
                default:
                    throw new Exception("No platform selected!");
            }
            return driver;
        }

        private void StartAppiumServer()
        {
            string appiumJSPath = Environment.ExpandEnvironmentVariables(@"%SystemDrive%/Users/%USERNAME%/AppData/Roaming/npm/node_modules/appium/build/lib/main.js");
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\appiumrc.json");
            /* var GeneralOptionConfigFile = new KeyValuePair<string, string>("--config", configFilePath);
             var optionCollector = new OptionCollector();
             optionCollector.AddArguments(GeneralOptionConfigFile);
             appiumServiceBuilder
                 .WithArguments(optionCollector)
                 .WithAppiumJS(new FileInfo(appiumJSPath))
                 .UsingDriverExecutable(new FileInfo(@"C:\Program Files\nodejs\node.exe"));
             appiumLocalService = appiumServiceBuilder.Build();

             if (!appiumLocalService.IsRunning)
                 appiumLocalService.Start();*/
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "node",
                Arguments = $"\"{appiumJSPath}\" --config \"{configFilePath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };

            appiumProcess = new Process
            {
                StartInfo = processStartInfo
            };

            appiumProcess.Start();
            appiumProcess.WaitForExit();
        }

        private void CloseAppiumServer()
        {
            if (appiumProcess != null && !appiumProcess.HasExited)
            {
                try
                {
                    appiumProcess.Kill();
                    appiumProcess.WaitForExit();
                }
                catch (Exception ex)
                {
                    throw new Exception ("Error closing Appium server: " + ex.Message);
                }
            }

            /*if (appiumLocalService?.IsRunning == true)
                appiumLocalService.Dispose();*/
        }

        private void SetUpDriver()
        {
            if (Enum.TryParse(Startup.ReadFromAppSettings("PlatformType"), out PlatformType platformType))
            {
                driver = InitializeDriver(platformType);
            }
            else
            {
                throw new Exception("Invalid platform type in configuration");
            }
        }

        private void CloseDriver() => driver?.Quit();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            StartAppiumServer();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => CloseAppiumServer();

        [SetUp]
        public void SetUp()
        {
            SetUpDriver();
        }

        [TearDown]
        public void TearDown()
        {
            CloseDriver();
        }
    }
}
