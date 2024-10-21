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
    public class IOSDictionaryPage : BaseDictionaryPage
    {
        public IOSDictionaryPage(AppiumDriver driver) : base(driver)
        {
        }
        protected override By SynchronizationButton => throw new NotImplementedException();

        protected override By ModalText => throw new NotImplementedException();

        protected override By OkBtn => throw new NotImplementedException();
    }
}
