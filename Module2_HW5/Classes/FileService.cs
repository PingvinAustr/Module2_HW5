using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5
{
    internal static class FileService
    {
        internal static FileInfo CurrentFile { get; set; }

        internal static void CheckLogFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"..\\..\\..\\" + ConfigController.CurrentConfigs.LogFolderName);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            else if ((dirInfo.GetFiles().Count() > 3) && (CurrentFile == null))
            {
                FileInfo[] files = dirInfo.GetFiles();
                DateTime oldestTime = DateTime.MaxValue;
                int oldestTimeIndex = -1;
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].CreationTime < oldestTime)
                    {
                        oldestTime = files[i].CreationTime;
                        oldestTimeIndex = i;
                    }
                }

                files[oldestTimeIndex].Delete();
            }

            if (CurrentFile == null)
            {
                CreateCurrentLogFile(dirInfo.FullName);
            }
        }

        // Print current log to log file
        internal static void PrintSingleLogToCurrentFile(LogEntry logEntry)
        {
            CheckLogFiles();
            File.AppendAllText(CurrentFile.FullName, "[" + logEntry.LogTime + "] [" + logEntry.LogType + "] [" + logEntry.ErrorMessage + "]\n");
        }

        private static void CreateCurrentLogFile(string parentPath)
        {
            string fileName = DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + ".txt";
            FileInfo fileInf = new FileInfo(parentPath + "\\" + fileName);

            // Actually create the file.
            FileStream fs = fileInf.Create();
            fs.Close();
            CurrentFile = fileInf;
        }
    }
}
