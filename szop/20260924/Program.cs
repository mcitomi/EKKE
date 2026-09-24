namespace Labdas
{
    internal class Program
    {
        static public ManualResetEvent stop = new ManualResetEvent(true);
        static public ManualResetEvent exital = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Balls b1 = new Balls(10, 10, +1, -1);
            Balls b2 = new Balls(20, 20, -1, -1);
            Balls b3 = new Balls(30, 30, +1, +1);
            Balls b4 = new Balls(40, 40, -1, +1);
            Thread t1 = new Thread(b1.Move);
            Thread t2 = new Thread(b2.Move);
            Thread t3 = new Thread(b3.Move);
            Thread t4 = new Thread(b4.Move);
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            Console.WriteLine("Megállítom");
            Console.ReadKey(); stop.Reset();
            Console.WriteLine("Újra");
            Console.ReadKey(); stop.Set();
            Console.WriteLine("Kilépés?");
            var consoleKey = Console.ReadKey();
            while(consoleKey.Key != ConsoleKey.Enter)
            {
                consoleKey = Console.ReadKey();
            }
            exital.Set();
        }
    }

    class Balls
    {
        public int CurrentPosX;
        public int CurrentPosY;
        public int DirectionX;
        public int DirectionY;

        public Balls(int cx, int cy, int dx, int dy)
        {
            this.CurrentPosX = cx;
            this.CurrentPosY = cy;
            this.DirectionX = dx;
            this.DirectionY = dy;
        }

        public void Move()
        {

            while (true)
            {
                Program.stop.WaitOne();
                if(Program.exital.WaitOne(0))
                {
                    break;
                }

                lock(typeof(Program))
                {
                    Console.SetCursorPosition(CurrentPosX, CurrentPosY);
                    Console.WriteLine(" ");
                }

                
                if (CurrentPosX > 0 || CurrentPosX < 80)
                    this.CurrentPosX += this.DirectionX;
                if (CurrentPosY > 0 || CurrentPosY < 25)
                    this.CurrentPosY += this.DirectionY;
                if (CurrentPosX == 0 || CurrentPosX == 80)
                {
                    this.DirectionX *= -1;
                    this.CurrentPosX += this.DirectionX;
                }
                if (CurrentPosY == 0 || CurrentPosY == 25)
                {
                    this.DirectionY *= -1;
                    this.CurrentPosY += this.DirectionY;
                }

                lock(typeof(Program))
                {
                    Console.SetCursorPosition(CurrentPosX, CurrentPosY);
                    Console.WriteLine("0");
                }
                
                Thread.Sleep(30);
            }
        }
    }
}
