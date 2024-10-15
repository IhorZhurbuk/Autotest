using Autotest.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;


namespace Autotest.Pages
{
    public abstract class BaseAllRroPage : BasePage
    {
        protected BaseAllRroPage(AppiumDriver driver) : base(driver)
        {
           
        }
        protected abstract By PrroN1 { get; }
        protected abstract By PrroN2 { get; }

        protected abstract By PrroN3 { get; }
        protected abstract By OpenRro { get; }
        protected abstract By UpdateDfs { get;}
        protected abstract By ChangeGo { get;}
        protected abstract By TexSupport { get;}
        public void IsShiftOpened(string rroName)
        {
            
        }
    }
}
