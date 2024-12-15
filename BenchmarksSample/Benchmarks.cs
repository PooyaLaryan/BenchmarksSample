using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class Benchmarks
{
    [WarmupCount(3)]
    [IterationCount(3)]
    [Benchmark]
    public void Method1()
    {
        // Simulate some work
        for (int i = 0; i < 1000; i++) { var x = Math.Sqrt(i); }
    }

    [WarmupCount(5)]
    [IterationCount(7)]
    [Benchmark]
    public void Method2()
    {
        // Simulate some other work
        for (int i = 0; i < 1000; i++) { var y = Math.Pow(i, 2); }
    }

    [MinIterationCount(5)]
    [MaxIterationCount(15)]
    [Benchmark]
    public void Method3() 
    { 
    }

    // Add more methods as needed
}