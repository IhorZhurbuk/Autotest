using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Pages
{
    public abstract class BaseRroShift:BasePage
    {
        protected BaseRroShift(AppiumDriver driver) : base(driver)
        {
        }
        protected abstract By Sale { get; }
        protected abstract By InternetSale { get; }  
        protected abstract By Prepayment { get; }
        protected abstract By Postpaid { get; }
        protected abstract By PostpaidFull { get; }
            

    }
}
