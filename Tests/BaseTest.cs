using Autotest.Drivers;
using Autotest.IOSPages;
using Autotest.Pages;
using Autotest.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Autotest.Tests
{
    public class BaseTest
    {

        private Process appiumProcess;

        private AppiumDriver driver;
        public BaseLoginPage loginPage;

        private AppiumDriver InitializeDriver(MobilePlatform platform)
        {
            LocalMobileDriverFactory localMobileDriver = new LocalMobileDriverFactory(platform);
            driver = localMobileDriver.GetDriver();

            // Ініціалізуємо сторінку в залежності від платформи
            if (platform == MobilePlatform.Android)
            {
                loginPage = new AndroidLoginPage(driver);
            }
            else if (platform == MobilePlatform.IOS)
            {
                loginPage = new IOSLoginPage(driver);
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
                    throw new Exception("Error closing Appium server: " + ex.Message);
                }
            }

            /*if (appiumLocalService?.IsRunning == true)
                appiumLocalService.Dispose();*/
        }

        private void SetUpDriver()
        {
            if (Enum.TryParse(Startup.ReadFromAppSettings("PlatformType"), out MobilePlatform platform))
            {
                driver = InitializeDriver(platform);
            }
            else
            {
                throw new Exception("Не вказоно платформу виконання");
            }
        }

        private void CloseDriver() => driver?.Quit();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // StartAppiumServer();
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
