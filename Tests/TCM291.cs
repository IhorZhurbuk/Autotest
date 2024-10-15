using Autotest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Autotest.Tests
{
    [TestFixture]
    public class TCM291 : BaseTest
    {
        protected override string TestName => "(Автотест) Mobile Cashalot Перевірка відкриття модулів програми";
        protected override string TestIssue => "TCM-291";

        [Test]
        public  void FillTestItems()
        {
            TestItems.Add("Вікно авторизації. Перевірка функціональних кнопок", Functional);
            TestItems.Add("Вікно авторизації. Ввести не вірний пароль", InvalidPassword);
            TestItems.Add("Вікно авторизації. Ввести вірний пароль", CorrectPass);

        }

        private ExecStatus Functional()
        {
            ExecStatus result = ExecStatus.InProccess;
            loginPage.ClickPumbButton();
            loginPage.ClickCloudKeyButton();
            loginPage.ClickFileButton();
            loginPage.ClickFilePathKeyButton().ClickToCert("FileKeyFirst");
            return ExecStatus.Pass;
        }
        private ExecStatus InvalidPassword()
        {
            ExecStatus result = ExecStatus.InProccess;
            loginPage.ClickPasswordFeildButton("123");
            loginPage.ClickEnterButton(false);
            if (!loginPage.IfModalBoxExists("Некоректний пароль приватного ключа."))
            {
                testLogger.LogError("Не з'явилось модальне вікно");
                return ExecStatus.Fail;
            }
            return ExecStatus.Pass;
        }
        private ExecStatus CorrectPass()
        {
            ExecStatus result = ExecStatus.InProccess;
            loginPage.ClickPasswordFeildButton("777");
            loginPage.ClickEnterButton(true);
            
            return ExecStatus.Pass;
        }
    }
}

