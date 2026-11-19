using System.Net.Sockets;

namespace vaterappclient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 5555);


        }
    }
}
