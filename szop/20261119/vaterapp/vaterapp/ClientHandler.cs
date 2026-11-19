using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace vaterapp
{
   
    internal class ClientHandler
    {
        StreamWriter wr;
        StreamReader rd;

        public ClientHandler(TcpClient client)
        {
            wr = new StreamWriter(client.GetStream(), Encoding.UTF8);

            rd = new StreamReader(client.GetStream(), Encoding.UTF8);

            wr.WriteLine("Vaterapp szerver");

            wr.Flush();
        }

        public void ClientStart()
        {
            string response = "";

            while (response.ToUpper() == "BYE")
            {
                string cmd = rd.ReadLine();

                string[] results = cmd.Split('|');

                switch(results[0])
                {
                    case "BYE":
                        wr.WriteLine("Bye!");
                        break;

                    case "ADD":
                        break;

                    case "LIST":
                        break;

                    case "LOGIN":
                        break;

                    case "LICIT":
                        break;

                    default:
                        wr.WriteLine("Ismeretlen parancs!");
                        break;
                }
            }

            Console.WriteLine("Kapcsolat vége.");
        }
    }
}
