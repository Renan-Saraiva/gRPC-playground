using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Client.Benchmark
{
    [MemoryDiagnoser]
    public class CallsBenchmark
    {
        [Params(100)]
        public int IterationCount;

        readonly APIBenchmark apiBenchmark = new APIBenchmark();
        readonly gRPCBenchmark gRPCBenchmark = new gRPCBenchmark();

        [Benchmark]
        public async Task API()
        {
            for (int i = 0; i < IterationCount; i++)
                await apiBenchmark.Execute();
        }

        [Benchmark]
        public async Task gRPC()
        {
            for (int i = 0; i < IterationCount; i++)
                await gRPCBenchmark.Execute();
        }
    }
}