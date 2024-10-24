using Autotest.Enums;
using Autotest.Pages;
using Autotest.Utils;
using NUnit.Framework;

namespace Autotest.Tests
{
    [TestFixture]
    public class TCM292 : BaseTest
    {
        protected override string TestName => "";
        protected override string TestIssue => "TCM-292";

        [Test]
        public void FillTestItems()
        {
            TestItems.Add("Відкрити зміну", OpenShift);
            TestItems.Add("Чек продажу оплата готівкою", CheckCash);
            TestItems.Add("Чек продажу оплата карткою", CheckCard);
            TestItems.Add("Чек продажу оплата комбінована", CheckCombine);
            TestItems.Add("Чек продажу оплата без решти", CheckNoRest);
            TestItems.Add("Чек передплати оплата готівкою", CheckBefore);
            TestItems.Add("Чек післяплати оплата готівкою", CheckAfter);
            TestItems.Add("Чек оплата частинами", CheckParts);
            TestItems.Add("Чек інтернет-продажу оплата готівкою", CheckInterner);
            TestItems.Add("Чек післяплатаповна", CheckPostPayFull);

        }
        private ExecStatus OpenShift()
        {
            ExecStatus result = ExecStatus.InProccess;
            var loginPage = pageFactory.CreatePage<BaseLoginPage>();
            loginPage.Authorize("FileKeySecond");
            var mainPage = pageFactory.CreatePage<BaseMainPage>();
            if (!mainPage.ClickDictionaryButton().ClickSynchronization())
            {
                testLogger.LogError("Не з'явилось модальне вікно");
                return ExecStatus.Fail;
            }
            mainPage.ClickGoToRro();
            return ExecStatus.Pass;
        }
        private ExecStatus CheckCash()
        {
            ExecStatus result = ExecStatus.InProccess;
            var rroPage = pageFactory.CreatePage<BaseShiftPage>();
            rroPage.MethodofPayment().СhooseMethodofPayment(PaymentMethod.Sale);
            var payment = pageFactory.CreatePage<BasePaymentPage>();
            payment.AddGoods(Goods.AutoTestItem1);
            payment.CreatePayment(PaymentTypes.Cash);
            var cashpayment = pageFactory.CreatePage<BaseCashPaymentPage>();
            cashpayment.CompleteCashPayment();
            payment.RegCheck();
            return ExecStatus.Pass; 
        }
        private ExecStatus CheckCard()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
        private ExecStatus CheckCombine()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
        private ExecStatus CheckNoRest()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
        private ExecStatus CheckBefore()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
        private ExecStatus CheckAfter()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
        private ExecStatus CheckParts()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
        private ExecStatus CheckInterner()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
        private ExecStatus CheckPostPayFull()
        {
            ExecStatus result = ExecStatus.InProccess;
            return ExecStatus.Pass;
        }
    }
}
