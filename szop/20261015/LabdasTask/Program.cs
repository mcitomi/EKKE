namespace Labdas
{
    internal class Program
    {

        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Balls b1 = new Balls(10, 10, +1, -1);
            Balls b2 = new Balls(20, 20, -1, -1);
            Balls b3 = new Balls(30, 30, +1, +1);
            // Balls b4 = new Balls(40, 40, -1, +1);

            Task t1 = Task.Run(() => b1.Move(cts.Token));
            Task t2 = Task.Run(() => b2.Move(cts.Token));
            Task t3 = Task.Run(() => b3.Move(cts.Token));

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Most vége");

            Console.ReadKey();

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

        public void Move(CancellationToken ctoken)
        {

            while (true)
            {
                if (ctoken.IsCancellationRequested)
                {
                    break;
                }

                lock (typeof(Program))
                {
                    Console.SetCursorPosition(CurrentPosX, CurrentPosY);
                    Console.Write(' ');
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

                lock (typeof(Program))
                {
                    Console.SetCursorPosition(CurrentPosX, CurrentPosY);
                    Console.WriteLine("0");
                }

                Thread.Sleep(30);
            }
        }
    }
}
