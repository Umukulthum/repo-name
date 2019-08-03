using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gleek.Web
{
    public class AppSettings
    {
        public LoggingSetting Logging { get; set; }
    }
    public class LoggingSetting
    {
        public LogLevelSetting LogLevel { get; set; }
    }
    public class LogLevelSetting
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
