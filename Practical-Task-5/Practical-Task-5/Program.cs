using System;
using System.Threading;

class Program
{
    static int[] array = new int[10];

    static void Main()
    {
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 26);
        }

        Thread t0 = new Thread(PrintSquares);
        Thread t1 = new Thread(PrintNumbersLessThan50);

        t0.Start();
        t1.Start();

        t0.Join();
        t1.Join();
    }

    static void PrintSquares()
    {
        Console.WriteLine("T0: Виведення квадратів всіх елементів масиву:");
        foreach (var number in array)
        {
            int square = number * number;
            Console.WriteLine($"T0: Квадрат {number} = {square}");
        }
    }

    static void PrintNumbersLessThan50()
    {
        Console.WriteLine("T1: Виведення чисел, які менші за 50:");
        foreach (var number in array)
        {
            if (number < 50)
            {
                Console.WriteLine($"T1: {number}");
            }
        }
    }
}
 