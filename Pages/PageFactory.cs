using Autotest.Drivers;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using System;
using System.Reflection;

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

            ConstructorInfo constructorWithConfig = type.GetConstructor(new Type[] { typeof(AppiumDriver), typeof(IConfiguration) });
            ConstructorInfo constructorWithoutConfig = type.GetConstructor(new Type[] { typeof(AppiumDriver) });

            if (constructorWithConfig != null)
            {
                // Якщо є конструктор з драйвером і конфігурацією, створюємо сторінку з обома параметрами
                return (T)Activator.CreateInstance(type, driver, configuration);
            }
            else if (constructorWithoutConfig != null)
            {
                // Якщо є тільки конструктор з драйвером, створюємо сторінку лише з драйвером
                return (T)Activator.CreateInstance(type, driver);
            }
            else
            {
                throw new Exception($"Не вдалося знайти відповідний конструктор для сторінки: {fullName}");
            }
        }
    }
}
