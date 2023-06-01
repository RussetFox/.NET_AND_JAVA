using System;
using System.Threading;
namespace Filozofowie
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Thread[] threads = new Thread[n];
            Filozof[] filozofowie = new Filozof[n];
            Mutex[] forks = new Mutex[n];
            for (int i = 0; i < n; i++)
            {
                forks[i] = new Mutex();
                filozofowie[i] = new Filozof(forks, n, i);
                threads[i] = new Thread(filozofowie[i].ExistenceIsPain);
                threads[i].Start();
            }
            /*for (int i = 0; i < n; i++)
            {
                threads[i].Start();
            }*/
            for (int i = 0 ; i < n ; i++)
            {
                threads[i].Join();
            }
        }
        public class Filozof
        {
            public bool full = false;
            public int id;
            public int totalNumber;
            private Mutex[] mutexArray; 
            public Filozof(Mutex[] mutArr, int totalNumber, int id)
            {
                mutexArray = mutArr;
                this.totalNumber = totalNumber;
                this.id = id;
            }
            public void SufferLiving()
            {
                Thread.Sleep(500);
            }
            public void ExistenceIsPain()
            {
                SufferLiving();

                while (!full)
                {
                    bool leftForkAcquired = false;
                    bool rightForkAcquired = false;

                    try
                    {
                        mutexArray[this.id].WaitOne();
                        leftForkAcquired = true;

                        mutexArray[(this.id + 1) % totalNumber].WaitOne();
                        rightForkAcquired = true;

                        Console.WriteLine("Zyjemy by jesc: " + this.id);
                        full = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {

                        if (rightForkAcquired)
                        {
                            mutexArray[(this.id + 1) % totalNumber].ReleaseMutex();
                        }
                        if (leftForkAcquired)
                        {
                            mutexArray[this.id].ReleaseMutex();
                        }
                    }
                    if (full)
                    {
                        SufferLiving();
                        full = false;
                    }
                }
            }

        }

    }
}