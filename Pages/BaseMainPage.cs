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
        protected abstract By GoToRro { get; }
        
        public void ClickAllRooButton()
        {
            ClickElement(AllRooButton);
        }
        public void ClickHistoryButton()
        {
            ClickElement(HistoryButton);
        }
        public abstract BaseDictionaryPage ClickDictionaryButton();

        public void ClickMenuButton()
        {
            ClickElement(MenuButton);
        }
        public void ClickGoToRro()
        {
            ClickElement(GoToRro);
        }
    }
}
