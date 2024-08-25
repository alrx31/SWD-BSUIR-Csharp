using System.Runtime.CompilerServices;

namespace LT9
{
    class Program
    {
        static int x=0;
        static object obj = new object();

        public static void Main(string[] args)
        {
            // создание и запуск потоков
            for (int i = 0; i <3; i++)
            {
                Thread myTh = new Thread(Count);
                myTh.Start();
            }
            Console.ReadLine();
        }

        public static void Count()
        {
            // блокировка ресурсов
            lock(obj){
                // код потока
                x = 1;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(x);
                    x++;
                    Thread.Sleep(100);

                }
            }

        }
    }
}