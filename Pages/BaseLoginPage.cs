using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

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
            if (!value)
            {
                ClickElement(EnterLocator);
                Thread.Sleep(5000);
                return true;
            }
            else
            {
                ClickElement(EnterLocator);
                WaitForElement(LogoLocaLocator);

            }
            return false;
        }
        public bool IfModalBoxExists(string text)
        {
            if (driver.FindElement(IncoorectPass).Text.Equals(text))
            {
                ClickElement(OkBtn);
                return true;
            }
            return false;
        }
        public void Authorize(string rro)
        {
            var cert = _configuration.GetSection("Certificates")
                .Get<List<Certificate>>()
                .FirstOrDefault(c => c.Rro == rro);

            if (cert == null)
            {
                throw new Exception($"Сертифікат для RRO {rro} не знайдено у конфігурації.");
            }

            ClickFileButton(); 
            ClickFilePathKeyButton().ClickToCert(cert.Name); 
            ClickPasswordFeildButton(cert.Password); 
            ClickEnterButton(true); 
        }
    }
}
public class Certificate
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Rro { get; set; }
}
