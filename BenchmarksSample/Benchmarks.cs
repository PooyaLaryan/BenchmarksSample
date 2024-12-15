using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class Benchmarks
{
    [Benchmark]
    public void Method1()
    {
        // Simulate some work
        for (int i = 0; i < 1000; i++) { var x = Math.Sqrt(i); }
    }

    [Benchmark]
    public void Method2()
    {
        // Simulate some other work
        for (int i = 0; i < 1000; i++) { var y = Math.Pow(i, 2); }
    }

    // Add more methods as needed
}