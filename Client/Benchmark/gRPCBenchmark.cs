using System.Threading.Tasks;
using Grpc.Net.Client;

namespace Client.Benchmark
{
    public class gRPCBenchmark
    {
        private readonly GrpcChannel _channel;
        private readonly Greeter.GreeterClient _client;

        public gRPCBenchmark()
        {
            _channel = GrpcChannel.ForAddress("http://localhost:5000/");
            _client = new Greeter.GreeterClient(_channel);
        }

        public async Task<HelloResponse> Execute()
        {
            return await _client.SayHelloAsync(new HelloRequest { Name = $"Client" });
        }

        ~gRPCBenchmark()
        {
            _channel.Dispose();
        }        
    }
}
