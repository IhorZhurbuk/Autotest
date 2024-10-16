using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Pages
{
    public abstract class BaseMainPage : BasePage
    {
        protected BaseMainPage(AppiumDriver driver) : base(driver)
        {
        }
        protected abstract By AllRooButton { get; }
        protected abstract By HistoryButton { get; }
        protected abstract By DictionaryButton { get; }
        protected abstract By MenuButton { get; }
    }
}
