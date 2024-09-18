using Autotest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.IOSPages
{
    public class IOSStoragePage : BaseStoragePage
    {
        public IOSStoragePage(AppiumDriver driver) : base(driver)
        {
        }

        protected override By DocumentsLocator => throw new NotImplementedException();

        protected override By KeysLocator => throw new NotImplementedException();

        protected override By ChooseFolderLocator => throw new NotImplementedException();

        protected override By AllowPermissionLocator => throw new NotImplementedException();

        protected override By DenyPermissionLocator => throw new NotImplementedException();

        protected override By CloudkeyLocator => throw new NotImplementedException();

        protected override By FilekeyLocator => throw new NotImplementedException();

        protected override By SecondkeyLocator => throw new NotImplementedException();
    }
}
