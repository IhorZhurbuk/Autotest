using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Utils
{
    public class TestResult
    {
        public string TestName { get; }

        public string Issue { get; }

        public Dictionary<string, ExecStatus> ItemsResults { get; }

        public ExecStatus TestCaseStatus { get; set; } = ExecStatus.Unexecuted;

        public TestResult(string testName, string issue, IEnumerable<string> itemsNames)
        {
            ItemsResults = new Dictionary<string, ExecStatus>();
            TestName = testName;
            Issue = issue;
            foreach (string name in itemsNames)
            {
                ItemsResults.Add(name, ExecStatus.Unexecuted);
            }
        }

        public void SetItemStatus(string name, ExecStatus stutus)
        {
            ItemsResults[name] = stutus;
        }

        public string GetXmlLog()
        {
            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            builder.AppendLine($"<testitems testcase=\"{Issue}\" testname=\"{TestName}\">");
            foreach (var itemResult in ItemsResults)
            {
                builder.AppendLine($"   <item name=\"{itemResult.Key}\" value=\"{itemResult.Value}\" />");
            }
            builder.AppendLine("</testitems>");
            return builder.ToString();
        }
    }

    public enum ExecStatus
    {
        Pass = 1,
        Fail = 2,
        InProccess = 3,
        Block = 4,
        Unexecuted = 5,
        Terminated = 6
    }
}
