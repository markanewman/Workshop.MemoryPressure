using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Workshop.MemoryPressure.Tools
{
    public static class SimpleTextLog
    {
        public static void WriteData(string path, string data)
        {
            var site = Environment.GetEnvironmentVariable("APPSETTING_WEBSITE_SITE_NAME");
            var instance = Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");
            var now = DateTime.Now.ToString("yyyyMMddhhmmss");

            site = site == null ? "localhost" : site;
            instance = instance == null ? "000000" : instance.Substring(0,6);
            
            var line = string.Join(" ", site,instance, now, data);

            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (var writer = new StreamWriter(path, true)) 
                writer.WriteLine(line);
        }
    }
}