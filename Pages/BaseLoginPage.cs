using Autotest.Utils;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Autotest.Pages
{
    public abstract class BaseLoginPage : BasePage
    {
        private readonly IConfiguration _configuration;
        protected BaseLoginPage(AppiumDriver driver, IConfiguration configuration) : base(driver)
        {
            _configuration = configuration;
        }

        protected abstract By FileButtonLocator { get; }
        protected abstract By CloudKeyButtonLocator { get; }
        protected abstract By PumbButtonLocator { get; }
        protected abstract By FilePathLocator { get; }

        protected abstract By PasswordFeildLocator { get; }
        protected abstract By EnterLocator { get; }
        protected abstract By IncoorectPass { get; }
        protected abstract By OkBtn { get; }
        protected abstract By LogoLocaLocator { get; }

        public void ClickFileButton()
        {
            ClickElement(FileButtonLocator);
        }
        public void ClickCloudKeyButton()
        {
            ClickElement(CloudKeyButtonLocator);
        }

        public void ClickPumbButton()
        {
            ClickElement(PumbButtonLocator);
        }
        public abstract BaseStoragePage ClickFilePathKeyButton();


        public void ClickPasswordFeildButton(string keys)
        {
            EnterText(PasswordFeildLocator, keys);
        }
        public bool ClickEnterButton(bool value)
        {
            ClickElement(EnterLocator);
            if (!value)
            {
                bool modalExists = Helpers.CheckAndCloseModal(driver, IncoorectPass, "Некоректний пароль приватного ключа.", OkBtn);
                return modalExists;
            }
            else
            {
                WaitForElement(LogoLocaLocator);
            }

            return false;
        }
        public void Authorize(string certName)
        {
            // Знаходимо сертифікат за іменем ключа
            var cert = _configuration.GetSection("Certificates")
                .Get<List<Certificate>>()
                .FirstOrDefault(c => c.Name == certName);

            if (cert == null)
            {
                throw new Exception($"Сертифікат з ім'ям {certName} не знайдено у конфігурації.");
            }

            ClickFileButton();
            ClickFilePathKeyButton().ClickToCert(cert.Name);
            ClickPasswordFeildButton(cert.Password);
            ClickEnterButton(true);
            var rroElements = driver.FindElements(By.XPath($"//android.widget.TextView[contains(@text, 'ФН')]"));
            var openShiftButtons = driver.FindElements(By.XPath("//android.widget.Button[@text='Відкрити зміну']"));

            if (rroElements.Count == 0 || openShiftButtons.Count == 0)
            {
                throw new Exception($"Не вдалося знайти елементи з ФН або кнопки 'Відкрити зміну'.");
            }
            for (int i = 0; i < rroElements.Count; i++)
            {
                var rroText = rroElements[i].Text;

                if (rroText.Contains(cert.Rro))
                {
                    openShiftButtons[i].Click();
                    WaitForElement(By.XPath("//android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.View"));
                    return;
                }
            }
            throw new Exception($"Не вдалося знайти відповідну кнопку 'Відкрити зміну' для сертифіката з ФН {cert.Rro}.");
        }
    }
}
public class Certificate
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Rro { get; set; }
}
