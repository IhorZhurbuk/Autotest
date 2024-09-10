using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autotest.Pages
{
    public abstract class BaseLoginPage:BasePage
    {
        protected BaseLoginPage(AppiumDriver driver) : base(driver)
        {
        }

        protected abstract By FileButtonLocator { get; }
        protected abstract By CloudKeyButtonLocator { get; }
        protected abstract By PumbButtonLocator { get; }
        protected abstract By FilePathLocator { get; }
        protected abstract By DocumentsLocator { get; }
        protected abstract By KeysLocator { get; }
        protected abstract By ChooseFolderLocator { get; }
        protected abstract By AllowPermissionLocator { get; }
        protected abstract By DenyPermissionLocator { get; }

        protected abstract By PasswordFeildLocator { get; }
        protected abstract By EnterLocator { get; }

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
        public void ClickFilePathKeyButton()
        {
            ClickElement(FilePathLocator);
        }
        public void ClickDocumentButton()
        {
            ClickElement(DocumentsLocator);
        }
        public void ClickKeysButton()
        {
            ClickElement(KeysLocator);
        }
        public void ClickFolderButton()
        {
            ClickElement(ChooseFolderLocator);
        }
        public void ClickAllowPermissionButton()
        {
            ClickElement(AllowPermissionLocator);
            Thread.Sleep(2000);
        }
        public void ClickPasswordFeildButton()
        {
            EnterText(PasswordFeildLocator, "777");
        }
        public void ClickEnterButton()
        {
            ClickElement(EnterLocator);
            Thread.Sleep(10000);
        }
    }
}
