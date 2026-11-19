using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketMatekSzerver
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 3000;

            IPAddress ipaddress = IPAddress.Parse(ip);

            string ipcim = ConfigurationManager.AppSettings["IP-cim"];

            string portnum = ConfigurationManager.AppSettings["Port"];

            ipaddress = IPAddress.Parse(ipcim);

            TcpListener listener = new TcpListener(ipaddress, int.Parse(portnum));

            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Várakozás...");

                ClientComm clientcomm = new ClientComm(client);
                Thread t = new Thread(clientcomm.ClientStart);

                t.Start();
            }
        }
    }
}
