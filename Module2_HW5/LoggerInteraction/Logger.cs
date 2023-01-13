using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5
{
    internal class Logger
    {
        private static Logger instance;
        private LogEntry[] _logList = new LogEntry[0];
        private Logger()
        {
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }

            return instance;
        }

        // Logging method
        internal void SaveNewLogEntry(LogEntry logEntry)
        {
            FileService.PrintSingleLogToCurrentFile(logEntry);
            LogEntry[] logEntries = new LogEntry[1] { logEntry };
            _logList = _logList.Concat(logEntries).ToArray();
        }

        // Method that returns current logs
        internal LogEntry[] ReturnMemoryLogs()
        {
            return _logList;
        }
    }
}
