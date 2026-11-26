using System.Net.Sockets;
using System.Text;

namespace vaterappclient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 3000);

            StreamWriter wr = new StreamWriter(client.GetStream(), Encoding.UTF8);
            StreamReader rd = new StreamReader(client.GetStream(), Encoding.UTF8);

            string serverResponse = rd.ReadLine();
            Console.WriteLine(serverResponse);

            string consoleInput = "";

            while (consoleInput.ToUpper() != "BYE") 
            {
                Console.Write("> ");
                consoleInput = Console.ReadLine();

                wr.WriteLine(consoleInput);
                wr.Flush();

                serverResponse = rd.ReadLine();
                Console.WriteLine(serverResponse);

                

            }

            rd.Close();
            wr.Close();

            Console.ReadKey();


        }
    }
}
