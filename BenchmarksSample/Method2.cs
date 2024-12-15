using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarksSample
{
    public class Method2
    {
        public void Method2Run()
        {
            Benchmarks benchmarks = new Benchmarks();

            Action method1 = benchmarks.Method1;
            Action method2 = benchmarks.Method2;

            // Warm-up
            method1();
            method2();

            // Benchmark the methods
            var result1 = Benchmark(method1, "Method 1");
            var result2 = Benchmark(method2, "Method 2");

            // Display results in a table
            var table = new ConsoleTable("Method", "Elapsed Time (ms)");
            table.AddRow(result1.Name, result1.ElapsedMilliseconds)
                 .AddRow(result2.Name, result2.ElapsedMilliseconds);
            table.Write();

            Console.WriteLine("Benchmark completed.");
        }

        static private (string Name, long ElapsedMilliseconds) Benchmark(Action method, string name)
        {
            const int iterations = 1000;
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                method();
            }

            stopwatch.Stop();
            return (name, stopwatch.ElapsedMilliseconds);
        }
    }
}
