//3)
// Készítsen kliens +szerver alkalmazást az alábbi problémára: a közösség egy vatera szerûen mûködõ elad-vesz szervert üzemeltet. Minden tárgynak van - kod (string) - neve (string) - ára (egész szám) - felrakójának login neve (string) - vásárló login neve (string, csak ha már megvásárolta valaki)

//A szerver felé fel lehet ajánlani (ADD) eladásra tárgyat, amit a login-el rendelkezõ személyek licitálhatnak (LICIT). A megvehetõ tárgyak listáját (LIST) viszont login nélkül is meg lehet nézni. Ennek megfelelõen az alábbi protokollt kell alkalmazni:

//    LIST: eredménye a megvehetõ tárgyak listája (login nélkül is mûködik), az alábbi sorokból áll: < nev >|< kod >|< ar >|< user > ahol a user az utoljára licitáló user neve (ha van már ilyen). A list parancs erdeménye több soros válasz.
//    (OK* szöveggel kezdjük a kommunikációt, OK!szöveggel zárjuk.)
//    LOGIN|<user>|<jelszo>: a program elfogad bármilyen usert és jelszót, mindenesetre loginolni kötelezõ. Eredménye vagy OK vagy ERR|<hibaüzenet>.
//    ADD|<kod>|<megnevezes><ar>: új termék felrakása.A kód egyedi kell legyen. Csak login után adható ki.
//    LICIT|<kod>|<ar>: csak login után adható ki, az árnak magasabbnak kell lennie az aktuális árnál.
//    BYE: ezzel jelzi a kliens hogy le kiván csatakozni. a szerver is egy BYE választ küld.

//A szerver egy idõben több klienssel is tartsa a kapcsolatot. A klienseknek a logint csak egyszer kell beküldeni (logout parancs nincs). 

using System.Net;
using System.Net.Sockets;

namespace vaterapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 3000;

            IPAddress ipaddress = IPAddress.Parse(ip);
            TcpListener listener = new TcpListener(ipaddress, port);

            listener.Start();

            Console.WriteLine("A szerver elindult!");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Új kliens csatlakozott");

                ClientHandler clienthander = new ClientHandler(client);

                Thread t = new Thread(clienthander.ClientStart);

                t.Start();
            }
        }
    }
}
