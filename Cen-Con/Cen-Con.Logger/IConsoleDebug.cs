

namespace Cen_Con.Logger
{
    public interface IConsoleDebug
    {
        public void SendMessage(string msg);
        public void SendWarning (string msg);

        public void SendError (string msg);
    }
}
