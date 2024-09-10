using Autotest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Autotest.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        [Test]     
        public void Test_ClickFileButton()
        {
            loginPage.ClickPumbButton();
            loginPage.ClickCloudKeyButton();
            loginPage.ClickFileButton();                   
            loginPage.ClickFilePathKeyButton();
            loginPage.ClickDocumentButton();
            loginPage.ClickKeysButton();
            loginPage.ClickFolderButton();
            loginPage.ClickAllowPermissionButton();
            loginPage.ClickPasswordFeildButton();
            loginPage.ClickEnterButton();
        }
    
    }
}

