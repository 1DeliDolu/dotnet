using System;
using System.Linq;

namespace LinqPartitioningExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0'dan 7'ye kadar sayı dizisi oluştur
            var numbers = Enumerable.Range(0, 8);

            Console.WriteLine("=== TAKE ===");
            var takeResult = numbers.Take(3);
            foreach (var n in takeResult)
                Console.WriteLine(n);

            Console.WriteLine("\n=== SKIP ===");
            var skipResult = numbers.Skip(3);
            foreach (var n in skipResult)
                Console.WriteLine(n);

            Console.WriteLine("\n=== TAKEWHILE ===");
            var takeWhileResult = numbers.TakeWhile(n => n < 5);
            foreach (var n in takeWhileResult)
                Console.WriteLine(n);

            Console.WriteLine("\n=== SKIPWHILE ===");
            var skipWhileResult = numbers.SkipWhile(n => n < 5);
            foreach (var n in skipWhileResult)
                Console.WriteLine(n);

            Console.WriteLine("\n=== CHUNK ===");
            int chunkNumber = 1;
            foreach (var chunk in numbers.Chunk(3))
            {
                Console.WriteLine($"Chunk {chunkNumber++}:");
                foreach (var item in chunk)
                    Console.WriteLine($"    {item}");
                Console.WriteLine();
            }

            Console.WriteLine("=== TAMAMLANDI ===");
        }
    }
}
