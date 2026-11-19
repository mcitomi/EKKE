using System.Net.Sockets;
using System.Text;

namespace SocketMatekClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            TcpClient client = new TcpClient("127.0.0.1", 5555);

            StreamWriter wr = new StreamWriter(client.GetStream(), Encoding.UTF8);  // output - küldő
            StreamReader rd = new StreamReader(client.GetStream(), Encoding.UTF8);  // input - beérkező

            string message = rd.ReadLine();
            Console.WriteLine(message);

            string valasz = "";

            while (valasz.ToLower() != "bye")
            {
                Console.WriteLine("Mit kérjek a szervertől?");
                string cmd = Console.ReadLine();

                wr.WriteLine(cmd);

                wr.Flush();

                Console.WriteLine("A szerver válasza:");

                valasz = rd.ReadLine();

                if(valasz == "OK*")
                {
                    while (valasz != "OK!")
                    {
                        Console.WriteLine(valasz);
                        valasz = rd.ReadLine();
                    }
                }
               

                Console.WriteLine(valasz);
            }

            rd.Close();
            wr.Close();

            Console.ReadKey();


        }
    }
}
