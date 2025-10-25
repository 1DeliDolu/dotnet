using System;

namespace D4_SartlarVeDongulerNamespace;

public static class SartlarVeDongulerTopic
{
    public static void Run()
    {
        ShowBasicIf();
        ShowIfElse();
        ShowCompoundConditions();
        ShowWhileLoop();
        ShowDoWhileLoop();
        ShowForLoop();
        ShowNestedLoops();
        ShowSumDivisibleByThree();
    }

    private static void ShowBasicIf()
    {
        int a = 5;
        int b = 6;

        Console.WriteLine("Basit if örneği:");
        if (a + b > 10)
        {
            Console.WriteLine($"{a} + {b} > 10");
        }
        Console.WriteLine();
    }

    private static void ShowIfElse()
    {
        int a = 5;
        int b = 3;

        Console.WriteLine("if/else kullanımı:");
        if (a + b > 10)
        {
            Console.WriteLine("Sonuç 10'dan büyük");
        }
        else
        {
            Console.WriteLine("Sonuç 10'dan büyük değil");
        }
        Console.WriteLine();
    }

    private static void ShowCompoundConditions()
    {
        int a = 5;
        int b = 3;
        int c = 4;

        Console.WriteLine("Birden fazla koşul:");
        if ((a + b + c > 10) && (a == b))
        {
            Console.WriteLine("Toplam 10'dan büyük ve a == b");
        }
        else
        {
            Console.WriteLine("Koşullardan en az biri sağlanmadı");
        }

        if ((a + b + c > 10) || (a == b))
        {
            Console.WriteLine("En az bir koşul sağlandı");
        }
        Console.WriteLine();
    }

    private static void ShowWhileLoop()
    {
        Console.WriteLine("while döngüsü:");
        int counter = 0;
        while (counter < 3)
        {
            Console.WriteLine($"Sayaç: {counter}");
            counter++;
        }
        Console.WriteLine();
    }

    private static void ShowDoWhileLoop()
    {
        Console.WriteLine("do/while döngüsü:");
        int counter = 0;
        do
        {
            Console.WriteLine($"Sayaç: {counter}");
            counter++;
        }
        while (counter < 3);
        Console.WriteLine();
    }

    private static void ShowForLoop()
    {
        Console.WriteLine("for döngüsü:");
        for (int counter = 0; counter < 3; counter++)
        {
            Console.WriteLine($"Sayaç: {counter}");
        }

        Console.WriteLine("Ters for döngüsü:");
        for (int counter = 5; counter >= 0; counter -= 2)
        {
            Console.WriteLine($"Sayaç: {counter}");
        }
        Console.WriteLine();
    }

    private static void ShowNestedLoops()
    {
        Console.WriteLine("İç içe döngüler:");
        for (int row = 1; row <= 3; row++)
        {
            for (char column = 'a'; column <= 'c'; column++)
            {
                Console.Write($"({row}, {column}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static void ShowSumDivisibleByThree()
    {
        Console.WriteLine("1-20 arasında 3'e bölünebilen sayıların toplamı:");
        int sum = 0;
        for (int number = 1; number <= 20; number++)
        {
            if (number % 3 == 0)
            {
                sum += number;
            }
        }
        Console.WriteLine($"Toplam: {sum}");
        Console.WriteLine();
    }
}
