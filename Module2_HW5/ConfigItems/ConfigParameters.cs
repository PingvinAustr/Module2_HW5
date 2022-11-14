using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW5
{
    public class ConfigParameters
    {
        public ConfigParameters(string logFolderName)
        {
            LogFolderName = logFolderName;
        }

        public string LogFolderName { get; set; }
    }
}
