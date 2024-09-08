using System.Collections.Concurrent;
using System.Diagnostics;

namespace LT10;
public class Program
{
    public static void FindPrimes(int n,CancellationToken cancellationToken)
    {
        var primes = new bool[n + 1];
        for (int i = 0; i <= n; i++) primes[i] = true;
        primes[0] = primes[1] = false;
        for (int p = 2; p * p <= n; p++)
        {
            if (cancellationToken.IsCancellationRequested) return;
            if (primes[p])
            {
                for (int i = p * p; i <= n; i += p)
                    primes[i] = false;
            }
        }

        for (int i = 2; i <= n; i++)
        {
            if (cancellationToken.IsCancellationRequested) return;
            if (primes[i]) Console.WriteLine(i);
        }
    }

    public static async Task Main()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        var task = Task.Run(() => FindPrimes(1000000, token));
        cts.Cancel();

        Console.WriteLine($"Task ID: {task.Id}");
        Console.WriteLine($"Task Status: {task.Status}");
        var stopwatch = Stopwatch.StartNew();


        try
        {
            task.Wait();
        }
        catch (AggregateException ex)
        {
            ex.Handle(e => e is TaskCanceledException);
            Console.WriteLine("Task canceled");
        }

        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");




        var task1 = Task.Run(() => 5);
        var task2 = Task.Run(() => 10);
        var task3 = Task.Run(() => 15);

        var task4 = Task.WhenAll(task1, task2, task3).ContinueWith(t =>
        {
            int sum = t.Result.Sum();
            Console.WriteLine($"Sum: {sum}");
        });

        task4.Wait();



        var task5 = Task.Run(() => 42);
        var awaiter = task5.GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            var result = awaiter.GetResult();
            Console.WriteLine($"Result: {result}");
        });

        task5.Wait();


        var arr1 = new List<int>(10000000);
        var arr2 = new List<int>(10000000);

        var task6 = Task.Run(() =>
        {
            for (int i = 0; i < 10000000; i++)
            {
                arr1.Add(i);
                arr2.Add(i);
            }
        });

        task6.Wait();

        var stopwatch1 = Stopwatch.StartNew();
        Parallel.For(0, 10000000, i =>
        {
            arr1[i] = arr1[i] * 2731;
        });
        
        stopwatch1.Stop();

        Console.WriteLine($"Parallel Execution Time: {stopwatch1.ElapsedMilliseconds} ms");

        var stopwatch2 = Stopwatch.StartNew();

        for (int i = 0; i < 10000000; i++)
        {
            arr2[i] = arr2[i] * 2731;
        }

        stopwatch2.Stop();

        Console.WriteLine($"Sequential Execution Time: {stopwatch2.ElapsedMilliseconds} ms");


        Parallel.Invoke(
            () => Console.WriteLine("Task 1"),
            () => Console.WriteLine("Task 2"),
            () => Console.WriteLine("Task 3")
        );


        int result = await CalculateAsync();
        Console.WriteLine($"Result: {result}");


        var stock = new BlockingCollection<string>();

        Task.Run(() =>
        {
            while (true)
            {
                if (stock.TryTake(out var item)) Console.WriteLine($"Customer bought: {item}");
            }
        });

        var suppliers = new Task[5];
        for (int i = 0; i < 5; i++)
        {
            suppliers[i] = Task.Run(() =>
            {
                while (true)
                {
                    var item = $"Item {Guid.NewGuid()}";
                    stock.Add(item);
                    Console.WriteLine($"Supplier added: {item}");
                    Thread.Sleep(300*i); 
                }
            });
        }

        Task.WaitAll(suppliers);



       

    }

    public static async Task<int> CalculateAsync()
    {
        await Task.Delay(1000);
        return 42;
    }

}