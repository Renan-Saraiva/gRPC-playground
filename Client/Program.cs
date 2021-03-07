using BenchmarkDotNet.Running;
using Client.Benchmark;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CallsBenchmark>();
        }
    }
}
