using Autotest.Pages;
using Autotest.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            TestItems.Add("Чек продажу оплата карткою", CheckNoRest);
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
            loginPage.Authorize("4000029022");
            return ExecStatus.Pass;
        }
        private ExecStatus CheckCash()
        {
            ExecStatus result = ExecStatus.InProccess;
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
