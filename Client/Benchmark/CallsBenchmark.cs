using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace Client.Benchmark
{
    [MemoryDiagnoser]
    [AsciiDocExporter]
    [CsvExporter]
    [CsvMeasurementsExporter]
    [HtmlExporter]
    [PlainExporter]
    [RPlotExporter]
    public class CallsBenchmark
    {
        [Params(100, 200)]
        public int IterationCount;

        readonly RestBenchmark restBenchmark = new RestBenchmark();
        readonly gRPCBenchmark gRPCBenchmark = new gRPCBenchmark();

        [Benchmark()]
        [BenchmarkCategory("small")]
        public async Task RestSmall()
        {
            for (int i = 0; i < IterationCount; i++)
                await restBenchmark.Execute();
        }

        [Benchmark]
        [BenchmarkCategory("small")]
        public async Task gRPCSmall()
        {
            for (int i = 0; i < IterationCount; i++)
                await gRPCBenchmark.Execute();
        }

        [Benchmark()]
        [BenchmarkCategory("large")]
        public async Task RestLarge()
        {
            for (int i = 0; i < IterationCount; i++)
                await restBenchmark.ExecuteLarge();
        }

        [Benchmark]
        [BenchmarkCategory("large")]
        public async Task gRPCLarge()
        {
            for (int i = 0; i < IterationCount; i++)
                await gRPCBenchmark.ExecuteLarge();
        }

        [Benchmark()]
        [BenchmarkCategory("multipleFields")]
        public async Task RestMultiple()
        {
            for (int i = 0; i < IterationCount; i++)
                await restBenchmark.ExecuteMultipleFields();
        }

        [Benchmark]
        [BenchmarkCategory("multipleFields")]
        public async Task gRPCMultiple()
        {
            for (int i = 0; i < IterationCount; i++)
                await gRPCBenchmark.ExecuteMultipleFields();
        }

        [Benchmark()]
        [BenchmarkCategory("multipleFieldsList")]
        public async Task RestMultipleList()
        {
            for (int i = 0; i < IterationCount; i++)
                await restBenchmark.ExecuteMultipleFieldsList();
        }

        [Benchmark]
        [BenchmarkCategory("multipleFieldsList")]
        public async Task gRPCMultipleList()
        {
            for (int i = 0; i < IterationCount; i++)
                await gRPCBenchmark.ExecuteMultipleFieldsList();
        }
    }
}