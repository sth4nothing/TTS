using System.Text;

namespace Sth4nothing.TTS
{
    internal class StateObject
    {
        public System.Net.Sockets.Socket workSocket = null;
        public const int BUFFER_SIZE = 1024;
        public byte[] buffer = new byte[BUFFER_SIZE];
        public StringBuilder sb = new StringBuilder();
    }
}
