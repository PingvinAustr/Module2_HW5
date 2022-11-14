using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5
{
    internal class LogEntry
    {
        // LogEntry class contains Status(bool) and an error message

        // Default constuctor
        internal LogEntry()
        {
            Status = null;
            ErrorMessage = string.Empty;
        }

        // Constructor with parameters
        internal LogEntry(bool status, string message, LogTypeEnum logType, DateTime dateTime)
        {
            Status = status;
            ErrorMessage = message;
            LogType = logType;
            LogTime = dateTime;
        }

        // Log type
        internal enum LogTypeEnum
        {
            Info,
            Warning,
            Error
        }

        // Log fields
        internal bool? Status { get; set; }
        internal string ErrorMessage { get; set; }
        internal LogTypeEnum LogType { get; set; }
        internal DateTime LogTime { get; set; }
    }
}
