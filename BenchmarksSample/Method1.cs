using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarksSample
{
    public class Method1
    {
        public void Method1Run()
        {
            var config = DefaultConfig.Instance
                                        .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                                        .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest));

            // Run benchmarks
            var summary = BenchmarkRunner.Run<Benchmarks>(config);

            // Initialize table with headers
            var table = new ConsoleTable("Method", "Mean (ms)", "Error (%)", "StdDev");

            // Populate table with benchmark results
            foreach (var report in summary.Reports)
            {
                // Get the benchmark method name
                var methodName = report.BenchmarkCase.Descriptor.WorkloadMethod.Name;

                // Retrieve statistics and format the data
                var mean = report.ResultStatistics.Mean * 1000; // Convert to ms
                var error = report.ResultStatistics.StandardError * 1000; // Convert to ms
                var stdDev = report.ResultStatistics.StandardDeviation * 1000; // Convert to ms

                // Add row to the table
                table.AddRow(methodName, mean.ToString("F4"), error.ToString("F2"), stdDev.ToString("F4"));
            }

            // Display the table
            Console.WriteLine();
            Console.WriteLine("Benchmark Results:");
            table.Write(Format.Alternative);
            Console.WriteLine();

            Console.WriteLine("Benchmark completed.");
        }
    }
}
