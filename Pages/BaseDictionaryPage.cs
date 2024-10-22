using Autotest.Utils;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Autotest.Pages
{
    public abstract class BaseDictionaryPage : BasePage
    {
        protected BaseDictionaryPage(AppiumDriver driver) : base(driver)
        {
        }
        protected abstract By SynchronizationButton {  get; }
        protected abstract By ModalText {  get; } 
        protected abstract By OkBtn {  get; } 

        public bool ClickSynchronization()
        {
            ClickElement(SynchronizationButton);
            WaitForElement(ModalText);
            bool modalExists = Helpers.CheckAndCloseModal(driver, ModalText, "Синхронізація успішна", OkBtn);
            return modalExists;
        }
    }
}
