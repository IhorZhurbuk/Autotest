using Autotest.Drivers;
using Autotest.IOSPages;
using Autotest.Pages;
using Autotest.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Autotest.Tests
{
    public abstract class BaseTest
    {
        private Process appiumProcess;

        private AppiumDriver driver;
        private TestResult testResult;
        protected abstract string TestName { get; }
        protected Logger testLogger;
        protected Dictionary<string, Func<ExecStatus>> TestItems { get; } = new Dictionary<string, Func<ExecStatus>>();
        protected abstract string TestIssue { get; }
        protected  PageFactory pageFactory;

        private AppiumDriver InitializeDriver(MobilePlatform platform)
        {
            LocalMobileDriverFactory localMobileDriver = new LocalMobileDriverFactory(platform);
            driver = localMobileDriver.GetDriver();
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("Config\\key.json") 
                .Build();
            pageFactory = new PageFactory(driver, configuration, platform);
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

        private void CloseDriver()
        {
            driver?.Quit();
        }
        [SetUp]
        public void SetUp()
        {
            testLogger = Startup.GetLogger(this.GetType().Name);
            SetUpDriver();
            testLogger.LogInfo("Запуск програми");
            TestItems.Add("Запуск програми", () => RunApp());
            testResult = new TestResult(TestName, TestIssue, TestItems.Keys);
        }
        protected ExecStatus ExecuteStep(string stepName, Func<ExecStatus> stepAction)
        {
            try
            {
                testLogger.LogInfo($"Виконання кроку: {stepName}");
                return stepAction();
            }
            catch (Exception ex)
            {
                testLogger.LogError($"Помилка під час виконання кроку '{stepName}': {ex.Message}");
                LogFileWriter.CreateLogFile(testLogger);
                LogFileWriter.CreateLogFile(testResult);
                Assert.Fail($"Тест завершено. Крок '{stepName}' провалився.");
                return ExecStatus.Fail;
            }
        }
        private ExecStatus RunApp()
        {
            try
            {
                testLogger.LogInfo("Запуск програми успішний.");
                return ExecStatus.Pass;
            }
            catch (Exception ex)
            {
                testLogger.LogError($"Помилка під час запуску програми: {ex.Message}");
                LogFileWriter.CreateLogFile(testLogger);
                LogFileWriter.CreateLogFile(testResult);
                Assert.Fail($"Помилка під час запуску програми: {ex.Message}");
                return ExecStatus.Fail;
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                foreach (var item in TestItems)
                {
                    var result = ExecuteStep(item.Key, item.Value);
                    testResult.SetItemStatus(item.Key, result);
                }
                LogFileWriter.CreateLogFile(testLogger);
                LogFileWriter.CreateLogFile(testResult);
            }
            finally
            {
                CloseDriver();
            }
        }
    }
}

