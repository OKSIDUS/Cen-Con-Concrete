using Serilog;
using Serilog.Core;

namespace Cen_Con.INF
{
    public class ConsoleDebug : IConsoleDebug
    {
        private readonly Logger _log;

        public ConsoleDebug()
        {
            _log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public void SendError(string msg)
        {
            _log.Error(msg);
        }

        public void SendMessage(string msg)
        {
            _log.Information(msg);
        }

        public void SendWarning(string msg)
        {
            _log.Warning(msg);
        }
    }
}
