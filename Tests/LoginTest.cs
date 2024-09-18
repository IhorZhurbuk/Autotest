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
        public void Login()
        {           
            loginPage.ClickPumbButton();
            loginPage.ClickCloudKeyButton();
            loginPage.ClickFileButton();                   
            loginPage.ClickFilePathKeyButton().ClickToCert("FileKeyFirst");          
            loginPage.ClickPasswordFeildButton();
            loginPage.ClickEnterButton();
        }
    
    }
}

