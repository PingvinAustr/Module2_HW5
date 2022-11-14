using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5
{
    internal static class Starter
    {
        internal static void Run()
        {
            if (!ConfigController.ValidateConfig())
            {
                Environment.Exit(0);
            }

            Console.WriteLine("[Log DateTime] [Log type] [Log message]");
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int randomNum = random.Next(1, 4);
                bool answerFromAction;
                switch (randomNum)
                {
                    case 1:
                        {
                            // Action 1
                            answerFromAction = Actions.StartMethod();
                            break;
                        }

                    case 2:
                        {
                            // Action 2
                            try
                            {
                                Actions.SkipMethod();
                            }
                            catch (Exceptions.BusinessException ex)
                            {
                                LogEntry log = new LogEntry(
                                    false,
                                    "Action got this custom Exception :" + ex.Message,
                                    LogEntry.LogTypeEnum.Warning,
                                    DateTime.Now);

                                Logger.GetInstance().SaveNewLogEntry(log);
                            }

                            break;
                        }

                    case 3:
                        {
                              // Action 3
                            try
                            {
                                 Actions.BrakeMethod();
                            }
                            catch (Exception ex)
                            {
                                LogEntry log = new LogEntry(
                                    false,
                                    "Action failed by reason:" + ex,
                                    LogEntry.LogTypeEnum.Error,
                                    DateTime.Now);
                                Logger.GetInstance().SaveNewLogEntry(log);
                            }

                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }

            // Print logs from memory and to file
            LogWriter.PrintMemoryLogs(Logger.GetInstance().ReturnMemoryLogs());
            Console.WriteLine("\n\n\n");
        }
    }
}
