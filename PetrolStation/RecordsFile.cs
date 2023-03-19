using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public static class RecordsFile
    {
        public static string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string fileName = (ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["filename"].Value ?? "records") + ".txt";
        public static string filePath = exePath + @"\" + fileName;

    }
}
