using Autotest.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace Autotest.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private BaseLoginPage<AppiumDriver> loginPage;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
        }

        [Test]
        public void Test_ClickFileButton()
        {
            loginPage.ClickFileButton();
            Assert.Pass("File button clicked successfully.");
        }

        [Test]
        public void Test_ClickCloudKeyButton()
        {
            loginPage.ClickCloudKeyButton();
            Assert.Pass("Cloud key button clicked successfully.");
        }

        [Test]
        public void Test_GetFilePathText()
        {
            string filePathText = loginPage.GetFilePathText();
        }
    }
}

