using Grpc.Net.Client;
using Proto.Library;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<HelloResponse> ExecuteLarge()
        {
            return await _client.LargeSayHelloResponseAsync(new HelloRequest { Name = $"Client" });
        }

        public async Task<MultipleFieldsResponse> ExecuteMultipleFields()
        {
            return await _client.MultipleFieldsAsync(CreateMultipleFieldsRequest());
        }

        public async Task<MultipleFieldsResponseList> ExecuteMultipleFieldsList()
        {
            var request = new MultipleFieldsRequestList();
            request.List.AddRange(CreateMultipleFieldsResponseList());
            return await _client.MultipleFieldsListAsync(request);
        }

        private IEnumerable<MultipleFieldsRequest> CreateMultipleFieldsResponseList()
            => Enumerable.Repeat(CreateMultipleFieldsRequest(), Constraints.ListCount);

        private MultipleFieldsRequest CreateMultipleFieldsRequest()
            => new MultipleFieldsRequest
            {
                Prop1 = "teste---",
                Prop2 = 780784,
                Prop3 = "teste---",
                Prop4 = "teste---",
                Prop5 = "teste---",
                Prop6 = "teste---",
                Prop7 = "teste---",
                Prop8 = 878048040,
                Prop9 = "teste---",
                Prop10 = "teste---"
            };

        ~gRPCBenchmark()
        {
            _channel.Dispose();
        }        
    }
}
