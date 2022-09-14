using System;
using System.IO;
using System.Reflection;
using log4net.Appender;

namespace StepChange.Blogger.Web
{
    public class RelFileAppender : RollingFileAppender
    {
        public override string File
        {
            set
            {
                // Linux support
                string path = Path.Combine(value.Split("\\"));

                string baseDirectory = Environment.UserInteractive ?
                    Directory.GetCurrentDirectory() :
                    GetExecutableDirectory();
                base.File = Path.Combine(baseDirectory, path);
            }
        }

        static string GetExecutableDirectory()
        {
            string codebase = Assembly.GetExecutingAssembly().CodeBase;
            var uriBuilder = new UriBuilder(codebase!);
            string path = Uri.UnescapeDataString(uriBuilder.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
