

namespace Cen_Con.INF
{
    public interface IConsoleDebug
    {
        public void SendMessage(string msg);
        public void SendWarning (string msg);

        public void SendError (string msg);
    }
}
