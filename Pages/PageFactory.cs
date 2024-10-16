using Autotest.Drivers;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using System;

namespace Autotest.Pages
{
    public class PageFactory
    {
        private readonly AppiumDriver driver;
        private readonly IConfiguration configuration;
        private readonly MobilePlatform platform;
        public PageFactory(AppiumDriver driver, IConfiguration configuration, MobilePlatform platform)
        {
            this.driver = driver;
            this.configuration = configuration;
            this.platform = platform;
        }

        public T CreatePage<T>() where T : BasePage
        {
            var pageType = typeof(T);
            string platformSuffix = platform == MobilePlatform.Android ? "Android" : "IOS";
            string namespacePrefix = platform == MobilePlatform.Android ? "Autotest.AndroidPages" : "Autotest.IOSPages";
            string className = pageType.Name.Replace("Base", "");
            string fullName = $"{namespacePrefix}.{platformSuffix}{className}";

            Type type = Type.GetType(fullName);
            if (type == null)
            {
                throw new Exception($"Не вдалося знайти тип для сторінки: {fullName}");
            }

            return (T)Activator.CreateInstance(type, driver, configuration);
        }
    }
}
