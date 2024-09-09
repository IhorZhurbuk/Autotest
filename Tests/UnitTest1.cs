using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
public class UnitTest1
{
    private AndroidDriver _driver;

    [OneTimeSetUp]
    public void SetUp()
    {
        var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:8888/");
        var driverOptions = new AppiumOptions()
        {
            AutomationName = AutomationName.AndroidUIAutomator2,
            PlatformName = "Android",
            DeviceName = "22f000d7",
            App = "C:\\Users\\Ihor\\Downloads\\551.apk",
            PlatformVersion = "13",
            //UseStrictFileInteractability = true,
            
        };

        /*driverOptions.AddAdditionalAppiumOption("appPackage", "com.medoc.cashalot");
        driverOptions.AddAdditionalAppiumOption("appActivity", "com.medoc.cashalot.MainActivity");*//*
        driverOptions.AddAdditionalAppiumOption("capabilityName", "C:\\Users\\Ihor\\Downloads\\com.medoc.cashalot.testpath.apk");
        driverOptions.AddAdditionalAppiumOption("noReset", true);
*/
        _driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        /*string localFilePath = "C:\\Users\\Ihor\\source\\repos\\Autotest\\ТП4 2023-2025";
        byte[] fileData = File.ReadAllBytes(localFilePath);
        string base64File = Convert.ToBase64String(fileData);
        string deviceFilePath = "/Documents/ТП4 2023-2025";
        _driver.PushFile(deviceFilePath, base64File);*/
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        try
        {
            if (_driver != null)
            {
                _driver.Dispose();
                Console.WriteLine("Драйвер успешно завершил работу.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при завершении работы драйвера: {ex.Message}");
        }
    }
    [Test]
    public void Test()
    {
       // _driver.StartActivity("com.medoc.cashalot", "crc644bf7db1f14d245f5.MainActivity");
        var fileButton = _driver.FindElement(By.XPath("//android.widget.Button[@text=\"ФАЙЛОВИЙ КЛЮЧ\"]"));
        var cloudKeyButton = _driver.FindElement(By.XPath("//android.widget.Button[@text=\"CLOUDKEY\"]"));
        var filePath = _driver.FindElement(By.XPath("//android.widget.TextView[@text=\"Особистий ключ\"]"));


        TimeSpan timeSpan = TimeSpan.FromSeconds(5);


        fileButton.Click();
        cloudKeyButton.Click();
        filePath.Click();     

    }
}