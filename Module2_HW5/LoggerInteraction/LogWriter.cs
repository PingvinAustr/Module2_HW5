using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5
{
    internal static class LogWriter
    {
        // Print current memory logs
        internal static void PrintMemoryLogs(LogEntry[] logList)
        {
            if (logList.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No logs in memory...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (LogEntry logEntry in logList)
                {
                    if (logEntry.LogType == LogEntry.LogTypeEnum.Info)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (logEntry.LogType == LogEntry.LogTypeEnum.Warning)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (logEntry.LogType == LogEntry.LogTypeEnum.Error)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine("[" + logEntry.LogTime + "] [" + logEntry.LogType + "] [" + logEntry.ErrorMessage + "]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
