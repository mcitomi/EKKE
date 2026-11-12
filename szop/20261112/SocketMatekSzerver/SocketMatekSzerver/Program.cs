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

            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("Várakozás...");

            StreamWriter wr = new StreamWriter(client.GetStream(), Encoding.UTF8);

            StreamReader rd = new StreamReader(client.GetStream(), Encoding.UTF8);

            wr.WriteLine("Matek szerver 1.0");

            wr.Flush();

            //wr.AutoFlush = true;

            string resp = "";

            while (resp.ToLower() != "bye")
            {
                string cmd = rd.ReadLine();
                string[] result = cmd.Split('|');

                switch (result[0])
                {
                    case "BYE":
                        wr.WriteLine("Bye");
                        break;

                    case "ADD":
                        wr.WriteLine(int.Parse(result[1]) + int.Parse(result[2]));
                        break;

                    default:
                        wr.WriteLine("Ismeretlen parancs");
                        break;
                }

                wr.Flush();
            }


            Console.WriteLine("Vége");


        }
    }
}
