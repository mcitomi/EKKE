using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SocketMatekSzerver
{
    
    internal class ClientComm
    {
        StreamWriter wr;
        StreamReader rd;
        public ClientComm(TcpClient client) {
            wr = new StreamWriter(client.GetStream(), Encoding.UTF8);

            rd = new StreamReader(client.GetStream(), Encoding.UTF8);

            wr.WriteLine("Matek szerver 1.0");

            wr.Flush();
            //wr.AutoFlush = true;
        }

        public void ClientStart()
        {
            string resp = "";

            while (resp.ToLower() != "bye")
            {
                try
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

                        case "FIBO":
                            Fibo(int.Parse(result[1]));
                            break;

                        default:
                            wr.WriteLine("Ismeretlen parancs");
                            break;
                    }

                    wr.Flush();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine("Egy kliens kilépett");
                }
                catch (Exception e) {
                    wr.WriteLine("ERR|hiba");
                }

            }



            Console.WriteLine("Vége");
        }

        void Fibo(int number)
        {
            int db = 2;

            wr.WriteLine("OK*");
            wr.WriteLine(1);

            int f1 = 1;
            int f2 = 1;
            int f3 = 0;

            while (db <= number)
            {
                f3 = f2 + f1;
                wr.WriteLine(f3);
                f1 = f2;
                f2 = f3;
                db++;
            }

            wr.WriteLine("OK!");


        }
    }
}
