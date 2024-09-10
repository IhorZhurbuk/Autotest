using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Autotest.Drivers
{
    public abstract class MobileDriverFactory
    {
        protected AppiumDriver driverInstance = null;

        public abstract AppiumDriver GetDriver();

        public abstract AppiumDriver GetDriverIfExist();
    }
}
