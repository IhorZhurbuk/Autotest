using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autotest.Pages
{
    public abstract class BaseStoragePage : BasePage
    {
        public BaseStoragePage(AppiumDriver driver) : base(driver)
        {
        }
        protected abstract By DocumentsLocator { get; }
        protected abstract By KeysLocator { get; }
        protected abstract By ChooseFolderLocator { get; }
        protected abstract By AllowPermissionLocator { get; }
        protected abstract By DenyPermissionLocator { get; }
        protected abstract By CloudkeyLocator { get; }
        protected abstract By FilekeyLocator { get; }
        protected abstract By SecondkeyLocator { get; }

        public void ClickToCert(string name)
        {
            ClickElement(DocumentsLocator);
            ClickElement(KeysLocator);           
            if (name.Equals("FileKeyFirst"))
            {
                ClickElement(FilekeyLocator);
            } else if (name.Equals("FileKeySecond")){
                ClickElement(SecondkeyLocator);
            } else
            {
                ClickElement(CloudkeyLocator);  
            }
            ClickElement(ChooseFolderLocator);
            ClickElement(AllowPermissionLocator);
            Thread.Sleep(2000);
        }
    }
}
