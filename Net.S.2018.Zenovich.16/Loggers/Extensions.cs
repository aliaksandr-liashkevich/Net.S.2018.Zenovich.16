using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Net.S._2018.Zenovich._16.Loggers
{
    public static class Extensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }

        public static ILogger GetLogger()
        {
            var loggerFactory = new LoggerFactory();

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logInfo.txt"));
            return loggerFactory.CreateLogger("FileLogger");
        }
    }
}
