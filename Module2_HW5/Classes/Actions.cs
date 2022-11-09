using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5
{
    internal static class Actions
    {
        internal static bool StartMethod()
        {
            LogEntry startResult = new LogEntry(true, "Start method: StartMethod()", LogEntry.LogTypeEnum.Info, DateTime.Now);
            Logger.GetInstance().SaveNewLogEntry(startResult);
            return true;
        }

        internal static void SkipMethod()
        {
            throw new Exceptions.BusinessException("Skipped logic in method");
        }

        internal static void BrakeMethod()
        {
            throw new Exception("I broke logic");
        }
    }
}
