using System;
using System.Threading;

class Program
{
    static long sum1 = 0;
    static long sum2 = 0;
    static long sum3 = 0;

    static void Main()
    {
        Thread t1 = new Thread(() => SumRange(1, 100, ref sum1));
        Thread t2 = new Thread(() => SumRange(101, 200, ref sum2));
        Thread t3 = new Thread(() => SumRange(201, 300, ref sum3));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        long total = sum1 + sum2 + sum3;

        Console.WriteLine($"Сумма 1–100: {sum1}");
        Console.WriteLine($"Сумма 101–200: {sum2}");
        Console.WriteLine($"Сумма 201–300: {sum3}");
        Console.WriteLine($"Общая сумма: {total}");
    }

    static void SumRange(int start, int end, ref long result)
    {
        long sum = 0;

        for (int i = start; i <= end; i++)
        {
            sum += i;
        }

        result = sum;
    }
}