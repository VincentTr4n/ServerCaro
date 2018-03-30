
using System.Net.Sockets;

namespace ServerCaro
{
    public class Player
    {
        public string Name { get; set; }
        public Socket socket { get; set; }
        public int Source { get; set; }
        public Player other { get; set; }
    }
}
