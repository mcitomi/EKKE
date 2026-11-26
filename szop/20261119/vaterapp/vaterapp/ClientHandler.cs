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

        (string, string) user = ("", "");

        public ClientHandler(TcpClient client)
        {
            wr = new StreamWriter(client.GetStream(), Encoding.UTF8);

            rd = new StreamReader(client.GetStream(), Encoding.UTF8);

            wr.WriteLine("Üdv a VaterApp szerverén!");

            wr.Flush();
        }

        public void ClientStart()
        {
            string clientResponse = "";

            while (clientResponse.ToUpper() != "BYE")
            {
                try
                {
                    clientResponse = rd.ReadLine();

                    string[] results = clientResponse.Split('|');

                   

                    switch (results[0])
                    {
                        case "BYE":
                            wr.WriteLine("Bye");
                            break;

                        case "ADD":
                            break;

                        case "LIST":
                            break;

                        case "WHOAMI":
                            wr.WriteLine(user.Item1);
                            break;

                        case "LOGIN":


                            user = (results[1], results[2]);

                            wr.WriteLine("Sikeres bejelentkezés!");
                            
                            break;

                        case "LICIT":
                            break;

                        default:
                            wr.WriteLine("Ismeretlen parancs!");
                            break;
                    }

                    wr.Flush();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine("Egy kliens kilépett");
                    break;
                }
                catch (Exception e)
                {
                    wr.WriteLine($"ERR|{e.Message}");
                    wr.Flush();
                }
               
            }



            Console.WriteLine("Kapcsolat vége.");
        }
    }
}
